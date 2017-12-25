using battle;

using model.character;


namespace model.card {

    public abstract class Card {

        public string Name { get; set; }

        public string SimgleDesc { get; set; }

        public Character character;

        private Character target;

        protected int cooldownTime;

        protected int firstCooldown;

        public UCard uCard;

        public CardType CardType = CardType.Base;

        public CardProperty CardProperty = CardProperty.Nomal;

        public CardCost Cost = new CardCost();

        public int FirstCooldown {
            get { return firstCooldown; }
            set { firstCooldown = value; }
        }

        public int CooldownTime {
            get { return cooldownTime; }
            set { cooldownTime = value; }
        }
    
        public virtual Character ChooseTarget(BattleManager manager, Character user) {
            if(user as Hero) {
                target=manager.Monster;
            }
            if(user as Monster) {
                target= manager.Hero;
            }
            return target;
        }

        public abstract void PlayEffect(BattleManager manager, Character user);

        public virtual bool CouldCharacterUse(BattleManager manager,Character user) {
            if( uCard.CurrentCooldown>0) {
                return false;
            }
            if(!Cost.CouldCharacterCost(manager,user)) {
                return false;
            }
            return true;
        }
    

    }

}