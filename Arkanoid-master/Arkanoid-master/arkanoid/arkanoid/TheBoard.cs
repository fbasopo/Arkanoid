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
        
        //private void paddle_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (activate)             // if activated
        //    {
        //        double left = Canvas.GetLeft(img) + Mouse.GetPosition(img).X - point.X; // get the position of the img relative to the canvas and add it to the position of the mouse with the image
        //        Canvas.SetLeft(img, left); // move the mouse horizontally
        //    }
        //}

        public void Activate()
        {
            activate = true;
            point = Mouse.GetPosition(img);    // mouse must get the position of the img
            Mouse.Capture(img);                // the mouse must capture the position of the image
        }

        public void move()
        {
            if (activate)
            {
                double left = Canvas.GetLeft(img) + Mouse.GetPosition(img).X - point.X;
                Canvas.SetLeft(img, left);
                double x = Canvas.GetRight(img);
                //point = Mouse.GetPosition(paddle);
            }
        }
        public bool IntersectsWith(Point p, Point q)
        {
            if (p.Y >= Canvas.GetTop(img) && q.Y >= Canvas.GetTop(img))  // if the ball hits the top and bottom of the canvas
            {
                if (p.X >= Canvas.GetLeft(img) && p.X <= (Canvas.GetLeft(img) + img.ActualWidth) ||  q.X > Canvas.GetLeft(img) + img.ActualWidth )  //this if statement to know when to bounce off the board
                {     
                    return true;
                }
            }
            return false;
        }
    }
}
    

