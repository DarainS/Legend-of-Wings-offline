using System.Collections;

using battle;

using model.character;


namespace model.card {

    public class CostAction {

        public CostType type { get; set; }
        public int num { get; set; }

        public CostAction(CostType type) {
            this.type = type;
        }

        public CostAction(CostType type, int costNum) {
            this.type = type;
            num = costNum;
        }

    }

    public enum CostType {

        Health,
        Mana,
        Energy,
        Rage,
        Major,
        Minor
        

    }
    
    public class CardCost {

        private CostAction healthCost = new CostAction(CostType.Health);
        private CostAction manaCost = new CostAction(CostType.Mana);
        private CostAction energyCost = new CostAction(CostType.Energy);
        private CostAction rageCost = new CostAction(CostType.Rage);
        private CostAction majorCost = new CostAction(CostType.Major);
        private CostAction minorCost = new CostAction(CostType.Minor);
        
        private Hashtable costTable = new Hashtable(10);

       public CardCost() {
            costTable.Add(CostType.Minor,new CostAction(CostType.Minor));
        }

        public CardCost AddCost(CostType type, int costNum) {
            if(type == CostType.Health) {
                healthCost.num += costNum;
            }
            else if(type == CostType.Energy) {
                energyCost.num += costNum;
            }
            else if(type == CostType.Mana) {
                manaCost.num += costNum;
            }
            else if(type == CostType.Rage) {
                rageCost.num += costNum;
            }
            else if(type==CostType.Major) {
                majorCost.num += costNum;
            }
            else if (type==CostType.Minor) {
                minorCost.num += costNum;
            }

            return this;
        }

        public bool CouldCharacterCost(BattleManager manager, Character user) {
            if(user.Mana < manaCost.num) {
                return false;
            }
            if(user.Energy < energyCost.num) {
                return false;
            }
            if(user.Rage < rageCost.num) {
                return false;
            }
            if(user.Health < healthCost.num) {
                return false;
            }

            return true;
        }

        public void Cost(BattleManager manager, Character user) {
            if(user is Hero) {
                var hero = user as Hero;
                hero.Mana -= manaCost.num;
                hero.Energy -= energyCost.num;
                hero.Rage -= rageCost.num;
                hero.Health -= healthCost.num;
            }
        }

    }



}