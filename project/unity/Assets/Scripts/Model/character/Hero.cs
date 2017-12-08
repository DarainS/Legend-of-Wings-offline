using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using Manager;

using Model.card.charge;
using Model.card.mana;

using Slider = UnityEngine.UI.Slider;


namespace Model.character {

    public class Hero : Character {

        public Hero() {
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

        public int Mana {
            get { return _mana; }
            set {
                _mana = value;
                if(secondarySlider!=null) {
                    secondarySlider.value = value;
                }
            }
        }

        public int MaxMana {
            get { return _maxMana; }
            set {
                _maxMana = value;
                if(secondarySlider !=null ) {
                    secondarySlider.maxValue = value;
                }
            }
        }

        public Slider healthSlider;

        public Slider secondarySlider;


        void initData() {
            MaxHealth = 30;
            Health = 26;
            MaxMana = 20;
            Mana = 14;

            deck.Add(new IceAttack(this));
            deck.Add(new StoneSkin(this));
            deck.Add(new Meditation(this));
            deck.Add(new Meditation(this));
            deck.Add(new FireBall(this));
        }

        void Start() {
            manager = GetComponentInParent<BattleManager>();
            healthSlider.value = Health;
            healthSlider.maxValue = MaxHealth;
            secondarySlider.maxValue = MaxMana;
            secondarySlider.value = Mana;
        }

    }

}