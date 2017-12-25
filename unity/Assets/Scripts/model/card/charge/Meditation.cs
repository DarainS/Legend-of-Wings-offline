using battle;

using model.character;


namespace model.card.charge {

    public class Meditation : Card {

        public Meditation() {
            FirstCooldown = 2;
            CooldownTime = 3;
            CardType = CardType.Charge;
            CardProperty = CardProperty.Pneuma;
            Name = "冥想";
            SimgleDesc = "获得2点法力";
        }

        public override void PlayEffect(BattleManager manager, Character user) {
            user.Mana += 2;
        }

    }

}