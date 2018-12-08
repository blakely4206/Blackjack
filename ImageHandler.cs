using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace Blackjack
{
    class ImageHandler
    {
        internal void FillEllipseWithImage(string source, Ellipse ellipsey)
        {
            try
            {
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri(source));
                ellipsey.Fill = myBrush;
            }
            catch
            { }
        }

        internal void SetImageSource(Image i, string Source)
        {
            i.Source = new BitmapImage(new Uri(Source, UriKind.Absolute));
        }
    }
}
