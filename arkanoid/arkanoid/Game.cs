using System;
using System.Windows;
using System.Windows.Controls;

namespace arkanoid
{
    class Game
    {
        // we are unable to get the bounce method into this class and call it in the main window 
        Ball ball;
        TheBoard board;
        //Canvas canvas;
        double velY = 15, velX = 15;
        public int checkcollision()
        {
            //theGame = new Game(img);
            //theGame.Bounce( canvas, board);
            Point ballpos = ball.GetPosition();
            if (board.IntersectsWith(ballpos))
            {
                ball.bounce();
                return 1;
            }
            return 0;

            //double ballY = Canvas.GetTop(img) + img.ActualHeight;   // get the position and move it velY up
            //double boardpos = Canvas.GetTop(board);              // move the ball up
            //double boardwidth = board.ActualWidth;
            //if (ballY >= boardpos)  // if the ball hits the top and bottom of the canvas
            //{
            //    if (Canvas.GetLeft(board) <= Canvas.GetLeft(img) && Canvas.GetLeft(img) + img.ActualWidth < Canvas.GetLeft(board) + board.ActualWidth) //this if statement to know when to bounce off the board
            //    {
            //        velY = -velY;       // change the direction
            //        return 1;
            //    }
            //    else
            //    {
            //        if (ballY < 0 || ballY + img.ActualHeight > canvas.ActualHeight && velY > 0)
            //        {
            //            return 0;
            //        }
            //    }
            //    return 1;
            //    //else
            //    //{
            //    //    return 0;
            //    //}
            //}
            //return 1;

        }
       
        public Game(TheBoard board, Ball ball)
        {
            this.ball = ball;
            this.board = board;
        }
    }
}
    

