using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AForge.Vision.Motion;

namespace labo_op1_beweging_140220
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VideoCaptureDevice LocalWebCam;
        FilterInfoCollection LocalWebCamsCollection;
        MotionDetector simple;
        MotionDetector blob;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LocalWebCamsCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            LocalWebCam = new VideoCaptureDevice(LocalWebCamsCollection[0].MonikerString);
            LocalWebCam.VideoResolution = LocalWebCam.VideoCapabilities[0];
            LocalWebCam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);

            simple = new MotionDetector(
                    new SimpleBackgroundModelingDetector(),
                    new MotionAreaHighlighting());


            LocalWebCam.Start();
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap image = eventArgs.Frame;

                

                Dispatcher.Invoke(new Action<Bitmap>(
                     UpdateImage), image); //Cross thread image tonen op scherm.
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void UpdateImage(Bitmap bm)
        {
            if (simple.ProcessFrame(bm) > 0.02 && simple.ProcessFrame(bm) < 0.20)
            {
                lblActionSimple.Content = "Motion detected";
            }
            else if(simple.ProcessFrame(bm) > 0.20)
            {
                lblActionSimple.Content = "A lot of motion detected";
            }
            else
            {
                lblActionSimple.Content = "Safe";
            }
            lblMotion.Content = simple.ProcessFrame(bm);
            simple.ProcessFrame(bm);
            frameHolderSimple.Source = Convert(bm);
        }

        private BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            src.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            image.Freeze();
            return image;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode); //Alle threads stoppen bij closed.
        }
    }
}
