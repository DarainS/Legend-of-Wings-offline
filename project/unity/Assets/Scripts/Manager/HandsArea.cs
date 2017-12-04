using Model;

using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace Manager {

    public class HandsArea : MonoBehaviour {

        public BattleManager battleManager;

        public RectTransform rectTransform;

        void Awake() {
            rectTransform = GetComponent<RectTransform>();
        }

        private int size = -2;
        
        public void AddCard(UCard uCard) {
            uCard.transform.parent = transform;
            size++;
            uCard.rectTransform.position = rectTransform.position+new Vector3(170*size,0);
        }

        
    }
    
    

}