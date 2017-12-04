using System;
using System.Collections.Generic;


using Model;
using Model.damage;


public class StoneSkin : Card {

    public StoneSkin(Character c) {
        Name = "石化皮肤";
        character = c;
    }

    public override void playEffect(Character target) {
        var cardAction = new CardAction<Damage, Damage>(10,
            damage => {
                damage.Num = damage.Num - 2;
                return damage;
            });
        if(!character.BeforeDamage.Contains(cardAction)) {
            character.BeforeDamage.Add(cardAction);
        }
    }


}