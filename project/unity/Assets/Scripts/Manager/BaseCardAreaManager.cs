using System.Collections.Generic;

using Model;

using UnityEngine;


namespace Manager {

    public abstract class BaseCardAreaManager : MonoBehaviour {

        public List<UCard> cards = new List<UCard>(30);

        public abstract void AddCard(UCard card);

        public abstract void RemoveCard(UCard card);

    }

}