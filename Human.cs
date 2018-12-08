using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
	public class Human : Player
	{
        public int money =  1000;

        public void Bet(int bet)
        {
            money -= bet;
        }

        public void Collect_Chips(int bet)
        {
            money += bet;
        }
        public string name { get; set; }
	}
}
