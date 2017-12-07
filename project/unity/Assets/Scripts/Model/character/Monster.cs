using UnityEngine;
using UnityEngine.UI;


namespace Model.character {

    public class Monster : Character {

        private RectTransform RectTransform;

        Monster() {
            CurrentHealth = 20;
            MaxHealth = 30;
        }
        
        public override int CurrentHealth {
            get { return currentHealth; }
            set {
                currentHealth = value;
                if(slider != null && maxHealth != 0) {
                    slider.value = currentHealth;
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
            slider = gameObject.GetComponentInChildren<Slider>();
            RectTransform = GetComponent<RectTransform>();
            slider.maxValue = MaxHealth;
            slider.value = CurrentHealth;
            var st=slider.GetComponent<RectTransform>();
            st.position = RectTransform.position;
            initData();
        }
    }

}