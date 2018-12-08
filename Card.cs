using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
	public class Card
	{ 
        public string  Suit;
        public string  Face;

        public Card(string S, string F)
        {
            Suit = S;
            Face = F;
        }

        public int ReturnValue(string Face)
        {
            if (Face == "2")
            {
                return 2;
            }
            if (Face == "3")
            {
                return 3;
            }
            if (Face == "4")
            {
                return 4;
            }
            if (Face == "5")
            {
                return 5;
            }
            if (Face == "6")
            {
                return 6;
            }
            if (Face == "7")
            {
                return 7;
            }
            if (Face == "8")
            {
                return 8;
            }
            if (Face == "9")
            {
                return 9;
            }

            if (Face == "10" || Face == "Jack" || Face == "Queen" || Face == "King")
            {
                return 10;
            }

            else if (Face == "A")
            {
                return 11;
            }
            return 0;
        }
	}
}
