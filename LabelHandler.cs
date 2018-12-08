using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Blackjack
{
    class LabelHandler
    {
        internal void Hide_Labels(List<Label> lblsWinners)
        {
            foreach (Label lbl in lblsWinners)
            {
                lbl.Opacity = 0;
            }
        }
        internal void Update_lblCash(Label lbl, int cash)
        {
            lbl.Content = "$" + cash.ToString();
        }

        internal void Fire_Animation_Labels(Label l)
        {
            l.IsEnabled = false;
            l.IsEnabled = true;
        }

        internal void Update_HandValueLabel(Label l, int value)
        {
            if (value > 21)
            {
                l.Foreground = new LinearGradientBrush(Colors.MistyRose, Colors.Red, 45);
            }
            else
            {
                l.Content = value.ToString();
            }
        }
        internal void Set_Labels(Human h, Label PlayerName, Label PlayerCash, Label ValueOfPlayersHand)
        {
            PlayerName.Content = h.name;
            PlayerCash.Content = "$" + h.money.ToString();
            ValueOfPlayersHand.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
