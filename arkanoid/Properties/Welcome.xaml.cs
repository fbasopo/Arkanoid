using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace arkanoid.Properties
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {

        DispatcherTimer go;
        Properties.Menu_Bar tm;
        
        public Welcome()
        {
            InitializeComponent();
            WelcomeVideo.Source = new Uri(Directory.GetCurrentDirectory() +@"\start.wmv");
            WelcomeVideo.Play();
            go = new DispatcherTimer();
            go.Interval = TimeSpan.FromSeconds(7);
            go.IsEnabled = true;
            go.Tick += Tino_Tick;
        }
       
        private void Tino_Tick(object sender, EventArgs e)
        {
            tm = new Menu_Bar();
            tm.Show();
            this.Hide();
            go.IsEnabled = false;
        }
    }
}
