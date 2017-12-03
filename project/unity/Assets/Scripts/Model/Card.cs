using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;


    public class Card {
        
        protected string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string SimgleDesc {
            get { return simgleDesc; }
            set { simgleDesc = value; }
        }

        protected string simgleDesc;

        public Character character;


        public void playEffect(Character target) {
            
        }


    }
