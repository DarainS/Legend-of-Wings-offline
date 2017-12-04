﻿using System;

using Model;

using UnityEngine;


namespace Manager {

    public class BattleManager : MonoBehaviour {

        private Hero _hero;
        private HandsArea handsArea;
        public UCard _ucard;

        public Hero Hero {
            get { return _hero; }
            set { _hero = value; }
        }

        private void initHandsArea() {
            foreach(var card in _hero.Deck) {
                Debug.Log("load card: " + card.Name);
                handsArea.AddCard(card);
            }
        }

        public void Start() {
            Hero = transform.GetComponentInChildren<Hero>();
            handsArea = transform.GetComponentInChildren<HandsArea>();
            handsArea._battleManager = this;
            _ucard = transform.GetComponentInChildren<UCard>();
            handsArea.TempUCard = _ucard;
            initHandsArea();
        }

    }

}