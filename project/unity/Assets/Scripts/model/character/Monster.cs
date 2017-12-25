using battle;

using model.card.attack;
using model.card.@base;
using model.character;

using UnityEngine;
using UnityEngine.UI;


namespace model.character {

    public class Monster : Character {

        private RectTransform RectTransform;

        public Monster() {
            Health = 20;
            MaxHealth = 30;
        }

        void initData() {
            deck.Add(new IceAttack());
            deck.Add(new StoneSkin());
            deck.Add(new IceAttack());
            deck.Add(new IceAttack());
        }

        void Start() {
            manager = GetComponentInParent<BattleManager>();

            RectTransform = GetComponent<RectTransform>();

            initData();
        }
    }

}