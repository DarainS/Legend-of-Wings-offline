using Model;

using UnityEngine;


namespace Manager {

    public class YieldArea : BaseCardAreaManager {

        public RectTransform rectTransform;

        private void Start() {
            rectTransform = GetComponent<RectTransform>();
        }

        public override void AddCard(UCard card) {
            card.transform.parent = transform;
            card.rectTransform.position = rectTransform.position;
            cards.Add(card);
        }

        public override void RemoveCard(UCard card)
        {
            cards.Remove(card);
        }
    }

}