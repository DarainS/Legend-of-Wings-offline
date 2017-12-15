using System;
using System.Collections.Generic;

using Manager;

using Model;
using Model.damage;


public class StoneSkin : Card {

    public StoneSkin( ) {
        Name = "石化皮肤";
        SimgleDesc = "直到下回合开始，获得2点伤害减免";
        cooldownTime = 3;
        firstCooldown = 2;
    }


    public override void PlayEffect(BattleManager manager, Character user) {
        var cardAction = new CardAction<Damage, Damage>(10,
            damage => {
                damage.Num = damage.Num - 2;
                return damage;
            });
        if(!user.BeforeDamage.Contains(cardAction)) {
            user.BeforeDamage.Add(cardAction);
        }
        
    }

}