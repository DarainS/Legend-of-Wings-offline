﻿using battle;

using model.character;
using model.damage;


namespace model.card.attack {

    public class PhysicialAttack : Card {

        public PhysicialAttack() {
            Cost.AddCost(ResourceType.Major);
            cooldownTime = 2;
            Name = "攻击";
            SimgleDesc = "对敌方造成2点伤害";
        }


        public override void PlayEffect(BattleManager manager, Character user) {
            Damage damage = new Damage(2, DamageType.Physical, user);
            var target = ChooseTarget(manager, user);
            target.TakeDamage(damage);
        }
    }
}