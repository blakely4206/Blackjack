using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Blackjack
{
    class GameAnimations
    {
        internal void Bet_Animation(Label lbl)
        {
            ColorAnimation ca = new ColorAnimation(Colors.Black, new Duration(TimeSpan.FromSeconds(1)));
            lbl.Foreground = new SolidColorBrush(Colors.Red);
            lbl.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }

        internal void win_Animation(Label lbl)
        {
            ColorAnimation ca = new ColorAnimation(Colors.Black, new Duration(TimeSpan.FromSeconds(1)));
            lbl.Foreground = new SolidColorBrush(Colors.LimeGreen);
            lbl.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }
    }
}
