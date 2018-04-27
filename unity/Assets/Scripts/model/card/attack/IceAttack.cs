using battle;

using model.character;
using model.damage;


namespace model.card.attack {

    public class IceAttack : Card {

        public IceAttack() {
            Cost.AddCost(ResourceType.Major);
            cooldownTime = 2;
            Name = "寒冰攻击";
            SimgleDesc = "对敌方造成1点物理伤害，迟缓*1，然后获得1点能量";
        }


        public override void PlayEffect(BattleManager manager, Character user) {
            Damage damage = new Damage(1, DamageType.Physical, character);
            var target = ChooseTarget(manager, user);
            target.TakeDamage(damage);
            user.Energy += 1;
        }
    }
}