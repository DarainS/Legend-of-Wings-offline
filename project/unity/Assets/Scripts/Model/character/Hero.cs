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
                if(healthSlider != null && maxHealth != 0) {
                    healthSlider.value = _health;
                }
            }
        }

        public override int MaxHealth {
            get { return maxHealth; }
            set {
                maxHealth = value;
                if(healthSlider) {
                    healthSlider.maxValue = maxHealth;
                }
            }
        }

        protected Slider healthSlider;


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
            healthSlider = gameObject.GetComponentInChildren<Slider>();
            healthSlider.value = Health;
            healthSlider.maxValue = MaxHealth;
        }

    }

}