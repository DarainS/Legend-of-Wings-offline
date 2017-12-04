using Model;

using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace Manager {

    public class HandsArea : MonoBehaviour {


        public BattleManager battleManager;

        public UCard tempUCard;

        protected void Start() {
            
        }

        private int size = 0;
        
        public void AddCard(Card card) {
            UCard temp = Instantiate(tempUCard);
            temp.Card = card;
            temp.transform.parent = transform;
            size++;
            var p=temp.transform.position;
            temp.transform.position = new Vector3(p.x+200*size,p.y);
        }
        
    }
    
    

}