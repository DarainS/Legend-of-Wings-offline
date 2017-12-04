using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.UIElements;
using Slider = UnityEngine.UI.Slider;

namespace Model.character {
    public class Hero : Character
    {
        
        public Hero() {
            MaxHealth = 30;
            CurrentHealth = 26;
            initData();
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
        }
        
        void Start() {

            slider = gameObject.GetComponentInChildren<Slider>();

            slider.value = CurrentHealth;
            slider.maxValue = MaxHealth;
        }

        
    }
}