using model.character;


using UnityEngine;
using UnityEngine.UI;


namespace model.buff {

    public class Buff : MonoBehaviour {

        public Character Source { get; set; }

        public Character Owner { get; set; }

        private string _name;

        private string _desc;

        private Image _image;

        private Text nameText;

        public BuffType Type;

        public string Name {
            get { return _name; }
            set {
                _name = value;
                nameText.text = _name;
            }
        }

        public string Desc {
            get { return _desc; }
            set { _desc = value; }
        }

        public Image Image {
            get { return _image; }
            set { _image = value; }
        }


        private void Start() {
            
        }

    }

}