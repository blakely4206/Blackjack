using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
	public class Dealer : Player
	{
        internal void Shuffle_Deck(Deck d)
        {
            foreach (string face in d.Faces)
            {
                foreach (string suit in d.Suits)
                {
                    Card c = new Card(suit, face);
                    d.theDeck.Add(c);
                }
            }
        }

        public void PlayGame(Deck d, Human h)
        {
            if (theHand.Value <= 16)
            {
                theHand.theHand.Add(DealCard(d, h.theHand));
            }
        }

        public string DetermineIfHumanIsWinner(Human h, Dealer d)
        {
            if (h.theHand.Value > 21)
            {
                if (d.theHand.Value > 21)
                {
                    return "push";
                }

                return "dealer";

            }
            else
            {
                if (d.theHand.Value> 21)
                {
                    return "human";
                }
                if (h.theHand.Value == d.theHand.Value)
                {
                    return "push";
                }
                else if (h.theHand.Value > d.theHand.Value)
                {
                    return "human";
                }
                return "dealer";
            }
        }

        public bool DetermineBust(Hand hand)
        {
            if (hand.Value > 21)
            {
                return true;
            }

            return false;
        }

        public void Pick_Up(Human h)
        {
            h.theHand.theHand.Clear();
            theHand.theHand.Clear();
        }

        internal Card DealCard (Deck d, Hand humanHand)
        {
            bool notRepeat = false;
            int i = 0;

            while (notRepeat == false)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                i = r.Next(0, 52);
                if (!humanHand.theHand.Contains(d.theDeck[i]) && !theHand.theHand.Contains(d.theDeck[i]))
                {
                    break;
                }
            }
            return d.theDeck[i];
        }
    }
}
