using Model;

using UnityEngine;


namespace Manager {

    public class YieldArea : MonoBehaviour {

        public RectTransform rectTransform;

        private void Start() {
            rectTransform = GetComponent<RectTransform>();
        }

        public void AddCard(UCard card) {
            card.transform.parent = transform;
            card.rectTransform.position = rectTransform.position;
        }
    }

}