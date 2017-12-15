using UnityEngine;
using UnityEngine.UI;


namespace MapCard {

    public class MapCard : MonoBehaviour {

        protected Image _image;

        protected string _name;

        protected Text nameText;

        private void Start() {
            _image = GetComponentInChildren<Image>();
            nameText = GetComponentInChildren<Text>();
        }
        
        
        
    }

}