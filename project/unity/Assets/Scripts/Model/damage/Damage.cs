using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace Model.damage {

    public class Damage {

        private DamageType Type { get; set; }

        public int Num { get; set; }

        public Character Source { get; set; }

        public Damage(int num, Character source) {
            Num = num;
            Type = DamageType.Physical;
            Source = source;
        }

        public Damage(int num, DamageType type, Character source) {
            Num = num;
            Type = type;
            Source = source;
        }

    }

}