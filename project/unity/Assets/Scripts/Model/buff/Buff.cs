using UnityEngine;
using UnityEngine.UI;


namespace Model.buff {

    public class Buff : MonoBehaviour
    {

        private Character owner;

        public Character Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        private string _name;

        private string _desc;

        private Image _image;
        
        public BuffType Type;

        public string Name {
            get { return _name; }
            set { _name = value; }
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