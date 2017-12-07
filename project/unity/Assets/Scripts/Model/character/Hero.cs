using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using Manager;


using Slider = UnityEngine.UI.Slider;


namespace Model.character {

    public class Hero : Character {

        Hero() {
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
            MaxHealth = 30;
            CurrentHealth = 26;
            
            deck.Add(new IceAttack(this));
            deck.Add(new StoneSkin(this));
            deck.Add(new IceAttack(this));
            deck.Add(new IceAttack(this));
        }

        void Start() {
            manager = GetComponentInParent<BattleManager>();
            slider = gameObject.GetComponentInChildren<Slider>();
            slider.value = CurrentHealth;
            slider.maxValue = MaxHealth;
        }

    }

}