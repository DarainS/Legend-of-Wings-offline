using battle;

using model.card;
using model.character;
using model.damage;


namespace model.card.mana {

    public class FireBall : Card {

        public FireBall() {
            Cost = new CardCost().AddCost(ResourceType. Major).AddCost(ResourceType.Energy,2);
            FirstCooldown = 2;
            CooldownTime = 3;
            CardType = CardType.Spell;
            CardProperty = CardProperty.Fire;
            Name = "火球术";
            SimgleDesc = "造成4点魔法伤害，若目标已引燃，则额外造成1点魔法伤害";
        }

        public override void PlayEffect(BattleManager manager, Character user) {
            var target = ChooseTarget(manager, user);
            var d = new Damage(4, DamageType.Fire, user);
            target.TakeDamage(d);
        }

    }
}