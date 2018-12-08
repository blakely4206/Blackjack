using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class CardHandler
    {/// <summary>
     /// Puts the humans cards on the screen.</summary>
     /// <param name="h">Instance of Human Player</param>
     /// <param name="canvasWidth">Width of the Canvas</param>
     /// <param name="height">Height of Card and Canvas</param>
     /// <param name="cardWidth">Width of Card</param>
     /// <param name="left">Set Left</param>
     /// <param name="parent">Parent Canvas for Cards</param>
     /// <param name="space_between_cards">Distance between Cards</param>
     internal void Do_Cards(Human h, Canvas parent, double canvasWidth, double height, double cardWidth, int left, int space_between_cards)
        {
            foreach (Card c in h.theHand.theHand)
            {
                Canvas child = new Canvas();
                child.Width = canvasWidth;
                child.Height = height;
                Canvas.SetLeft(child, left);
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(@"pack://application:,,,/Blackjack;component/Cards/" + c.Face + "Of" + c.Suit + ".bmp", UriKind.Absolute));
                image.Width = cardWidth;
                image.Height = height;
                child.Children.Add(image);
                parent.Children.Add(child);
                left += space_between_cards;
            }
        }

        internal void Do_Cards(Dealer dealer, Canvas parent, double canvasWidth, double height, double cardWidth, int left, int space_between_cards, bool gameisover)
        {
            int i = 0;
            if (gameisover == false)
            {
                foreach (Card c in dealer.theHand.theHand)
                {
                    Canvas child = new Canvas();
                    child.Width = canvasWidth;
                    child.Height = height;
                    Canvas.SetLeft(child, left);
                    Image image = new Image();

                    if (i != 0)
                    {
                        image.Source = new BitmapImage(new Uri(@"pack://application:,,,/Blackjack;component/Cards/" + c.Face + "Of" + c.Suit + ".bmp", UriKind.Absolute));
                    }
                    else if (i == 0)
                    {
                        image.Source = new BitmapImage(new Uri(@"pack://application:,,,/Blackjack;component/Cards/back.jpg", UriKind.Absolute));
                    }

                    image.Width = cardWidth;
                    image.Height = height;
                    child.Children.Add(image);
                    parent.Children.Add(child);
                    left += 15;
                    i++;
                }
            }
            else if (gameisover == true)
            {
                foreach (Card c in dealer.theHand.theHand)
                {
                    Canvas canny = new Canvas();
                    canny.Width = canvasWidth;
                    canny.Height = height;
                    Canvas.SetLeft(canny, left);
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri(@"pack://application:,,,/Blackjack;component/Cards/" + c.Face + "Of" + c.Suit + ".bmp", UriKind.Absolute));
                    image.Width = cardWidth;
                    image.Height = height;
                    canny.Children.Add(image);
                    parent.Children.Add(canny);
                    left += 50;
                    i++;
                }
            }
        }

        internal void ClearCards(Canvas can)
        {
            if (can.Children.Count > 0)
            {
                can.Children.RemoveRange(0, can.Children.Count);
            }
        }
    }
}
