using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing.Imaging;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WMPLib;
namespace Blackjack
{
    /// <summary>
    /// Interaction logic for start.xaml
    /// </summary>
    public partial class start : Window
    {
        public string name;
        public string source;
        public int minBet;
        public start()
        {
            InitializeComponent();
            txtBet.IsReadOnly = true;
            Unknown_Player();
        }

        private void Unknown_Player()
        {
            Image x = new Image();
            x.Height = canvasPic.Height;
            x.Width = canvasPic.Width;
            x.Source = new BitmapImage(new Uri("pack://application:,,,/Blackjack;component/Resources/unknownPlayer.jpg", UriKind.Absolute));
            canvasPic.Children.Add(x);
            source = "pack://application:,,,/Blackjack;component/Resources/unknownPlayer.jpg";
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                System.Windows.MessageBox.Show("Enter a Name", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                name = txtName.Text;
                this.Close();
            }
        }

        private void btnFileDialog_Click(object sender, RoutedEventArgs e)
        {
            var imageTypes = ImageCodecInfo.GetImageEncoders();
            var filter = "Image Files|";
            foreach (var imageFormat in imageTypes)
            {
                filter += imageFormat.FilenameExtension + ";";
            }


            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Select a Photo";
            file.Filter = filter;
            file.ShowDialog();
            source = file.FileName;
            try
            {
                canvasPic.Children.RemoveAt(0);
                Image i = new Image();
                i.Source = new BitmapImage(new Uri(source));
                i.Width = canvasPic.Width;
                i.Height = canvasPic.Height;
                canvasPic.Children.Add(i);
            }
            catch
            {
                System.Windows.MessageBox.Show("Unable to use image.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void sliderMinBet_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            minBet = Convert.ToInt32(sliderMinBet.Value);
            txtBet.Text = "$" + minBet.ToString();
      
        }
    }
}
