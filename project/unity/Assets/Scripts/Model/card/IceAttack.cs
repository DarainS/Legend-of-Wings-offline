﻿using System;
using Model;
using Model.damage;

    public class IceAttack : Card {
        private string name;

        public IceAttack() {
            
        }


        public void playEffect(Character target) {
            Damage damage = new Damage(2, DamageType.ICE);
            character.TakeDamage(damage);
        }
    }
