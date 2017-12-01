using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.damage;

namespace Model.card
{
    class StoneSkin : Card
    {
        public override void playEffect(Character targer)
        {
            CardAction<Damage,Damage> cardAction=new CardAction<Damage, Damage>(10,
                damage => {
                     damage.Num = damage.Num - 2;
                    return damage;
                });
            targer.BeforeDamage.Add(cardAction);
        }
    }
}
