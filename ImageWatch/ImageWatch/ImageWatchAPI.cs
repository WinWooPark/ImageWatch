using ImageWatch.ManagementSystem;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static ImageWatch.ManagementSystem.MainSystemData;
using Point = System.Windows.Point;

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

        public void InitImageView(int ImageWidth, int ImageHeight,bool MouseWheelFlag = true, bool MouseLeftFlag = true, bool MouseRightFlag = false) 
        {
            _mainSystem.ImageWidth = ImageWidth;
            _mainSystem.ImageHeight = ImageHeight;
            _mainSystem.MouseLeftFlag = MouseLeftFlag;
            _mainSystem.MouseRightFlag = MouseRightFlag;
            _mainSystem.MouseWheelFlag = MouseWheelFlag;
        }
        
        public void Close() 
        {
            _mainSystem.Close();
        }

        public void UpdateUIImage(BitmapSource Bitmap , bool ObjectDraw = false) 
        {
            _mainSystem.UpdateImage(Bitmap);
        }

        public void UpdateUIImage(byte[] imageData, int width, int height, int channels)
        {
            _mainSystem.UpdateUIImage(imageData, width, height, channels);
        }

        public void AddDrawObjectEllipse(double X, double Y, double Width, double Height, Color Color)
        {
            _mainSystem.AddDrawObjectEllipse(X, Y, Width, Height, Color);
        }

        public void AddDrawObjectLine(double startX, double startY, double EndX, double EndY, Color Color)
        {
            _mainSystem.AddDrawObjectLine(startX, startY, EndX, EndY, Color);
        }

        public void AddDrawObjectRect(double X, double Y, double Width, double Height, Color Color)
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

        public void SetRightMouseButtomEvent(Action<Point,Point> mousePointCallBack) 
        {
            _mainSystem.RightMouseEvent += mousePointCallBack;
        }
    }
}
