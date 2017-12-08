using Manager;


namespace Model.card {

    public class CardCost {

        private CostAction healthCost= new CostAction(CostType.Health);
        private CostAction manaCost= new CostAction(CostType.Mana);
        private CostAction energyCost= new CostAction(CostType.Energy);
        private CostAction rageCost= new CostAction(CostType.Rage);

        public CardCost AddCost(CostType type, int costNum) {
            if(type== CostType.Health) {
                healthCost.num += costNum;
            }
            else if(type== CostType.Energy) {
                energyCost.num += costNum;
            }
            else if(type== CostType.Mana) {
                manaCost.num += costNum;
            }
            else if(type== CostType.Rage) {
                rageCost.num += costNum;
            }

            return this;
        }
        
        public bool CouldCharacterCost(BattleManager manager, Character user) {
            if(user.Mana< manaCost.num) {
                return false;
            }
            if(user.Energy< energyCost.num) {
                return false;
            }
            if(user.Rage< rageCost.num) {
                return false;
            }
            if(user.Health< healthCost.num) {
                return false;
            }
            return true;
        }

        public void Cost(BattleManager manager, Character user) {
            user.Mana -= manaCost.num;
            user.Energy -= energyCost.num;
            user.Rage -= rageCost.num;
            user.Health -= healthCost.num;
        }
    }

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
        Rage
    }
}