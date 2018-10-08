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
        public bool checkcollision()
        {
            Point ballpos = ball.BottomLeft();
            Point balYps = ball.BottomRight();
            
            if (board.IntersectsWith(ballpos, balYps))
            {
                ball.bounce(board.Position());
                return true;
            }
            return false;
        }
        private bool BrickPointCollision(Point p, Point topLeft, Point bottomRight)  // for the top and bottom
        {
            return p.X >= topLeft.X && p.X <= bottomRight.X && p.Y <= bottomRight.Y && p.Y >= topLeft.Y;
        }
        public void  Brickcollision() 
        {
            List<Point> ballPoints = new List<Point>();
            ballPoints.Add(ball.TopLeft());
            ballPoints.Add(ball.BottomRight());
            ballPoints.Add(ball.BottomLeft());
            ballPoints.Add(ball.TopRight());
            Brick intersected = null;
            bool i = false; // has-hit-side-of-brick
            foreach (Brick b in bricks)
            {
                foreach (Point p in ballPoints)
                {
                    if (BrickPointCollision(p, b.TopLeft(), b.BottomRight()))
                    {
                        intersected = b;
                        if (ball.TopLeft().X == b.TopRight().X || ball.TopRight().X == b.TopLeft().X)
                        {
                            if(ball.TopLeft().Y < b.BottomRight().Y || ball.BottomLeft().Y > b.TopRight().Y)
                            {
                                i = true;
                            }
                        }
                    }
                }
                if (intersected != null)
                {
                    break;
                }
            }
            if (intersected != null)
            {
                if (i) // has-hit-brick-side
                {
                    ball.ReverseX();
                    if (intersected.CheckerForBrick()) // is-brick-cracked
                    {
                        intersected.replacebrick();
                    }
                    else
                    {
                        intersected.removebrick();
                        bricks.Remove(intersected);
                    }
                }
                else
                {
                    ball.ReverseY();
                    if (intersected.CheckerForBrick())
                    {
                        intersected.replacebrick();
                    }
                    else
                    {
                        intersected.removebrick();
                        bricks.Remove(intersected);
                    }
                }
            }
        }
       
        public Game(TheBoard board, Ball ball, List<Brick> list)
        {
            this.bricks = list;
            this.ball = ball;
            this.board = board;
        }
    }
}
    

