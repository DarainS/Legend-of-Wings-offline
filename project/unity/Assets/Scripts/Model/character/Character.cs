using Model;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Manager;

using Model.damage;

using UnityEngine;

using Object = System.Object;


namespace Model {

    public class Character : MonoBehaviour {

        protected List<CardAction<Damage, Damage>> beforeDamage = new List<CardAction<Damage, Damage>>();

        protected List<CardAction<Damage, Damage>> afterDamage = new List<CardAction<Damage, Damage>>();

        protected int _health;

        protected int maxHealth;

        protected List<Card> deck = new List<Card>(30);

        protected int _mana;
        
        public int Mana {
            get { return _mana; }
            set { _mana = value; }
        }
        
        protected int _maxMana;
        public int MaxMana {
            get { return _maxMana; }
            set {
                _maxMana = value;

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

        public List<Card> Deck {
            get { return deck; }
        }

        public virtual int Health {
            get { return _health; }
            set { _health = value; }
        }

        public virtual int MaxHealth {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        public List<CardAction<Damage, Damage>> BeforeDamage {
            get { return beforeDamage; }
        }

        public List<CardAction<Damage, Damage>> AfterDamage {
            get { return afterDamage; }
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