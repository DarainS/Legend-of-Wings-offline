using System;
using Model;
using Model.damage;

namespace Model {
    public class IceAttack : Card {
        private string name;

        public IceAttack() {
            
        }


        public override void playEffect(Character target) {
            Damage damage = new Damage(2, DamageType.ICE);
            character.TakeDamage(damage);
        }
    }
}