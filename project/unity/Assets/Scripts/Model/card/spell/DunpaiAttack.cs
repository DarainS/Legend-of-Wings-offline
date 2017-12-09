using Manager;

using Model.damage;


namespace Model.card.spell {

    public class DunpaiAttack : Card {

        public DunpaiAttack(Character c) {
            character = c;

//            Cost = Cost.AddCost(CostType.Mana, 2);
            FirstCooldown = 3;
            CooldownTime = 5;
            CardType = CardType.Spell;
            CardProperty = CardProperty.Physical;
            Name = "盾牌打击";
            SimgleDesc = "造成2点伤害，你每有5点护甲，便额外造成1点伤害";
        }

        public override void PlayEffect(BattleManager manager, Character user) {
            var target = ChooseTarget(manager, user);
            var d = new Damage(2, DamageType.Physical, user);
            var plus = user.armor / 5;
            d.Num += plus;
            target.TakeDamage(d);
        }

    }

}