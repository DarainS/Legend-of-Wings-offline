using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.damage {
    public class Damage {

        private DamageType Type;

        public int Num { get; set; }

        public Damage(int num) {
            this.Num = num;
            this.Type = DamageType.Physical;
        }

        public Damage(int num, DamageType type) {
            this.Num = num;
            this.Type = type;
        }
    }
}