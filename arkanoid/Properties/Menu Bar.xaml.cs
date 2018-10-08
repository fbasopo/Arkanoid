using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace arkanoid.Properties
{
    /// <summary>
    /// Interaction logic for Menu_Bar.xaml
    /// </summary>
    public partial class Menu_Bar : Window
    {
        SoundPlayer sp = new SoundPlayer(Directory.GetCurrentDirectory() + @"\music1.wav");
        int m = 0;
        MainWindow mw;
        public Menu_Bar()
        {
            InitializeComponent();
            sp.PlayLooping();
        }
        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {
            mw = (MainWindow)Application.Current.MainWindow;
            mw.Show();
            this.Hide();
        }

        private void Sound_Button_Click(object sender, RoutedEventArgs e)
        {
            string[] x = {"Sound On", "Sound Off"};
            switch (m)
            {
                case 0: Sound_Button.Content = x[1]; m = 1 ; sp.Stop(); break;
                case 1: Sound_Button.Content = x[0]; m = 0; sp.PlayLooping(); break;
            }
        }
        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
