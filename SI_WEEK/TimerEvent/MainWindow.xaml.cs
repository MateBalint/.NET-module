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

namespace TimerEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Threading.DispatcherTimer _timer;


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            myProgressBar.Value += 10;
            if (myProgressBar.Value >= 100)
            {
                _timer.Stop();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.myProgressBar.Loaded += new RoutedEventHandler(MyProgressBar_Loaded);
        }

        private void MyProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Windows.Threading.DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);
            _timer.Start();
        }
    }
}
