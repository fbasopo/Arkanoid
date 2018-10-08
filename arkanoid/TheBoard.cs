using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;



namespace arkanoid
{
    class TheBoard
    {
        Image img;
        Canvas canvas;

        public void move_board(Canvas canvasP, Image img)
        {
            //double x = Canvas.GetLeft(img);

        }
        public TheBoard(Image img)   // the constructor for the board 
        {
            this.img = img;

        }
        bool activate = false;    // initialise the activate of the mouse
        Point point;
        
        public bool Activate()
        {
            activate = true;
            point = Mouse.GetPosition(img);    // mouse must get the position of the img
            Mouse.Capture(img);                // the mouse must capture the position of the image
            return true;
        }

        public void move(Canvas canvas)
        {
            if (activate)
            {
                double left = Canvas.GetLeft(img) + Mouse.GetPosition(img).X - point.X;
                if (left <= 0 || left + img.ActualWidth >= canvas.ActualWidth) return;
                Canvas.SetLeft(img, left);
                double x = Canvas.GetRight(img);
                //point = Mouse.GetPosition(paddle);
            }
        }
        public bool IntersectsWith(Point p, Point q)
        {
            if (p.Y >= Canvas.GetTop(img) && q.Y >= Canvas.GetTop(img))  
            {
                double a = Canvas.GetLeft(img);
                double b = a + img.ActualWidth;
                if (q.X >= a && p.X <= b )  //this if statement to know when to bounce off the board
                {
                    return true;
                }
            }
            return false;
        }

        public Point Position()
        {
            Point f = new Point(Canvas.GetLeft(img), Canvas.GetTop(img));
            //Ball.bounce(f);
            return f;

        }
    }
}
    

