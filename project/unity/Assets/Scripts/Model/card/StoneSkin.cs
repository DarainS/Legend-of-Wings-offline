using System;
using System.Collections.Generic;


using Model;
using Model.damage;


class StoneSkin : Card {

    public override void playEffect(Character targer) {
        CardAction<Damage, Damage> cardAction = new CardAction<Damage, Damage>(10,
            damage => {
                damage.Num = damage.Num - 2;
                return damage;
            });
        targer.BeforeDamage.Add(cardAction);
    }

}