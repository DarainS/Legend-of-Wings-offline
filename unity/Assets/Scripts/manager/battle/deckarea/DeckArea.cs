using model.card;

using UnityEngine.UI;


namespace manager.battle.deckarea {

    public class DeckArea : BaseCardAreaManager {

        private Text text;

        public override void AddCard(UCard card) {
            card.gameObject.SetActive(false);
            card.transform.SetParent(transform);
            cards.Add(card);
            ChangeAreaView();
        }

        public override void RemoveCard(UCard card) {
            cards.Remove(card);
            ChangeAreaView();
        }

        private void Start() {
            text = GetComponentInChildren<Text>();
            text.text = "Left Cards: " + cards.Count;
        }

        public override void ChangeAreaView() {
            text.text = "Left Cards: " + cards.Count;
        }

    }

}