using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldScorpion
{
    public class Card
    {
        public static string[] cardType = {"scorpion", "gold"};
        public string cardName;
        public Card(int val){
            cardName = cardType[val];
        } 
    }
    public class Player
    {
        public static Random rand = new Random();
        public List<Card> hand;
        public List<Card> cards_avail = new List<Card>();
        public Stack<Card> pile; 
        public int points;
        public string name; 
        

        public Player(string playerName)
        {
            cards_avail.Add(new Card(0));
            cards_avail.AddRange(Enumerable.Repeat(new Card(1),3));
            Hand();
            pile = new Stack<Card>();
            points=0;
            name = playerName;
        }

        public void Hand()
        {
            hand = new List<Card>(cards_avail);
        }

        public void playCard(int num)
        // player adds a card from their hand to the pile
        {
            Card card = hand[num];
            pile.Push(card);
            hand.RemoveAt(num);
        }

        public int flip(int num)
        // flips cards. For each card indicated in the bid, if the card is within the pile count, we check the value. If the value is scorpion, the bid is over, player loses. If our count to flip ends within our pile with no scorpions, the player wins.  Otherwise, if we run out of cards, we move to the next deck. 
        // -1 = Lose; 0 = Win; # = Recall flip for another player using this number
        {
            for(int i=0;i<num;i++)
            {
                while(pile.Count>0)
                {
                    string currCard = pile.Pop().cardName;
                    if(currCard == "scorpion")
                    {
                        return -1;
                    }
                    else if (i==num-1)
                    {
                        return 0;
                    }
                    i++;
                }
                if(i>=pile.Count)
                {
                    return (num-i);
                }
            }
            return 0;
        }

        public void Discard()
        {
            cards_avail.RemoveAt(rand.Next(cards_avail.Count));
        }


    }
}
