﻿using Model;
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

        protected List<UCard> hands = new List<UCard>(10);
        
        protected List<UCard> inPlayUCards= new List<UCard>(30);

        public List<Card> Deck {
            get { return deck; }
        }
        
        public List<UCard> Hands {
            get { return hands; }
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

        public void PlayEffect(Card card)
        {
            card.character = this;
            card.playEffect();
        }

        public bool CouldUseCard(Card card)
        {
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