using System;
using Model;
using Model.damage;

    public class IceAttack : Card {
        
        public IceAttack(Character c) {
            Name = "寒冰攻击";
            character = c;
        }



        public override void playEffect(Character target) {
            Damage damage = new Damage(2, DamageType.ICE);
            character.TakeDamage(damage);
        }

        public override bool isUseable() {
            return true;
        }

    }
