using Manager;


namespace Model.card.charge {

    public class Meditation : Card {

        public Meditation( ) {
            FirstCooldown = 2;
            CooldownTime = 3;
            CardType = CardType.Charge;
            CardProperty = CardProperty.Pneuma;
            Name = "冥想";
            SimgleDesc = "获得3点法力";
        }

        public override void PlayEffect(BattleManager manager, Character user) {
            user.Mana += 3;
        }

    }

}