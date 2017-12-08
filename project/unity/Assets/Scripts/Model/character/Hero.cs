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
            MaxHealth = 30;
            Health = 26;
            
            
            
            deck.Add(new IceAttack(this));
            deck.Add(new StoneSkin(this));
            deck.Add(new IceAttack(this));
            deck.Add(new IceAttack(this));
        }

        void Start() {
            manager = GetComponentInParent<BattleManager>();
            slider = gameObject.GetComponentInChildren<Slider>();
            slider.value = Health;
            slider.maxValue = MaxHealth;
        }

    }

}