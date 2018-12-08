using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Blackjack
{
	public class Deck
	{
        internal List<Card> theDeck = new List<Card>(52);
        internal string[] Faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        internal string[] Suits = { "Clubs", "Diamonds", "Spades", "Hearts" };
    }
}
