using System;

using Manager;

using Model;
using Model.character;
using Model.damage;


public class IceAttack : Card {


    public IceAttack(Character c) {
        Name = "寒冰攻击";
        SimgleDesc = "对敌方造成3点寒冰伤害";
        character = c;
        cooldownTime = 2;
        firstCooldown = 1;
    }


    public override void PlayEffect(BattleManager manager, Character user) {
        
        Damage damage = new Damage(2, DamageType.Ice, character);
        var target = ChooseTarget(manager,user);
        target.TakeDamage(damage);
    }

}