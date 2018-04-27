using battle;

using model.card.attack;
using model.card.@base;
using model.card.charge;
using model.card.mana;
using model.card.spell;


namespace model.character {

    public class Hero : Character {
        
        public int Gold { get; set; }
        
        public Hero():base() {
            initData();

        }
        
      

        private void initData() {
            MaxHealth = 40;
            Health = 40;
            MaxEnergy = 10;
            Energy = 0;
          


            deck.Add(new IceAttack());
//            deck.Add(new StoneSkin());
            deck.Add(new Meditation());
            deck.Add(new FireBall());
            deck.Add(new DunpaiAttack());
            deck.Add(new PhysicialAttack());
        }

        private void Start() {
            manager = GetComponentInParent<BattleManager>();
              
            healthSlider.maxValue = MaxHealth;
            healthSlider.value = Health;
            secondarySlider.maxValue = MaxEnergy;
            secondarySlider.value = Energy;
        }

        public void EndTurn() {
            
        }

    }

}