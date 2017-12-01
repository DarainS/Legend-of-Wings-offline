using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Assets.Scripts.Model.card
{
    class StoneSkin : Card
    {

        public override void playEffect()
        {
            character.BeforeDamage.AddLast(new);
        }
    }
}
