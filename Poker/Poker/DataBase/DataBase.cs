using System.Collections.Generic;
using Poker.Interfacees;

namespace Poker.DataBase
{
    public class DataBase:IDatabase
    {
        public DataBase()
        {
            this.Deck = new List<ICard>();
            //this.InitializeCards();
        }

        public IList<ICard> Deck { get; set; }

        //Trying to initialize the full Deck of cards. Not sure if this is the right way. Ask.
        //public void InitializeCards()
        //{
        //    var values = Enum.GetValues(typeof(CardSuit));
        //    var valuesTwo = Enum.GetValues(typeof(CardRank));


        //    foreach (var element in values)
        //    {
        //        foreach (var element2 in valuesTwo)
        //        {
        //            Deck.Add(new Card((CardSuit)element, (CardRank)element2));
        //        }
        //    }
        //}   
    }
}