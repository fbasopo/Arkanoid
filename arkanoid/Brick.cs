using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace arkanoid
{
    class Brick
    {
        public int brick { get;  private set;}
        Image img;
        Canvas canvas;
       
        private string Location = "pack://application:,,,/";

        public  Brick(Canvas c, Point position)
        {
            this.canvas = c;
            img = new Image();
            img.Source = new BitmapImage(new System.Uri(Location + "Brick 1.jpg"));
            img.Width = 35;
            Canvas.SetTop(img, position.Y);
            Canvas.SetLeft(img, position.X);
            canvas.Children.Add(img);
        }
        //public void Remove(UIElement v)
        //{
        //    double m = getposition().Y;
        //    canvas.Children.Remove(v);
        //}

        public void removebrick(Brick brick)
        {
            canvas.Children.Remove(img);
        }
        public Point getposition()
        {
            Point posbrick = new Point(Canvas.GetLeft(img), Canvas.GetTop(img));
            return posbrick;
        }

        internal Point getposition2()
        {
            Point posbrick = new Point(Canvas.GetLeft(img) + img.ActualWidth, Canvas.GetTop(img));
            return posbrick;
        }

        //public void draw( int number){
        //    int row = 0;
        //    int col = 30;
        //    for(int i = 0; i < number; i++)
        //    {
        //        bricks.Add(new Brick(canvas, new Point(row, col)));
        //        row += 45;
        //    }
        //}
    }
}
    

