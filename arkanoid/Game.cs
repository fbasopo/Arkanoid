using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace arkanoid
{
    class Game
    {
        // we are unable to get the bounce method into this class and call it in the main window 
        Ball ball;
        TheBoard board;
        Brick brick;
        List<Brick> bricks;
        Canvas canvas;
        //Canvas canvas;
        //double velY = 15, velX = 15;
        public void checkcollision()
        {
            //theGame = new Game(img);
            //theGame.Bounce( canvas, board);
            Point ballpos = ball.BottomLeft();
            Point balYps = ball.BottomRight();
            
            if (board.IntersectsWith(ballpos, balYps))
            {
                ball.bounce(board.Position());
                
            }
            
        }

        public void  Brickcollision(Canvas canvas, List<Brick> brck) 
        {
            //if (brick.getposition().Y == ball.Intersection().Y)
            //{
            //    //ball.Intersection();
            //    brick.Remove();
            //}
            //foreach (UIElement b in canvas.Children)
            //{

            //    if ()
            //    {

            //        //ball.Intersection();
            //        brick.Remove(b);
            //    }

            //}
            
            
            //foreach(Brick b in brck)
            //{
            //    Point posball = ball.GetPosition();
            //    Point posbrck = b.getposition();
            //    if(posbrck.Y + 35 >= posball.Y - 25)
            //    {
            //        if(posbrck.X <= posball.X + 25 && posbrck.X + 35 >= posball.X)
            //        {
            //            //ball.bounce(posball);
            //            brck.Remove(b);
            //        }
            //    }
            //}
        }

        public Game(TheBoard board, Ball ball, List<Brick> list)
        {
            this.bricks = list;
            this.ball = ball;
            this.board = board;
        }
    }
}
    

