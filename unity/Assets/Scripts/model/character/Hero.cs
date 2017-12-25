using battle;

using model.card.attack;
using model.card.@base;
using model.card.charge;
using model.card.mana;


namespace model.character {

    public class Hero : Character {
        
        public int Gold { get; set; }
        
        public Hero() {
            initData();
        }

        private void initData() {
            MaxHealth = 30;
            Health = 26;
            MaxMana = 20;
            Mana = 14;

            deck.Add(new IceAttack());
            deck.Add(new StoneSkin());
            deck.Add(new Meditation());
            deck.Add(new FireBall());
        }

        private void Start() {
            manager = GetComponentInParent<BattleManager>();
            healthSlider.value = Health;
            healthSlider.maxValue = MaxHealth;
            secondarySlider.maxValue = MaxMana;
            secondarySlider.value = Mana;
        }

    }

}