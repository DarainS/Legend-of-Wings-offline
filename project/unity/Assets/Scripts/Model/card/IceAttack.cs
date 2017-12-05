using System;

using Model;
using Model.character;
using Model.damage;


public class IceAttack : Card {

    public IceAttack(Character c) {
        Name = "寒冰攻击";
        character = c;
        cooldownTime = 2;
        firstCooldown = 1;
    }

    public override void PlayEffect(Character player = null, Character target = null) {
        Damage damage = new Damage(2, DamageType.Ice);
        var t = character;
        if(t as Hero) {
            var h = (Hero) t;
            h.TakeDamage(damage);
        }
        else if(target) {
        }
    }

}