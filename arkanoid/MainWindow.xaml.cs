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
using System.Media;
using System.Windows.Resources;




namespace arkanoid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        arkanoid.Properties.Welcome welcome;
        private BitmapImage[] OverImages;
        private string Location = "pack://application:,,,/";
        DispatcherTimer theTimer = new DispatcherTimer();
        
        Ball theBall;
        TheBoard board;
        Game theGame;
        List<Brick> bricks;
        bool checkboard = false;

        public MainWindow()
        {
            InitializeComponent();
            welcome = new Properties.Welcome();
            welcome.Show();
            this.Hide();
            theTimer.Interval = TimeSpan.FromMilliseconds(10);
            theTimer.Tick += dispatcherTimer_Tick;
            theTimer.IsEnabled = true;
            theBall = new Ball(ball);
            board = new TheBoard(paddle);
            bricks = new List<Brick>();
            theGame = new Game(board, theBall, bricks);
            double pad = canvas.ActualHeight - (paddle.ActualHeight + 20);
            Canvas.SetBottom(paddle, pad);
            //makes bricks
            makeBricks(16, 4);
            
        }

        public void removeBricks()
        {
            foreach(Brick i in bricks)
            {
                i.removebrick();
            }
        }
        public void makeBricks(int number, int colunm) 
        {
            int row = 10;
            int col = 30;
            for (int i = 0; i < number; i++)
            {
                bricks.Add(new Brick(canvas, new Point(row, col)));
                row += 50;
            }
            if(colunm > 1)
            {
                
                row = 10;
                for (int a = 1; a < colunm; a++)
                {
                    col += 40;
                    for (int b = 0; b < number; b++)
                    {
                        bricks.Add(new Brick(canvas, new Point(row, col)));
                        row += 50;
                    }
                    row = 10;
                }
            }
        }
        public bool checkwin()
        {
            if (bricks.Count == 0)
            {
                return true;
            }
            return false;
        }
        public void stop()                  // the method to stop the timer
        {
            theTimer.IsEnabled = false;    // stops the timer
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //GameSound();
            if (checkboard)
            {
                theBall.update(canvas);
                bool checkforsound = theGame.checkcollision();       // calls the method in the ball class to make the ball bounce
                if (checkforsound)
                {
                    makeBounceSound();
                }
                theGame.Brickcollision();
                // if it reaches the bottom of the canvas, display the image and stop
                if (theBall.LeavesArea(canvas))
                {
                    removeBricks();
                    stop();
                    OverImages = new BitmapImage[] { new BitmapImage(new Uri(Location + "Over1.png")) };
                    Over.Source = OverImages[0];
                }
                if (checkwin())
                {
                    stop();
                    OverImages = new BitmapImage[] { new BitmapImage(new Uri(Location + "youwin.png")) };
                    Over.Source = OverImages[0];
                }
            }
        } // dispatcherTimer_Tick
        private void makeBounceSound()
        {
            SoundPlayer sp = new SoundPlayer(Directory.GetCurrentDirectory() + @"\bounce3.wav");
            sp.Play();
        }
        private void paddle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // actives the board with the mouse
            board.Activate();
        }

        private void paddle_MouseMove(object sender, MouseEventArgs e)
        {
            board.move(canvas);               // moves the board
            checkboard = true;
        }
    }//class Mainwindow
}
    

