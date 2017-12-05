using Model;

using UnityEngine;


namespace Manager {

    public class GraveArea : BaseCardAreaManager {

        public override void AddCard(UCard card) {
            card.gameObject.SetActive(false);
            cards.Add(card);
        }

        public override void RemoveCard(UCard card) {
            cards.Remove(card);
        }

    }

}