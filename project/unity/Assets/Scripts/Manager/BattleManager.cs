using System;
using System.Collections.Generic;

using Model;
using Model.card;
using Model.character;

using UnityEngine;
using UnityEngine.UI;


namespace Manager {

    public class BattleManager : MonoBehaviour {

        private Hero hero;
        
        private HandsArea handsArea;

        public YieldArea yieldArea;
        
        public UCard ucard;

        public Button EndHeroTurnBtn;

        private List<UCard> heroCards = new List<UCard>(30);

        public Hero Hero {
            get { return hero; }
            set { hero = value; }
        }

        private void initHeroDeckCards() {
            foreach(var card in hero.Deck) {
                var temp = Instantiate(ucard);
                temp.enabled = true;
                temp.Card = card;
                temp.gameObject.SetActive(true);

                temp.character = hero;
                heroCards.Add(temp);
            }
        }

        private void initHandsArea() {
            foreach(var ucard in heroCards) {
                handsArea.AddCard(ucard);
            }
        }


        public void MoveCard(UCard ucard, CardStatus from, CardStatus to) {
            if(from == CardStatus.InHands && to == CardStatus.InYield) {
                yieldArea.AddCard(ucard);
                return;
            }
        }

        public void Start() {
            Hero = GetComponentInChildren<Hero>();
            handsArea = GetComponentInChildren<HandsArea>();
            handsArea.battleManager = this;

            yieldArea = GetComponentInChildren<YieldArea>();
            
            ucard = transform.GetComponentInChildren<UCard>();
            ucard.gameObject.SetActive(false);

            initHeroDeckCards();
            initHandsArea();
        }

    }

}