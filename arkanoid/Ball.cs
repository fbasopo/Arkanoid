 using System;
using System.Windows;
using System.Windows.Controls;


namespace arkanoid
{
    class Ball
    {
        //Game theGame;
        double velX = 4, velY = 4;   // initialised velocities for the ball
        Image img;
        // img represents the ball
        //This is to check whether the ball is within the canvas
        //Canvas canvasP;
        private void moveX(Canvas canvasP)  // the method to move the ball in the x axis
        {
            //Ball Nball = new Ball();
            double ballX = Canvas.GetLeft(img) + velX;  // it is to move the ball to the horizontal
            Canvas.SetLeft(img, ballX);
            if(ballX < 0 || ballX + img.ActualWidth > canvasP.ActualWidth && velX > 0) // if the ball hits the canvas 
            {
                velX = -velX;                                                          // chang ethe direction
            }
        }
        public Point Intersection()
        {
            Point bbl = new Point(Canvas.GetLeft(img), Canvas.GetTop(img));
            return bbl;
        }
        public Point BottomRight()
        {
            Point ballS = new Point(Canvas.GetLeft(img) + img.ActualWidth, Canvas.GetTop(img) + img.ActualHeight);
            return ballS;
        }

        public Point BottomLeft() {
            Point ballY = new Point(Canvas.GetLeft(img), Canvas.GetTop(img) + img.ActualHeight);
            return ballY;
        }

        public Point TopLeft() {
            Point ballY = new Point(Canvas.GetLeft(img), Canvas.GetTop(img));
            return ballY;
        }

        public Point TopRight() {
            Point ballY = new Point(Canvas.GetLeft(img) + img.ActualWidth, Canvas.GetTop(img));
            return ballY;
        }

        private void moveY(Canvas canvasP)
        {
            double ballY = Canvas.GetTop(img) + velY;   // get the position and move it velY up
            Canvas.SetTop(img, ballY);              // move the ball up
            if(ballY < 0)   // if the ball hits the top and bottom of the canvas
            {
                velY = -velY;                // change the direction
            }
        }
        public Ball(Image img)          // the constructor for the ball
        {
            this.img = img;             
            //canvasP = play;
        }

        public void update(Canvas canvas)
        {
            moveX(canvas);                    //method in the ball class to move the ball horizontally
            moveY(canvas);                    //method in the ball class to movethe ball vertically
        }
        
        public void ReverseX()
        {
            velX *= -1;
        }

        public void ReverseY()
        {
            velY *= -1;
        }
        public bool LeavesArea(Canvas canvas)
        {
            if (Canvas.GetTop(img) + img.ActualHeight >= canvas.ActualHeight)
            {
                return true;
            }
            return false;
        }

        public void bounce(Point p)
        {
            Canvas.SetTop(img, p.Y - img.ActualWidth - 1);
            velY = -velY;
        }
    }
}
    

