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
            img.Width = 40;
            Canvas.SetTop(img, position.Y);
            Canvas.SetLeft(img, position.X);
            canvas.Children.Add(img);
        }
        public void removebrick()
        {
            canvas.Children.Remove(img);
        }
        public bool CheckerForBrick()
        {
            if ( img.Source.ToString() == "pack://application:,,,/Brick 1.jpg")
            {
                return true;
            }
            return false;
        }
        public void replacebrick()
        {
            canvas.Children.Remove(img);
            img.Source = new BitmapImage(new System.Uri(Location + "cracked.png"));
            canvas.Children.Add(img);
            
        }
        public Point TopLeft()
        {
            Point posbrick = new Point(Canvas.GetLeft(img), Canvas.GetTop(img));
            return posbrick;
        }
        public Point TopRight()
        {
            Point posbrick = new Point(Canvas.GetLeft(img) + img.ActualWidth, Canvas.GetTop(img));
            return posbrick;
        }

        public Point BottomRight() {
            Point posbrick = new Point(Canvas.GetLeft(img) + img.ActualWidth, Canvas.GetTop(img) + img.ActualHeight);
            return posbrick;
        }
        public Point BottomLeft()
        {
            Point posbrick = new Point(Canvas.GetLeft(img), Canvas.GetTop(img) + img.ActualHeight);
            return posbrick;
        }
    }
}
    

