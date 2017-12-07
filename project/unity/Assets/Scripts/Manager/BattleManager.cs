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

        public Monster Monster;

        private void initHeroDeckCards() {
            foreach(var card in hero.Deck) {
                var temp = Instantiate(ucard);
                temp.Card = card;
                temp.character = hero;
                deckArea.AddCard(temp);
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
            initCardAreas();
           

            initHeroDeckCards();
            beginBattle();
        }

        private void beginBattle() {
            DrawCard(hero, 2);
        }

        private void GoTurnsOn() {
            DrawCard(hero,1);
        }

        public void Shuffle() {
            for(int i = graveArea.cards.Count - 1; i >= 0; i--) {
                var temp = graveArea.cards[i];
                graveArea.RemoveCard(temp);
                deckArea.AddCard(temp);
            }
            // TODO 随机洗牌算法
        }        
        
        public void DrawCard(Character c,int n) {
            if( c is Hero) {
                for(int i = 0; i < n; i++) {
                    if(deckArea.cards.Count<1) {
                        Shuffle();
                    }
                    if(deckArea.cards.Count==0) {
                        return;
                    }
                    var temp = deckArea.cards[0];
                    deckArea.RemoveCard(temp);
                    handsArea.AddCard(temp);
                }
               
            }
        }
        
        private void initCardAreas() {
            handsArea = GetComponentInChildren<HandsArea>();
            handsArea.battleManager = this;
            yieldArea = GetComponentInChildren<YieldArea>();
            deckArea = GetComponentInChildren<DeckArea>();
            graveArea = GetComponentInChildren<GraveArea>();
            
            Hero = GetComponentInChildren<Hero>();
            Monster = GetComponentInChildren<Monster>();
            ucard = transform.GetComponentInChildren<UCard>();
            ucard.gameObject.SetActive(false);
            
        }

        public void OnHeroTurnEnd() {
            Debug.Log(" hero turn end");
            foreach(var card in yieldArea.cards) {
                graveArea.AddCard(card);
            }
            yieldArea.RemoveAllCard();
            GoTurnsOn();
            
        }
        
        

    }

}