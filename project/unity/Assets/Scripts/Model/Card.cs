using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;


namespace Model {
    public abstract class Card : MonoBehaviour {
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


        public abstract void playEffect(Character target);


        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {
        }
    }
}