using System;

using Manager;

using Model;
using Model.card;
using Model.character;
using Model.damage;


public class IceAttack : Card {
    
    public IceAttack() {
        Cost.AddCost(CostType.Mana, 1);
        firstCooldown = 1;
        cooldownTime = 2;
        Name = "寒冰攻击";
        SimgleDesc = "对敌方造成3点寒冰伤害";
    }


    public override void PlayEffect(BattleManager manager, Character user) {
        Damage damage = new Damage(2, DamageType.Ice, character);
        var target = ChooseTarget(manager,user);
        target.TakeDamage(damage);
    }

}