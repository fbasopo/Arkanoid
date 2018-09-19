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
using ThinkLib;
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
            theTimer.Interval = TimeSpan.FromMilliseconds(100);
            theTimer.Tick += dispatcherTimer_Tick;
            theTimer.IsEnabled = true;
            theBall = new Ball(ball);
            board = new TheBoard(paddle);
            theGame = new Game(board, theBall);
            bricks = new List<Brick>();
            bricks.Add(new Brick(canvas, new Point(0, 30)));
            bricks.Add(new Brick(canvas, new Point(45, 30)));
            bricks.Add(new Brick(canvas, new Point(90, 30)));
            //brick = new Brick(brick1, brick2, brick3);
            //Point p = Mouse.GetPosition(canvas);

        }
        public void stop()                  // the method to stop the timer
        {
            theTimer.IsEnabled = false;    // stops the timer
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            theBall.update(canvas);                          // 
            int num = theGame.checkcollision();       // calls the method in the ball class to make the ball bounce
            // if it reaches the bottom of the canvas, display the image and stop
            if (theBall.LeavesArea(canvas))
            {
                OverImages = new BitmapImage[] { new BitmapImage(new Uri(Location + "Over1.png")) };
                Over.Source = OverImages[0];
                stop();
            }
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
    

