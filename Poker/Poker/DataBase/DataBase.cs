namespace Poker.DataBase
{
    using Enumerations;
    using Interfacees;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Table;

    public class DataBase : IDatabase
    {
        private readonly IList<ICard> deck;

        public DataBase()
        {
            this.deck = new List<ICard>();
            this.InitializeDeck();
        }

        public IEnumerable<ICard> Deck
        {
            get { return this.deck; }
        }

        //Trying to initialize the full Deck of cards. Not sure if this is the right way. Ask.
        private void InitializeDeck()
        {
            var values = Enum.GetValues(typeof(CardSuit));
            var valuesTwo = Enum.GetValues(typeof(CardRank));

            foreach (var element in values)
            {
                foreach (var element2 in valuesTwo)
                {
                    string cardPath = "..\\..\\Resources\\Cards\\" + (CardRank)element2 + (CardSuit)element + ".png";
                    Image cardImage = Image.FromFile(cardPath);

                    this.deck.Add(new Card((CardSuit)element, (CardRank)element2, cardImage));
                }
            }
        }
    }
}