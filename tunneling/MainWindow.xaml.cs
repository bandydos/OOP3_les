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

namespace TunnelingDemo_070220
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int _tunnelingEventStep;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lblTunneling_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender.Equals(wndwMain))
            {
                tbxInfo.Clear();
                _tunnelingEventStep = 1;
            }

            tbxInfo.AppendText(_tunnelingEventStep + ": " +
                ((FrameworkElement)sender).Name + "\n");

            _tunnelingEventStep++;

            if (e.Source.Equals(sender))
            {
                tbxInfo.AppendText("Dit was het tunneling event.\n");
            }
        }
    }
}
