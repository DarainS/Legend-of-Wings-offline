using System.Collections.Generic;

using Model;

using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace Manager {

    public class HandsArea : BaseCardAreaManager {

        public BattleManager battleManager;

        public RectTransform rectTransform;

        void Awake() {
            rectTransform = GetComponent<RectTransform>();
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
            changeCardPosition();
        }

        private void changeCardPosition() {
            cards.Sort();
            var n = cards.Count;
            const int w = 180;
            var total = (n - 1) * w;
            var begin = -(total / 2);
            for(var i = 0; i < n; i++) {
                cards[i].rectTransform.position = new Vector3(begin + w * i, 0) + rectTransform.position;
                cards[i].transform.SetSiblingIndex(i);
            }
        }

    }

}