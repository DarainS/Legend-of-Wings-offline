using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using battle;

using model.card;
using model.damage;

using UnityEngine;
using UnityEngine.UI;


namespace model.character {

    public class Character : MonoBehaviour {

        public readonly List<CardAction<Damage, Damage>> beforeDamage = new List<CardAction<Damage, Damage>>();

        public readonly List<CardAction<Damage, Damage>> afterDamage = new List<CardAction<Damage, Damage>>();

        private readonly Hashtable _eventMap = new Hashtable(100);

        private int _maxHealth;

        protected readonly List<Card> deck = new List<Card>(30);

        private int _maxEnergy;

        public Slider healthSlider;

        public Text healthText;

        public Slider secondarySlider;

        public Text SecondaryText;
           
        
        private Dictionary<ResourceType,int> _resourseTable=new Dictionary<ResourceType,int>();

        public int GetResourceNum(ResourceType type) {
            return _resourseTable[type];
        }
        
        public void SetResourceNum(ResourceType type,int num) {
              _resourseTable[type]=num;
        }
        

        public Character() {
            foreach(ResourceType type in Enum.GetValues(typeof(ResourceType))) {
                _resourseTable.Add(type,0);
            }
            Major = 1;
            Minor = 1;
            
        }

        public int Major {
            get { return (int) _resourseTable[ResourceType.Major]; }
            set {
                _resourseTable[ResourceType.Major] = value;
            }
        }
        
        public int Minor {
            get { return (int) _resourseTable[ResourceType.Minor]; }
            set {
                _resourseTable[ResourceType.Minor] = value;
            }
        }
        
        public int Health {
            get { return (int) _resourseTable[ResourceType.Health]; }
            set {
                if(value<=0) {
                    value = 0;
                    OnDeath();
                }
                if(value> MaxHealth) {
                    value = MaxHealth;
                }
                _resourseTable[ResourceType.Health] = value;
                if(healthText != null) {
                    healthText.text = value + "/" + _maxHealth;
                }
                if(healthSlider != null && _maxHealth != 0) {
                    healthSlider.value = value;
                }
            }
        }

        protected virtual void OnDeath() {
            
        }

        public int MaxHealth {
            get { return _maxHealth; }
            set {
                _maxHealth = value;
                if(healthSlider) {
                    healthSlider.maxValue = _maxHealth;
                }
            }
        }

        public int Energy {
            get { return (int) _resourseTable[ResourceType.Energy]; }
            set {
                _resourseTable[ResourceType.Energy] = value;
                if(secondarySlider != null) {
                    secondarySlider.value = value;
                }

                if(SecondaryText) {
                    SecondaryText.text = value + "/" + MaxEnergy;

                }
            }
        }

        public int MaxEnergy {
            get { return _maxEnergy; }
            set {
                _maxEnergy = value;
                if(secondarySlider != null) {
                    secondarySlider.maxValue = value;
                }
            }
        }

        protected int _rage;

        public int Rage {
            get { return _rage; }
            set { _rage = value; }
        }

        protected int _maxRage;

        public int MaxRage {
            get { return _maxRage; }
            set { _maxRage = value; }
        }

        public BattleManager manager;
        
        public int armor;

        public List<Card> Deck {
            get { return deck; }
        }

        public List<CardAction<Damage, Damage>> BeforeDamage {
            get { return beforeDamage; }
        }


        public void TakeDamage(Damage damage) {
//            beforeDamage.Sort();
            damage = beforeDamage.Aggregate(damage, (current, action) => action.playEffect(current));

            Health -= damage.Num;
            
            foreach(var action in afterDamage) {
                action.playEffect(damage);
            }
        }

        public void PlayEffect(UCard ucard) {
            ucard.PlayEffect(manager, this);
        }

        public bool CouldUseCard(UCard card) {
            return card.CouldCharacterUse(manager, this);
        }

        // Use this for initialization
        private void Start() {
            
            manager = GetComponentInParent<BattleManager>();
            var names = Enum.GetNames(typeof(CharacterEventType));
//            foreach(var name in names) {
//                CharacterEventType p;
//                CharacterEventType.TryParse(name, true, p);
//                Enum.TryParse(name, true, out p);
//                _eventMap.Add(p, new List<CardAction<System.Object, System.Object>>());
//            }
        }

        public virtual void EndTurn() {
            Major = 1;
            Minor = 1;
            Energy += 1;
        }

        public virtual void BeginNewTurn() {
            
        }

        public List<CardAction<System.Object, System.Object>> GetEventList(CharacterEventType eventType) {
            return (List<CardAction<object, object>>) _eventMap[eventType];
        }

        public void AddEvent(CharacterEventType eventType, CardAction<System.Object, System.Object> action) {
            ((List<CardAction<object, object>>) _eventMap[eventType]).Add(action);
        }

       

    }

}