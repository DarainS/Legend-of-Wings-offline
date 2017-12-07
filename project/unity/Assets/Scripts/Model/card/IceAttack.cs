using System;

using Manager;

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

    public Character ChooseTarget(BattleManager manager, Character user) {
        if(user as Hero) {
            return manager.Monster;
        }

        if(user as Monster) {
            return manager.Hero;
        }

        throw new Exception();
    }

    public override void PlayEffect(BattleManager manager, Character user) {
        Damage damage = new Damage(2, DamageType.Ice, character);
        var target = ChooseTarget(manager,user);
        target.TakeDamage(damage);
    }

}