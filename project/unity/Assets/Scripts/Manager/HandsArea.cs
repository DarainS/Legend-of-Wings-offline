using Model;

using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace Manager {

    public class HandsArea : MonoBehaviour {

<<<<<<< HEAD
        public BattleManager _battleManager;

        public UCard TempUCard;
=======

        public BattleManager battleManager;

        public UCard tempUCard;
>>>>>>> 346d8705667fc35bd3c2f8027b61cc8ba6c9712b

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