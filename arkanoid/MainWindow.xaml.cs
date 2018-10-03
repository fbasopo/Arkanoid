using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;


namespace arkanoid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        private BitmapImage[] OverImages;
        private string Location = "pack://application:,,,/";
        DispatcherTimer theTimer = new DispatcherTimer();
        
        Ball theBall;
        TheBoard board;
        Game theGame;
        List<Brick> bricks;
        public MainWindow()
        {
            //playground = new Canvas();
            InitializeComponent();
            theTimer.Interval = TimeSpan.FromMilliseconds(10);
            theTimer.Tick += dispatcherTimer_Tick;
            theTimer.IsEnabled = true;
            theBall = new Ball(ball);
            board = new TheBoard(paddle);
            theGame = new Game(board, theBall, bricks);
            bricks = new List<Brick>();
           
            //bricks.Add(new Brick(canvas, new Point(0, 30)));
            //bricks.Add(new Brick(canvas, new Point(45, 30)));
            //bricks.Add(new Brick(canvas, new Point(90, 30)));
            //bricks.Add(new Brick(canvas, new Point(135, 30)));
            //brick = new Brick(brick1, brick2, brick3);
            //Point p = Mouse.GetPosition(canvas);
            makeBricks(10);
        }

        private bool BrickPointCollision(Point p, Point topLeft, Point bottomRight) {
            return p.X >= topLeft.X && p.X <= bottomRight.X && p.Y <= bottomRight.Y && p.Y >= topLeft.Y;
        }

        public void brickcollision()
        {
            List<Point> ballPoints = new List<Point>();
            ballPoints.Add(theBall.TopLeft());
            ballPoints.Add(theBall.BottomRight());
            ballPoints.Add(theBall.BottomLeft());
            ballPoints.Add(theBall.TopRight());
            Brick intersected = null;
            foreach (Brick b in bricks)
            {
                foreach (Point p in ballPoints) {
                    if (BrickPointCollision(p, b.TopLeft(), b.BottomRight())) {
                        intersected = b;
                    }
                }
                if (intersected != null) {
                    break;
                }
                /*
                Point posball = theBall.BottomLeft();
                Point posbal = theBall.BottomRight();
                Point posbrck = b.TopLeft();
                Point posbrk = b.TopRight();
                if (posbrck.Y >= posball.Y)
                {
                    if (posbrck.X <= posball.X && posbrk.X >= posbal.X)
                    {
                        theBall.bounce(posbrck);
                        
                    }
                }
                */
            }
            if (intersected != null) {
                theBall.ReverseCourse();
                intersected.removebrick();
                bricks.Remove(intersected);
            }
    }
    public void makeBricks(int number) 
        {

            int row = 0;
            int col = 30;
            for (int i = 0; i < number; i++)
            {
                bricks.Add(new Brick(canvas, new Point(row, col)));
                row += 45;
            }

        }
        public void stop()                  // the method to stop the timer
        {
            theTimer.IsEnabled = false;    // stops the timer
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            theBall.update(canvas);                          // 
            theGame.checkcollision();       // calls the method in the ball class to make the ball bounce
            // if it reaches the bottom of the canvas, display the image and stop
            if (theBall.LeavesArea(canvas))
            {
                OverImages = new BitmapImage[] { new BitmapImage(new Uri(Location + "Over1.png")) };
                Over.Source = OverImages[0];
                stop();
            }
            brickcollision();
            //theGame.Brickcollision(canvas, bricks);
        } // dispatcherTimer_Tick

        private void paddle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            board.Activate();                   // actives the board with the mouse
        }

        private void paddle_MouseMove(object sender, MouseEventArgs e)
        {
            board.move();               // moves the board
        }


    }//class Mainwindow
}
    

