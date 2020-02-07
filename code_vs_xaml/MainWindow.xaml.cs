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

namespace XamlVSCode_070220
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Xaml vs Code";

            //Stackpanel aanmaken.
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;
            this.Content = stackPanel;

            //Textblock aan stackpanel toevoegen.
            TextBlock textBlock = new TextBlock();
            textBlock.Margin = new Thickness(3);
            textBlock.Text = "hello";
            stackPanel.Children.Add(textBlock);

            //Button.
            Button btn = new Button();
            btn.Margin = new Thickness(3);
            btn.Content = "Click";
            btn.Name = "btnClick";
            stackPanel.Children.Add(btn);
            btn.Click += Btn_Click; //+= tab.
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
        }
    }
}
