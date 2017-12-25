
using dungeon;

using model.character;

using UnityEngine;
using UnityEngine.UI;


namespace MapCard {

    public class MapCard : MonoBehaviour {

        protected Image _image;

        protected string _name;

        protected Text nameText;

        public DungeonManager DungeonManager;

        private void Start() {
            _image = GetComponentInChildren<Image>();
            nameText = GetComponentInChildren<Text>();
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        protected virtual void OnClick() {
            var mon = new Monster();
            DungeonManager.GenerateBattle(DungeonManager.Hero, mon);
        }

    }

}