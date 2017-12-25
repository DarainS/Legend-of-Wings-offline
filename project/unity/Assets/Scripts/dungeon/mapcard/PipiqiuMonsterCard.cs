using System.Collections.Generic;

using model.card;
using model.card.attack;


namespace dungeon.mapcard {

    public class PipiqiuMonsterCard : BaseMonsterMapCard {

        public List<Card> deck = new List<Card>();
        
        private void initData() {
            _name = "皮皮丘";
            deck.Add(new PhysicialAttack());
            deck.Add(new PhysicialAttack());
            deck.Add(new PhysicialAttack());
            deck.Add(new PhysicialAttack());
            deck.Add(new PhysicialAttack());
        }
        
        private void Start() {
            initData();
            initUI();
        }

        private void initUI() {
            nameText.text = _name;
        }

    }

}