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
using RNGuesser.Enums;

namespace RNGuesser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RNGame game;

        public MainWindow()
        {
            InitializeComponent();
            game = new RNGame(1, 100, 5);
            ResetGame();
        }

        private void ResetGame()
        {
            SetLblLow();
            SetLblHigh();
            SetLblAttempts();
            lblResult.Content = "Start playing!";
            btnRetry.Visibility = Visibility.Hidden;
            tbxInput.Visibility = Visibility.Visible;
        }

        private void SetLblLow()
        {
            string result = string.Empty;
            for (int n = 0; n < Math.Min(game.CurrentLow - game.Low, 3); n++)
            {
                result += $"{game.Low + n}, ";
            }

            result += $"...{game.CurrentLow} ->";
            lblLow.Content = result;
        }

        private void SetLblHigh()
        {
            string result = string.Empty;
            for (int n = 0; n < Math.Min(game.High - game.CurrentHigh, 3); n++)
            {
                result = $", {game.High - n}" + result;
            }

            result = $"<- {game.CurrentHigh}..." + result;

            lblHigh.Content = result;
        }

        private void SetLblAttempts()
        {
            lblAttempts.Content = $"{game.CurrentAttempts} / {game.MaxAttempts}";
        }

        private void TbxInput_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string input = tbxInput.Text;
                if (!int.TryParse(input, out int guess))
                {
                    lblResult.Content = "You need to enter a number!";
                }
                else
                {
                    GuessResult result = game.Play(guess);
                    SetLblAttempts();
                    switch (result)
                    {
                        case GuessResult.Equal:
                            lblResult.Content = "Victory!";
                            btnRetry.Visibility = Visibility.Visible;
                            break;
                        case GuessResult.Less:
                            lblResult.Content = $"The number is less than {guess}!";
                            SetLblHigh();
                            break;
                        case GuessResult.Greater:
                            lblResult.Content = $"The number is greater than {guess}!";
                            SetLblLow();
                            break;
                        case GuessResult.Loss:
                            lblResult.Content = $"You lose! The number was {game.GeneratedNumber}!";
                            btnRetry.Visibility = Visibility.Visible;
                            tbxInput.Visibility = Visibility.Hidden;
                            break;
                    }
                }

                tbxInput.Text = string.Empty;
            }
        }

        private void BtnRetry_OnClick(object sender, RoutedEventArgs e)
        {
            game.ResetGame();
            ResetGame();
        }
    }
}
