using Model;

using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace Manager {

    public class HandsArea : MonoBehaviour {

        private Canvas _canvas;

        private IPanel _panel;

        public BattleManager _battleManager;

        public UCard tempUCard;

        public HandsArea() {
          
        }

        protected void Start() {
            _canvas = transform.GetComponentInChildren<Canvas>();
            _panel = transform.GetComponentInChildren<IPanel>();
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