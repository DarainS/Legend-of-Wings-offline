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

        void initData() {
            deck.Add(new IceAttack(this));
            deck.Add(new StoneSkin(this));
            deck.Add(new IceAttack(this));
            deck.Add(new IceAttack(this));
        }

        void Start() {
            manager = GetComponentInParent<BattleManager>();

            RectTransform = GetComponent<RectTransform>();

            initData();
        }
    }

}