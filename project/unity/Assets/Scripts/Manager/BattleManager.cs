using System;

using Model;

using UnityEngine;


namespace Manager {

    public class BattleManager : MonoBehaviour {

        private Hero _hero;
        private HandsArea handsArea;

        public Hero Hero {
            get { return _hero; }
            set { _hero = value; }
        }

        void initHandsArea() {
            foreach(var card in _hero.Deck) {
                handsArea.AddCard(card);
                Console.WriteLine("load card: "+card.Name);
                
            }
        }

        void Start() {
            
            Hero = transform.GetComponentInChildren<Hero>();
            handsArea = transform.GetComponentInChildren<HandsArea>();

            initHandsArea();
        }
        
        

    }

}