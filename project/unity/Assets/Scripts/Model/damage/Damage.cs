﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model.damage
{
    class Damage
    {
        int num;
        public DamageType type;

        public int Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }
        }

        public Damage(int num)
        {
            this.num = num;
            this.type = DamageType.PHYSICAL;
        }
        public Damage(int num,DamageType type)
        {
            this.num = num;
            this.type = type;
        }

    }
}
