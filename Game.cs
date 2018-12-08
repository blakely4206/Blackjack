using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace Blackjack
{
    class Game
    {
        public string winner { get; set; }
        internal void Run_Game(Human h, Dealer deal, Deck deck)
        {
            deal.Shuffle_Deck(deck);

            h.theHand.theHand.Add(deal.DealCard(deck, h.theHand));
            h.theHand.theHand.Add(deal.DealCard(deck, h.theHand));

            deal.theHand.theHand.Add(deal.DealCard(deck, h.theHand));
            deal.theHand.theHand.Add(deal.DealCard(deck, h.theHand));
        }

        internal string Dealers_Turn(string winner, Deck deck, CardHandler cH, Dealer deal, Human h)
        {
            while (deal.theHand.Value < 16)
            {
                deal.PlayGame(deck, h);
            }

            winner = deal.DetermineIfHumanIsWinner(h, deal);

            return winner;
        }

        internal bool Game_Lost(Human h)
        {
            if (h.money <= 0)
            {
                return true;
            }
            else return false;
        }
    }
}
