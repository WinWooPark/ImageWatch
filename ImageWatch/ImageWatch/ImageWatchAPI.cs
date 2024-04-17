using ImageWatch.ManagementSystem;
using ImageWatch.ViewModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace ImageWatch
{
    public class ImageWatchAPI
    {
        MainSystem _mainSystem;
        ImageWatch _imageWatch;
        public ImageWatch ImageWatch 
        {
            get { return _imageWatch; }
        }

        public ImageWatchAPI()
        {
            _imageWatch = new ImageWatch();
            _mainSystem = ImageWatch.MainSystem;
        }

        public void InitImageView(int ImageWidth, int ImageHeight) 
        {
            _mainSystem.ImageWidth = ImageWidth;
            _mainSystem.ImageHeight = ImageHeight;
        }
        
        public void Close() 
        {
            _mainSystem.Close();
        }

        public void UpdateUIImage(BitmapSource Bitmap , bool ObjectDraw = false) 
        {
            _mainSystem.UpdateImage(Bitmap);
        }

        public void UpdateUIByteImage(byte[] imageData, int width, int height, int channels)
        {
            _mainSystem.UpdateUIByteImage(imageData, width, height, channels);
        }

        public void AddDrawObjectEllipse(double X, double Y, double Width, double Height, SolidColorBrush Color)
        {
            _mainSystem.AddDrawObjectEllipse(X, Y, Width, Height, Color);
        }

        public void AddDrawObjectLine(double startX, double startY, double EndX, double EndY, SolidColorBrush Color)
        {
            _mainSystem.AddDrawObjectLine(startX, startY, EndX, EndY, Color);
        }

        public void AddDrawObjectRect(double X, double Y, double Width, double Height, SolidColorBrush Color)
        {
            _mainSystem.AddDrawObjectRect(X, Y, Width, Height, Color);
        }

        public void DrawAllObject()
        {
            _mainSystem.DrawAllObject();
        }

         public void DeleteAllDrawObject()
        {
           _mainSystem.DeleteAllDrawObject();
        }

        public void ImageWatchZoom(int Delta)
        {
            _mainSystem.ImageScaleChange(Delta);
        }

        public void ImageWatchFit()
        {
            _mainSystem.ImageFit();
        }
    }
}
