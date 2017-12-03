using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Model.damage;
using UnityEngine;
using Object = System.Object;

namespace Model {
    public class Character : MonoBehaviour {
        
        protected List<CardAction<Damage, Damage>> beforeDamage = new List<CardAction<Damage, Damage>>();

        protected List<CardAction<Damage, Damage>> afterDamage = new List<CardAction<Damage, Damage>>();

        protected int currentHealth;
        
        protected int maxHealth;

        protected List<Card> deck= new List<Card>(30);

        public List<Card> Deck {
            get { return deck; }
            set { deck = value; }
        }
        
        protected List<Card> hands= new List<Card>(10);

        public List<Card> Hands {
            get { return hands; }
            set { hands = value; }
        }

        public virtual int CurrentHealth {
            get { return currentHealth; }
            set { currentHealth = value; }
        }


        public virtual int MaxHealth {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        public List<CardAction<Damage, Damage>> BeforeDamage {
            get { return beforeDamage; }
            set { beforeDamage = value; }
        }

        public List<CardAction<Damage, Damage>> AfterDamage {
            get { return afterDamage; }
            set { afterDamage = value; }
        }

        public void TakeDamage(Damage damage) {
            beforeDamage.Sort();
            damage = beforeDamage.Aggregate(damage, (current, action) => action.playEffect(current));

            CurrentHealth -= damage.Num;

            foreach(var action in afterDamage) {
                action.playEffect(damage);
            }
        }

       

        // Use this for initialization
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
        }
    }
}