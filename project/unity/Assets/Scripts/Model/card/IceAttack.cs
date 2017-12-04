using System;
using Model;
using Model.character;
using Model.damage;

    public class IceAttack : Card {
        
        public IceAttack(Character c) {
            Name = "寒冰攻击";
            character = c;
        }

        public override void playEffect(Character target) {
            Damage damage = new Damage(2, DamageType.Ice);
            var t = character;
            if(t as Hero) {
                var h = (Hero) t;
                h.TakeDamage(damage);
            }
            else if(target) {
                
            }
            
        }


    }
