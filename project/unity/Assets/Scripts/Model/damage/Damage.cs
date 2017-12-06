using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Model.damage {

    public class Damage {

        private DamageType Type { get; set; }

        public int Num { get; set; }

        public Damage(int num) {
            Num = num;
            Type = DamageType.Physical;
        }

        public Damage(int num, DamageType type) {
            Num = num;
            Type = type;
        }

    }

}