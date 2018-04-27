using System;
using System.Collections;
using System.Collections.Generic;

using battle;

using model.character;


namespace model.card {

    public class ResourceAction {

        public ResourceType type { get; set; }
        public int num { get; set; }

        public ResourceAction(ResourceType type) {
            this.type = type;
            num = 0;
        }

        public ResourceAction(ResourceType type, int costNum) {
            this.type = type;
            num = costNum;
        }

    }

    public enum ResourceType {

        Health,
        Mana,
        Energy,
        Rage,
        Major,
        Minor

    }

    public class CardCost {

        public Dictionary<ResourceType,ResourceAction> costTable = new Dictionary<ResourceType,ResourceAction>(10);

        public CardCost() {
            foreach(ResourceType type in Enum.GetValues(typeof(ResourceType))) {
                costTable.Add(type, new ResourceAction(type));
            }
        }

        public CardCost AddCost(ResourceType type, int costNum = 1) {
            ResourceAction resourceAction = (ResourceAction) costTable[type];
            resourceAction.num += costNum;
            return this;
        }

        public bool CouldCharacterCost(BattleManager manager, Character user) {
            foreach(ResourceAction cost in costTable.Values) {
                if(user.GetResourceNum(cost.type)<cost.num) {
                    return false;
                }
            }
            return true;
        }

        public void Cost(BattleManager manager, Character user) {
            foreach(var cost in costTable.Values) {
                user.SetResourceNum(cost.type,user.GetResourceNum(cost.type)-cost.num);
            }
        }

    }

}