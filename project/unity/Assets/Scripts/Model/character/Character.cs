using Model;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Manager;

using Model.damage;

using UnityEngine;
using UnityEngine.UI;



namespace Model {

    public class Character : MonoBehaviour {

        public List<CardAction<Damage, Damage>> beforeDamage = new List<CardAction<Damage, Damage>>();

        public List<CardAction<Damage, Damage>> afterDamage = new List<CardAction<Damage, Damage>>();

        protected int _health;

        protected int maxHealth;

        protected List<Card> deck = new List<Card>(30);

        protected int _mana;

        protected int _maxMana;
        
        public Slider healthSlider;

        public Slider secondarySlider;
        
        public int Health {
            get { return _health; }
            set {
                _health = value;
                if(healthSlider != null && maxHealth != 0) {
                    healthSlider.value = _health;
                }
            }
        }

        public int MaxHealth {
            get { return maxHealth; }
            set {
                maxHealth = value;
                if(healthSlider) {
                    healthSlider.maxValue = maxHealth;
                }
            }
        }

        public int Mana {
            get { return _mana; }
            set {
                _mana = value;
                if(secondarySlider!=null) {
                    secondarySlider.value = value;
                }
            }
        }

        public int MaxMana {
            get { return _maxMana; }
            set {
                _maxMana = value;
                if(secondarySlider !=null ) {
                    secondarySlider.maxValue = value;
                }
            }
        }
        
        protected int _energy;
        
        public int Energy {
            get { return _energy; }
            set { _energy = value; }
        }
        
        protected int _maxEnergy;
        
        public int MaxEnergy {
            get { return _maxEnergy; }
            set { _maxEnergy = value; }
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
            beforeDamage.Sort();
            damage = beforeDamage.Aggregate(damage, (current, action) => action.playEffect(current));

            Health -= damage.Num;

            foreach(var action in afterDamage) {
                action.playEffect(damage);
            }
        }

        public void PlayEffect(UCard ucard) {
            ucard.PlayEffect(manager,this);
        }

        public bool CouldUseCard(UCard card) {
            return card.CouldCharacterUse(manager,this);
        }

        // Use this for initialization
        void Start() {
            manager = GetComponentInParent<BattleManager>();
        }

        // Update is called once per frame
        void Update() {
        }

    }

}