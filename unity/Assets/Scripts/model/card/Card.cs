using battle;

using model.character;


namespace model.card {

    public abstract class Card {

        public string Name { get; set; }

        public string SimgleDesc { get; set; }

        public Character character;

        private Character target;

        protected int cooldownTime = 1;

        protected int firstCooldown = 1;

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
            if(user is Hero) {
                target = manager.Monster;
            }

            if(user is Monster) {
                target = manager.Hero;
            }

            return target;
        }

        public virtual void PlayEffect(BattleManager manager, Character user) {
            if(!CouldCharacterUse(manager, user)) {
                return;
            }
    
            Cost.Cost(manager, user);
        }

        public virtual void PlayEffect(BattleManager manager, Character user, Character target) {
            Cost.Cost(manager, user);
        }

        public virtual bool CouldCharacterUse(BattleManager manager, Character user) {
            if(uCard.CurrentCooldown > 0) {
                return false;
            }

            if(!Cost.CouldCharacterCost(manager, user)) {
                return false;
            }

            return true;
        }

    }

}