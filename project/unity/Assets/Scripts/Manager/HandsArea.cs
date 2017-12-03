using Model;

using UnityEngine;


namespace Manager {

    public class HandsArea : MonoBehaviour {

        private Canvas _canvas;
        
        public void AddCard(Card card) {
            card.transform.parent = transform;
        }
        
    }
    
    

}