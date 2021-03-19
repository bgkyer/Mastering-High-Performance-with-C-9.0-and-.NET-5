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

namespace CH05_GameOfLife
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
        private readonly Grid _mainGrid;
        readonly System.Windows.Threading.DispatcherTimer _timer;
        private int _genCounter;

        public MainWindow()
        {
            InitializeComponent();
            _mainGrid = new Grid(MainCanvas);
            _timer = new System.Windows.Threading.DispatcherTimer();
            _timer.Tick += OnTimer;
            _timer.Interval = TimeSpan.FromMilliseconds(200);
        }

        private void Button_OnClick(object sender, EventArgs e)
        {
            if (!_timer.IsEnabled)
            {
                _timer.Start();
                ButtonStart.Content = "Stop";
            }
            else
            {
                _timer.Stop();
                ButtonStart.Content = "Start";
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {
            _mainGrid.Update();
            _genCounter++;
            lblGenCount.Content = "Generations: " + _genCounter;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            _mainGrid.Clear();
        }
    }
}