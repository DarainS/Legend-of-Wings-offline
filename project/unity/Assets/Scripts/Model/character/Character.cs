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

        protected List<Card> deck = new List<Card>(30);

        public List<Card> Deck {
            get { return deck; }
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
        }

        public List<CardAction<Damage, Damage>> AfterDamage {
            get { return afterDamage; }
        }

        public void TakeDamage(Damage damage) {
            beforeDamage.Sort();
            damage = beforeDamage.Aggregate(damage, (current, action) => action.playEffect(current));

            CurrentHealth -= damage.Num;

            foreach(var action in afterDamage) {
                action.playEffect(damage);
            }
        }

        public void PlayEffect(UCard ucard) {
            ucard.PlayEffect(this);
        }

        public bool CouldUseCard(UCard card) {
            return card.CouldCharacterUse(this);
        }

        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {
        }

    }

}