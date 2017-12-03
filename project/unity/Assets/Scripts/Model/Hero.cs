using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.UIElements;
using Slider = UnityEngine.UI.Slider;

namespace Model {
    public class Hero : Character {

        public Hero() {
            MaxHealth = 10;
            CurrentHealth = 6;
        }

        public int CurrentHealth {
            get { return currentHealth; }
            set {
                currentHealth = value;
                if(slider != null && maxHealth != 0) {
                    slider.value = currentHealth / maxHealth;
                }
            }
        }


        public int MaxHealth {
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
            deck.Add(gameObject.AddComponent<IceAttack>());
            deck.Add(gameObject.AddComponent<StoneSkin>());
        }
        
        void Start() {
            initData();
            Canvas canvas = transform.GetComponentInChildren<Canvas>();
            slider = canvas.gameObject.GetComponentInChildren<Slider>();

            slider.value = CurrentHealth;
            slider.maxValue = MaxHealth;
        }

        
    }
}