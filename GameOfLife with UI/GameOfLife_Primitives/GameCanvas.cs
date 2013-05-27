namespace GameOfLife_Primitives
{
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public class GameCanvas : UniformGrid
    {
        public bool[,] GameMatrix { get; set; }

        public void InitCanvas()
        {
            this.Children.Clear();

            for (var x = 0; x < GameMatrix.GetLength(0); x++)
            {
                for (var y = 0; y < GameMatrix.GetLength(1); y++)
                {
                    var myRect = new Rectangle
                    {
                        Fill = this.GameMatrix[x, y] ? Brushes.Wheat : Brushes.Violet
                    };

                    this.Children.Add(myRect);
                }
            }
        }

        public void RefreshCanvas()
        {
            var index = 0;

            for (var x = 0; x < GameMatrix.GetLength(0); x++)
            {
                for (var y = 0; y < GameMatrix.GetLength(1); y++)
                {
                    var myRect = (Rectangle)this.Children[index];
                    myRect.Fill = this.GameMatrix[x, y] ? Brushes.Wheat : Brushes.Violet;
                    index++;
                }
            }
        }
    }
}