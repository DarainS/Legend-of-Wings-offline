using Manager;

using UnityEngine;
using UnityEngine.UI;


namespace Model.character {

    public class Monster : Character {

        private RectTransform RectTransform;

        Monster() {
            Health = 20;
            MaxHealth = 30;
        }
        
        public override int Health {
            get { return _health; }
            set {
                _health = value;
                if(slider != null && maxHealth != 0) {
                    slider.value = _health;
                }
            }
        }

        public override int MaxHealth {
            get { return maxHealth; }
            set {
                maxHealth = value;
                if(slider) {
                    slider.maxValue = maxHealth;
                }
            }
        }

        protected Slider slider;


        void initData() {
            deck.Add(new IceAttack(this));
            deck.Add(new StoneSkin(this));
            deck.Add(new IceAttack(this));
            deck.Add(new IceAttack(this));
        }

        void Start() {
            manager = GetComponentInParent<BattleManager>();

            slider = gameObject.GetComponentInChildren<Slider>();
            RectTransform = GetComponent<RectTransform>();
            slider.maxValue = MaxHealth;
            slider.value = Health;
            var st=slider.GetComponent<RectTransform>();
            st.position = RectTransform.position;
            initData();
        }
    }

}