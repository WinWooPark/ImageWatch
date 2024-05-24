using ImageWatch.ManagementSystem;
using ImageWatch.ViewModel;
using System.Windows.Controls;

namespace ImageWatchAPI
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ImageWatch : UserControl
    {
        ImageWatchViewModel _imageWatchViewModel;
        MainSystem _mainSystem;
        public MainSystem MainSystem
        {
            get { return _mainSystem; }
        } 

        public ImageWatch()
        {
            _mainSystem = new MainSystem();
            _imageWatchViewModel = new ImageWatchViewModel(_mainSystem);

            _mainSystem.ImageWatchViewModel = _imageWatchViewModel;
          
            InitializeComponent();
            DataContext = _imageWatchViewModel;
        }
    }

}
