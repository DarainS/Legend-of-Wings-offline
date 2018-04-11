using model.card;

using UnityEngine;


namespace battle.deckarea {

    public class YieldArea : BaseCardAreaManager {

        private RectTransform rectTransform;

        private void Start() {
            rectTransform = GetComponent<RectTransform>();
        }

        private void changeCardsPosition() {
            var n = cards.Count;
            var w = 160;
            var total = (n - 1) * w;
            var begin = -(total / 2);
            for(var i = 0; i < n; i++) {
                cards[i].rectTransform.position = new Vector3(begin + w * i, 0) + rectTransform.position;
            }
        }

        public override void AddCard(UCard card) {
            card.gameObject.SetActive(true);
            card.transform.SetParent(transform);
            cards.Add(card);
            ChangeAreaView();
        }

        public override void RemoveCard(UCard card) {
            cards.Remove(card);
            ChangeAreaView();
        }

        public override void ChangeAreaView() {
            changeCardsPosition();
        }

        public void RemoveAllCard() {
            cards.Clear();
            ChangeAreaView();
        }

    }

}