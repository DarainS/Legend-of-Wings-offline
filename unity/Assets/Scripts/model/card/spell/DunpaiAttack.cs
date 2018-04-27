using battle;

using model.character;
using model.damage;


namespace model.card.spell {

    public class DunpaiAttack : Card {

        public DunpaiAttack() {
            FirstCooldown = 3;
            CooldownTime = 5;
            CardType = CardType.Spell;
            CardProperty = CardProperty.Physical;
            Cost=new CardCost().AddCost(ResourceType.Major).AddCost(ResourceType.Energy, 1);
            Name = "盾牌打击";
            SimgleDesc = "造成2点伤害，你每有3点护甲，便额外造成1点伤害";
        }

        public override void PlayEffect(BattleManager manager, Character user) {
            var target = ChooseTarget(manager, user);
            var d = new Damage(2, DamageType.Physical, user);
            var plus = user.armor / 3;
            d.Num += plus;
            target.TakeDamage(d);
        }

    }

}