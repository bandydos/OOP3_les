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

namespace BubblingDemo_070220
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int _bubblingEventStep;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lblBubbling_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.Equals(sender))
            {
                tbxInfo.Clear();
                _bubblingEventStep = 1;
                tbxInfo.Text = "Dit is een bubbling event:\n";
            }
            tbxInfo.AppendText(_bubblingEventStep + ": " + ((FrameworkElement)sender).Name + "\n");
            _bubblingEventStep++;

            //Optioneel => event al handled beschouwen.
            if(typeof(StackPanel) == sender.GetType())
            {
                e.Handled = true; 
            }
        }
    }
}
