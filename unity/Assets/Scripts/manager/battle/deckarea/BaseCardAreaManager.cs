using System.Collections.Generic;

using model.card;

using UnityEngine;


namespace manager.battle.deckarea {

    public abstract class BaseCardAreaManager : MonoBehaviour {

        public List<UCard> cards = new List<UCard>(30);

        public abstract void AddCard(UCard card);

        public abstract void RemoveCard(UCard card);

        public abstract void ChangeAreaView();

    }

}