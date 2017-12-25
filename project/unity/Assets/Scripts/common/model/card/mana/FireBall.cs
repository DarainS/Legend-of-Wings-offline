using Manager;

using Model.damage;


namespace Model.card.mana {

    public class FireBall : Card{

        public FireBall( ) {
            Cost = Cost.AddCost(CostType.Mana, 4);
            FirstCooldown = 3;
            CooldownTime = 5;
            CardType = CardType.Spell;
            CardProperty = CardProperty.Fire;
            Name = "火球术";
            SimgleDesc = "造成8点火属性伤害";
        }

        public override void PlayEffect(BattleManager manager, Character user) {
            var target = ChooseTarget(manager, user);
            var d = new Damage( 8, DamageType.Fire, user);
            target.TakeDamage(d);
        }

    }

}