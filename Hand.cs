using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Blackjack
{
	public class Hand
	{
        public List<Card> theHand = new List<Card>();

		public int Value
		{
			get
			{
                int x = 0;
                
				foreach(Card c in theHand)
                {
                    if (c.Face == "Ace")
                    {
                        if((x+11) > 21)
                        {
                            x += 1;
                        }
                        else
                        {
                            x += 11;
                        }
                    }
                    else
                    {
                        x += c.ReturnValue(c.Face);
                    }
                }
                return x;
			}
		}
	}
}
