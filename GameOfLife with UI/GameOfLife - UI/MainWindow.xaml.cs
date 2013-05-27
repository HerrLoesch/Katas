using System.Globalization;
using System.Windows;

namespace GameOfLifeUI
{
    using GameEngine;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool[,] playGround;
        private Game _game;

        public MainWindow()
        {
            InitializeComponent();
            _game = new Game();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            int x, y;
            
            if (!int.TryParse(xTextBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out x))
            {
                MessageBox.Show("Dork X");
                return;
            }

            if (!int.TryParse(yTextBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out y))
            {
                MessageBox.Show("Dork Y");
                return;
            }

            if ((x <= 0 || x > 1000) || (y <= 0 || y > 1000))
            {
                MessageBox.Show("Falscher Wert");
            }


            playGround = new bool[x,y];

            // TODO: init
            playGround[3, 3] = true;
            playGround[4, 3] = true;
            playGround[2, 2] = true;
            playGround[4, 4] = true;
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (playGround != null)
            {
                playGround = _game.Play(playGround);
                this.gameCanvas.PlayNewRound(this.playGround);
            }
        }
    }
}
