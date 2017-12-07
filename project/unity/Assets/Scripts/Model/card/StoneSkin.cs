﻿using System;
using System.Collections.Generic;

using Manager;

using Model;
using Model.damage;


public class StoneSkin : Card {

    public StoneSkin(Character c) {
        Name = "石化皮肤";
        character = c;
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