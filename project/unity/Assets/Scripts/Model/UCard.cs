using UnityEngine;


namespace Model {

    public class UCard : MonoBehaviour {

        private Card _card;


        public UCard() {
            
        }

        public Card Card {
            get { return _card; }
            set { _card = value; }
        }

        public UCard(Card card) {
            _card = card;
        }

    }

}