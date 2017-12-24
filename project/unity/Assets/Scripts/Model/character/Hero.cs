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

      


        void initData() {
            MaxHealth = 30;
            Health = 26;
            MaxMana = 20;
            Mana = 14;

            deck.Add(new IceAttack());
            deck.Add(new StoneSkin());
            deck.Add(new Meditation());
            deck.Add(new FireBall());
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