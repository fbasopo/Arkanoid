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
        //double velY = 15, velX = 15;
        public void checkcollision()
        {
            //theGame = new Game(img);
            //theGame.Bounce( canvas, board);
            Point ballpos = ball.GetPosition();
            Point balYps = ball.GetPosition2();
            if (board.IntersectsWith(ballpos, balYps))
            {
                ball.bounce();
                
            }
            
        }
       
        public Game(TheBoard board, Ball ball)
        {
            this.ball = ball;
            this.board = board;
        }
    }
}
    

