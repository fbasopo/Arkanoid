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
            Point ballpos = ball.BottomLeft();
            Point balYps = ball.BottomRight();
            
            if (board.IntersectsWith(ballpos, balYps))
            {
                ball.bounce(board.Position());
                
            }
            
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
            bool i = false;
            bool a = false;
            foreach (Brick b in bricks)
            {
                foreach (Point p in ballPoints)
                {
                    if (BrickPointCollision(p, b.TopLeft(), b.BottomRight()))
                    {
                        
                        intersected = b;
                        if (ball.TopLeft().X == b.TopRight().X || ball.TopRight().X == b.TopLeft().X)
                        {
                            if(ball.TopLeft().Y <= b.BottomRight().Y && ball.BottomLeft().Y >= b.TopRight().Y)
                            {
                                i = true;
                            }
                        }

                        if (ball.BottomRight().Y == b.TopRight().Y || ball.TopRight().Y == b.BottomRight().Y)
                        {
                            if (ball.TopRight().X >= b.BottomLeft().X && ball.TopLeft().X <= b.BottomRight().X)
                            {
                                a = true;
                            }
                        }
                        //if (ball.TopRight().Y == b.BottomRight().Y)
                        //{

                        //}
                    }
                }
                if (intersected != null)
                {
                    break;
                }
            }
            if (intersected != null)
            {
                if (i)
                {
                    if (intersected.CheckerForBrick())
                    {
                        ball.ReverseX();
                        intersected.replacebrick();
                    }
                    else
                    {
                        ball.ReverseX();
                        intersected.removebrick();
                        bricks.Remove(intersected);
                    }
                }

                if (a)
                {
                    if (intersected.CheckerForBrick())
                    {
                        ball.ReverseY();
                        intersected.replacebrick();
                    }
                    else
                    {
                        ball.ReverseY();
                        intersected.removebrick();
                        bricks.Remove(intersected);
                    }
                }

                //if (intersected.CheckerForBrick())
                //{
                //    ball.ReverseCourse();
                //    intersected.replacebrick();
                //}
                //else
                //{
                //    ball.ReverseCourse();
                //    intersected.removebrick();
                //    bricks.Remove(intersected);
                //}
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
    

