using Model;

using UnityEngine;


namespace Manager {

    public class HandsArea : MonoBehaviour {

        private Canvas _canvas;

        private BattleManager _battleManager;

        public HandsArea() {
          
        }

        private void Awake() {
            _battleManager = (BattleManager) transform.GetComponentInParent(_battleManager.GetType());
            
        }

        public void AddCard(Card card) {
            
            UCard uCard = gameObject.AddComponent<UCard>();
            UCard c2=_battleManager.GetComponentInChildren<UCard>();
            uCard = Instantiate(c2);
            uCard.Card = card;
            uCard.gameObject.AddComponent<UCard>();
        }
        
    }
    
    

}