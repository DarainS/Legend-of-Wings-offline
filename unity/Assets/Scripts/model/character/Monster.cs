
using common.config;

using manager.battle;

using model.card.attack;
using model.card.@base;
using model.card.mana;
using model.character;

using UnityEngine;
using UnityEngine.UI;


namespace model.character {

    public class Monster : Character {

        private RectTransform RectTransform;

        private void initData() {
            deck.Add(new IceAttack());
            deck.Add(new StoneSkin());
            deck.Add(new IceAttack());
            deck.Add(new FireBall());
            MaxHealth = 12;
            Health = 12;
            
            healthSlider.maxValue = MaxHealth;
            healthSlider.value = Health;
//            secondarySlider.maxValue = MaxEnergy;
//            secondarySlider.value = Energy;
        }

        private void Start() {
            manager = GetComponentInParent<BattleManager>();
            RectTransform = GetComponent<RectTransform>();
            initData();
        }

        protected override void OnDeath() {
            Config.BattleManager.PlayerBeatMonster(this);
        }

        public override void BeginNewTurn() {
            base.BeginNewTurn();
            int size = deck.Count;
            for(int i = 0; i < 2; i++) {
                int r = Random.Range(0, size - i-1);
                deck[r].PlayEffect(manager, this);
            }
        }

    }

}