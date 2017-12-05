using System;
using System.Collections.Generic;

using Model;
using Model.card;
using Model.character;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Manager {

    public class BattleManager : MonoBehaviour {

        private Hero hero;

        private HandsArea handsArea;

        public YieldArea yieldArea;

        public DeckArea deckArea;

        public GraveArea graveArea;

        public UCard ucard;

        public Button EndHeroTurnBtn;


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
                handsArea.AddCard(temp);
            }
        }


        public void MoveCard(UCard card, CardStatus from, CardStatus to) {
            if(from == CardStatus.InHands && to == CardStatus.InYield) {
                handsArea.RemoveCard(card);
                yieldArea.AddCard(card);
                return;
            }

            if(from == CardStatus.InYield && to == CardStatus.InDeck) {
                yieldArea.RemoveCard(card);
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

        }

        public void OnHeroTurnEnd() {
            Debug.Log(" hero turn end");
            foreach(var card in yieldArea.cards) {
                graveArea.AddCard(card);
            }
            yieldArea.RemoveAllCard();
        }

    }

}