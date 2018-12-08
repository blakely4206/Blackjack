using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Blackjack
{
    public partial class MainWindow : Window
    {

        GameAnimations gA = new GameAnimations();
        SoundHandler sH = new SoundHandler();
        CardHandler cH = new CardHandler();
        LabelHandler lH = new LabelHandler();
        Game game = new Game();
        ImageHandler iH = new ImageHandler();

        public Human h = new Human();
        public Dealer deal = new Dealer();
        public Deck deck = new Deck();

        string source;

        List<Label> lblsWinners = new List<Label>();
        start s = new start();

        public MainWindow()
        {
            sH.Run_Music();

            s.ShowDialog();

            InitializeComponent();

            lblsWinners.Add(lblPlayer);
            lblsWinners.Add(lblDealer);
            lblsWinners.Add(lblPush);

            lH.Hide_Labels(lblsWinners);

            Start_Items(s);
            txtBoxBet.IsReadOnly = true;
        }

        private void Start_Items(start s)
        {
            h.name = s.name;
            source = s.source;
            txtBoxBet.Text = s.minBet.ToString();
            slider.Minimum = s.minBet;
            slider.Maximum = h.money;
            iH.FillEllipseWithImage(source, ellipsey);
            lH.Set_Labels(h, lblPlayerName, lblCash, lblValue);
        }

        private void Restart_Items(start s)
        {
            h.name = s.name;
            source = s.source;
            txtBoxBet.Text = s.minBet.ToString();
            slider.Minimum = s.minBet;
            slider.Maximum = h.money;
            iH.FillEllipseWithImage(source, ellipsey);
            lH.Set_Labels(h, lblPlayerName, lblCash, lblValue);
            h.money = 1000;
            cH.ClearCards(canvasHumParent);
            cH.ClearCards(canvasDealerParent);
            lH.Hide_Labels(lblsWinners);
            lH.Update_HandValueLabel(lblValue, h.theHand.Value);
            lH.Update_lblCash(lblCash, h.money);
            Button_Enabler(true, false, false, true);
            txtBoxBet.Text = s.minBet.ToString();
            slider.Value = s.minBet;
            slider.Maximum = h.money;
            
        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            h.theHand.theHand.Add(deal.DealCard(deck, h.theHand));
            lH.Update_HandValueLabel(lblValue, h.theHand.Value);
            cH.Do_Cards(h, canvasHumParent, 499, 100, 87, 100, 15);

            if (deal.DetermineBust(h.theHand) == true)
            {
                lblValue.Content = "Bust";
                game.winner = game.Dealers_Turn(game.winner, deck, cH, deal, h);
                cH.Do_Cards(deal, canvasDealerParent, 499, 100, 87, 330, 15, true);
                Game_Over();
            }
        }

        private void btnStand_Click(object sender, RoutedEventArgs e)
        {
            game.winner = game.Dealers_Turn(game.winner, deck, cH, deal, h);

            cH.Do_Cards(deal, canvasDealerParent, 499, 100, 87, 330, 15, true);
            Game_Over();
        }

        public void Game_Over()
        {
            if (game.winner == "dealer")
            {
                lH.Fire_Animation_Labels(lblDealer);
                sH.Play_Bust_Sound();
            }

            if (game.winner == "human")
            {
                gA.win_Animation(lblCash);
                lH.Fire_Animation_Labels(lblPlayer);
                h.Collect_Chips(2 * Convert.ToUInt16(slider.Value));
            }

            else if (game.winner == "push")
            {
                lH.Fire_Animation_Labels(lblPush);
                h.Collect_Chips(Convert.ToUInt16(slider.Value));
            }

            lH.Update_HandValueLabel(lblValue, h.theHand.Value);
            lH.Update_lblCash(lblCash, h.money);

            deal.Pick_Up(h);

            Set_Slider_Max(h.money);

            Button_Enabler(true, false, false, true);

            if (game.Game_Lost(h) == true)
            {
                Button_Enabler(false, false, false, false);
                MessageBoxResult result = MessageBox.Show("New Game?", "Game Over!!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                
                if(result == MessageBoxResult.Yes)
                {
                    start s = new start();
                    s.ShowDialog();
                    Restart_Items(s);
                }
                else
                {
                    this.Close();
                }

            }
        }

        private void Set_Slider_Max(int money)
        {
            slider.Maximum = money;
        }

        private void btnBet_Click(object sender, RoutedEventArgs e)
        {
            cH.ClearCards(canvasDealerParent);
            cH.ClearCards(canvasHumParent);
            lH.Set_Labels(h, lblPlayerName, lblCash, lblValue);
            lH.Hide_Labels(lblsWinners);

            sH.Play_Shuffle();
            h.Bet(Convert.ToUInt16(slider.Value));
            gA.Bet_Animation(lblCash);
            lH.Update_lblCash(lblCash, h.money);

            game.Run_Game(h, deal, deck);

            cH.Do_Cards(h, canvasHumParent, 499, 100, 87, 100, 15);
            cH.Do_Cards(deal, canvasDealerParent, 499, 100, 87, 330, 15, false);

            lH.Update_HandValueLabel(lblValue, h.theHand.Value);
            Button_Enabler(false, true, true, false);
        }

        internal void Button_Enabler(bool Bet, bool Hit, bool Stand, bool Slider)
        {
            btnBet.IsEnabled = Bet;
            btnHit.IsEnabled = Hit;
            btnStand.IsEnabled = Stand;
            slider.IsEnabled = Slider;
        }

        private void imageSpeaker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string source;
            if (sH.isMute == false)
            {
                sH.Mute();
                source = "pack://application:,,,/Blackjack;component/Resources/speakerOff.bmp";
                iH.SetImageSource(imageSpeaker, source);
                sH.isMute = true;
            }
            else
            {
                sH.Mute();
                source = "pack://application:,,,/Blackjack;component/Resources/speakerOn.bmp";
                iH.SetImageSource(imageSpeaker, source);
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtBoxBet.Text = "$" + Convert.ToInt16(slider.Value).ToString();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvasBackground.Height = this.Height;
            canvasBackground.Width = this.Width;
        }
    }
}

