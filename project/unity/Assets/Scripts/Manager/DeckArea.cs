using Model;

using UnityEngine;


namespace Manager {

    public class DeckArea : BaseCardAreaManager {

        public override void AddCard(UCard card) {
            card.gameObject.SetActive(false);
            cards.Add(card);
            ChangeAreaView();
        }

        public override void RemoveCard(UCard card) {
            cards.Remove(card);
            ChangeAreaView();
        }

        public override void ChangeAreaView() {
            
        }

    }

}