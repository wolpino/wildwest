using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldScorpion
{
    class Card
    {
        public static string[] cardType = {"scorpion", "gold"};
        public string cardName;
        public Card(int val){
            cardName = cardType[val];
        } 
    }
    class Player
    {
        public List<Card> hand;
        public List<Card> cards_avail;
        public Stack<Card> pile; 
        public int points;
        

        public Player()
        {
            cards_avail.Add(new Card(0));
            cards_avail.AddRange(Enumerable.Repeat(new Card(1),3));
            Hand();
            pile = new Stack<Card>();
            points=0;
        }

        public void Hand()
        {
            hand = new List<Card>(cards_avail);
        }

        public void playCard(int num)
        {
            pile.Push(hand[num]);
            hand.RemoveAt(num);
        }
    }
}
