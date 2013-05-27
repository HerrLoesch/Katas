using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfLife_Primitives
{
    using GameEngine;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game gameEngine;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            this.gameEngine = new Game();

            var matrix = new bool[5,5];
            matrix[3, 3] = true;
            matrix[3, 2] = true;
            matrix[2, 1] = true;
            
            this.horst.GameMatrix = matrix;
            this.horst.InitCanvas();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            this.horst.GameMatrix = this.gameEngine.Play(this.horst.GameMatrix);
            this.horst.RefreshCanvas();
        }
    }
}
