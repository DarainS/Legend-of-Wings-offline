using Model;

using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace Manager {

    public class HandsArea : MonoBehaviour {

        public BattleManager _battleManager;

        public UCard TempUCard;

        public BattleManager battleManager;

        public UCard tempUCard;

        protected void Start() {
            
        }

        private int size = 0;
        
        public void AddCard(UCard uCard) {
            uCard.transform.parent = transform;
            size++;
            uCard.transform.position += new Vector3(200*size,0);
        }

        private void changeHandsCardPosition() {
            
        }
        
    }
    
    

}