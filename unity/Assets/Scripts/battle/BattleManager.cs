using System.Collections.Generic;

using battle.deckarea;

using common.config;

using model.card;
using model.character;

using UnityEngine;
using UnityEngine.UI;


namespace battle {

    public class BattleManager : MonoBehaviour {

        private HandsArea handsArea;

        public YieldArea yieldArea;

        public DeckArea deckArea;

        public GraveArea graveArea;

        public UCard ucard;

        public Button EndHeroTurnBtn;

        private List<UCard> allCards = new List<UCard>();


        public Hero Hero { get; set; }

        public Monster Monster;


        private void initHeroDeckCards() {
            foreach(var card in Hero.Deck) {
                var temp = Instantiate(ucard);
                temp.Card = card;
                temp.character = Hero;
                deckArea.AddCard(temp);
                allCards.Add(temp);
            }

            deckArea.cards.Sort();
        }


        public void MoveCard(UCard card, CardStatus from, CardStatus to) {
            if(from == CardStatus.InHands && to == CardStatus.InYield) {
                handsArea.RemoveCard(card);
                yieldArea.AddCard(card);
                return;
            }

            if(from == CardStatus.InYield && to == CardStatus.InGrave) {
                yieldArea.RemoveCard(card);
                graveArea.AddCard(card);
                return;
            }
        }

        public void Start() {
            Config.BattleManager = this;
            initCardAreas();
            initHeroDeckCards();
            initData();
            beginBattle();
        }

        private void initData() {
            Hero = Config.Hero;
            Monster = Config.Monster;
        }

        private void beginBattle() {
            DrawCard(Hero, 2);
        }

        private void GoTurnsOn() {
            DrawCard(Hero, 1);
        }

        public void Shuffle() {
            for(int i = graveArea.cards.Count - 1; i >= 0; i--) {
                var temp = graveArea.cards[i];
                graveArea.RemoveCard(temp);
                deckArea.AddCard(temp);
            }

            // TODO 随机洗牌算法
        }

        public void DrawCard(Character c, int n) {
            if(c is Hero) {
                for(var i = 0; i < n; i++) {
                    if(deckArea.cards.Count < 1) {
                        Shuffle();
                    }
                    if(deckArea.cards.Count == 0) {
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
            ucard = GetComponentInChildren<UCard>();
            ucard.gameObject.SetActive(false);
        }

        private void deleteAllCardsCooldown() {
            foreach(var card in allCards) {
                if(card.CurrentCooldown == 0) {
                    continue;
                }

                card.CurrentCooldown -= 1;
            }
        }

        public void OnHeroTurnEnd() {
            Debug.Log(" hero turn end");

            for(int i = yieldArea.cards.Count - 1; i >= 0; i--) {
                var temp = yieldArea.cards[i];
                yieldArea.RemoveCard(temp);
                graveArea.AddCard(temp);
            }

            graveArea.ResetCardsCooldown();

            deleteAllCardsCooldown();
            GoTurnsOn();
        }

        public void OnMonsterTurnBegin() {
        }

    }

}