
using manager.battle;

using model.character;


namespace model.card.charge {

    public class Meditation : Card {

        public Meditation() {
            CooldownTime = 3;
            CardType = CardType.Charge;
            CardProperty = CardProperty.Pneuma;
            Name = "冥想";
            SimgleDesc = "获得1点能量";
            Cost = new CardCost().AddCost(ResourceType.Minor);
        }

        public override void PlayEffect(BattleManager manager, Character user) {
            user.Energy += 1;
        }

    }

}