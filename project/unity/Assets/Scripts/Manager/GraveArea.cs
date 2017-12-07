using Model;

using UnityEngine;


namespace Manager {

    public class GraveArea : BaseCardAreaManager {

        public override void AddCard(UCard card) {
            card.gameObject.SetActive(false);
            card.transform.SetParent(transform);
            cards.Add(card);
        }

        public override void RemoveCard(UCard card) {
            cards.Remove(card);
        }

        public override void ChangeAreaView() {
            throw new System.NotImplementedException();
        }

        public void ResetCardsCooldown() {
            foreach(var card in cards) {
                card.CurrentCooldown = card.MaxCooldownTime;
            }
        }

    }

}