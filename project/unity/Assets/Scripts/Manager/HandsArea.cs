using Model;

using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace Manager {

    public class HandsArea : MonoBehaviour {

        public BattleManager _battleManager;

        public UCard TempUCard;

        protected void Start() {
            
        }

        private int size = 0;
        
        public void AddCard(Card card) {
            var temp = Instantiate(TempUCard);
            temp.Card = card;
            temp.transform.parent = transform;
//            temp.transform.position = new Vector3(0, 0);
            size++;
            temp.transform.position += new Vector3(200*size,0);
        }

        private void changeHandsCardPosition() {
            
        }
        
    }
    
    

}