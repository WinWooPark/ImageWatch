using ImageWatch.ManagementSystem;
using ImageWatch.ViewModel;
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

        public void UpdateUIImage(BitmapSource Bitmap) 
        {
            _mainSystem.UpdateImage(Bitmap);
        }

        public void UpdateUIByteImage(byte[] imageData, int width, int height, int channels)
        {
            _mainSystem.UpdateUIByteImage(imageData, width, height, channels);
        }

        public void AddDrawObjectEllipse(double X, double Y, double Width, double Height, bool Judge)
        {
            _mainSystem.AddDrawObjectEllipse(X, Y, Width, Height, Judge);
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
