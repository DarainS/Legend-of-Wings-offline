using System.Collections.Generic;

using model.card;


namespace data {

    public class HeroData {

        public int CurrentHelth { get; set; }
        public int MaxHelth { get; set; }

        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }

        public readonly List<Card> deck = new List<Card>(50);

    }

}