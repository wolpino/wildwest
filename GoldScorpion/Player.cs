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
            pile.Push(hand[num]);
            hand.RemoveAt(num);
        }

        public string flip(int num)
        // flips cards. For each card indicated in the bid, if the card is within the pile count, we check the value. If the value is scorpion, the bid is over, player loses. If our count to flip ends within our pile with no scorpions, the player wins.  Otherwise, if we run out of cards, we move to the next deck. 
        {
            for(int i=0;i<num;i++)
            {
                if(i<pile.Count)
                {
                    if(pile.Pop().cardName == "scorpion")
                    {
                        return "Sorry! You lose!";
                    }
                    else if (i==num-1)
                    {
                        return "Yay! You win this round";
                    }
                }
                else 
                {
                    return "Continue with someone else's pile...";
                }
            }
            return "Yay! You win this round";
        }


    }
}
