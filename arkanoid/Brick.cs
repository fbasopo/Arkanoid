using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace arkanoid
{
    class Brick
    {
        Image img;
        private string Location = "pack://application:,,,/";

        public void brick_collision(Point p)
        {

        }

        public  Brick(Canvas c, Point position)
        {
            img = new Image();
            img.Source = new BitmapImage(new System.Uri(Location + "Brick 1.jpg"));
            img.Width = 35;
            Canvas.SetTop(img, position.Y);
            Canvas.SetLeft(img, position.X);
            c.Children.Add(img);
        }
    }
}
    

