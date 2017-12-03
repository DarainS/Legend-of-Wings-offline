using UnityEngine;
using UnityEngine.UI;


namespace Model {

    public class UCard : MonoBehaviour {

        public Text cardName;
        
        public Text cardSimpleDesc;
           
        
        private Card _card;

        public UCard() {
            
        }

        public Card Card {
            get { return _card; }
            set {
                _card = value; 
            }
        }

        public string Name {
            get { return _card.Name; }
            set { _card.Name = value; }
        }

        public UCard(Card card) {
            _card = card;
        }

        private void Start() {
            cardName.text = _card.Name;
            cardSimpleDesc.text = _card.SimgleDesc;
            
        }

    }

}