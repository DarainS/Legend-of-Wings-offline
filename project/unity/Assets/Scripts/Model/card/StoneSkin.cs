using System;
using System.Collections.Generic;


using Model;
using Model.damage;


public class StoneSkin : Card {

    public StoneSkin(Character c ) {
        Name = "石化皮肤";
        character = c;
    }

    public override void playEffect(Character targer) {
        CardAction<Damage, Damage> cardAction = new CardAction<Damage, Damage>(10,
            damage => {
                damage.Num = damage.Num - 2;
                return damage;
            });
        targer.BeforeDamage.Add(cardAction);
    }

    public override bool isUseable() {
        return true;
    }

}