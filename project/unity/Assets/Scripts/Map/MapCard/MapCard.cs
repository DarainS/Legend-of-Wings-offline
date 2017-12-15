using UnityEngine;
using UnityEngine.UI;


namespace MapCard {

    public class MapCard : MonoBehaviour {

        protected Image _image;

        protected string _name;

        private void Start() {
            _image = GetComponent<Image>();
        }

    }

}