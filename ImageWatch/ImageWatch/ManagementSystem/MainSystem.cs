using ImageWatch.Model.DrawObject;
using ImageWatch.Model.ManagementSystem;
using ImageWatch.Define;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using ImageWatch.ViewModel;
using Point = System.Windows.Point;

namespace ImageWatch.ManagementSystem
{
    public class MainSystem : MainSystemData
    {
        public MainSystem()
        {
            _coordinateTransformations = new CoordinateTransformations();        
        }
      
        

        CoordinateTransformations _coordinateTransformations;

        public void CalRatio()
        {
            double ratio = Math.Min(GridControlWidth / ImageWidth, GridControlHeight / ImageHeight);

            ImageControlWidth = ImageWidth * ratio;
            ImageControlHeight = ImageHeight * ratio;

            RatioX = ImageControlWidth / ImageWidth;
            RatioY = ImageControlHeight / ImageHeight;

            ImageWatchViewModel.CenterPointX = ImageControlWidth / 2;
            ImageWatchViewModel.CenterPointY = ImageControlHeight / 2;

            CalShift(Scale);
        }

        public void CalShift(double scale)
        {
            ShiftWidth = ((CanvasControlWidth - (ImageControlWidth * scale)) / 2);
            ShiftHeight = ((CanvasControlHeight - (ImageControlHeight * scale)) / 2);
        }

        public void ImageScaleChange(int Delta)
        {
            if (!MouseWheelFlag) return;

            double scale = Scale;

            if (Delta > 0)
            {
                scale += CommonDefine.ScaleStep;
                if (scale > CommonDefine.ScaleMax) scale = CommonDefine.ScaleMax;
            }
            else
            {
                scale -= CommonDefine.ScaleStep;
                if (scale < CommonDefine.ScaleMin) scale = CommonDefine.ScaleMin;
            }

            CalShift(scale);

            ImageWatchViewModel.Scale = scale;
        }

        public void ImageTranslationChange(double offsetX, double offsetY)
        {
            if (!MouseLeftFlag) return;
            //스케일을 곱해주는 이유는 확대 되었을때 그만큼 더 움직일수 있도록 가중치를 부여 한것이다.
            ImageWatchViewModel.TranslationX += (offsetX * Scale * CommonDefine.MouseSensitivity);
            ImageWatchViewModel.TranslationY += (offsetY * Scale * CommonDefine.MouseSensitivity);
        }

        public void AddDrawObjectEllipse(double X, double Y, double Width, double Height, System.Windows.Media.Color Color)
        {
            System.Windows.Point point;
            System.Windows.Size size;

            point = _coordinateTransformations.CoordinateTransformationsPoint(CommonDefine.Coordinate.eImage2Control, new System.Windows.Point(X, Y), new System.Windows.Size(RatioX, RatioY));
            size = _coordinateTransformations.CoordinateTransformationsLength(CommonDefine.Coordinate.eImage2Control, new System.Windows.Size(Width, Height), new System.Windows.Size(RatioX, RatioY));

            DrawEllipse ellipse = new DrawEllipse(point, size , Color);

            DrawObj.drawEllipses.Enqueue(ellipse);
        }

        public void AddDrawObjectLine(double startX, double startY, double EndX, double EndY, System.Windows.Media.Color Color)
        {
            System.Windows.Point StartPoint;
            System.Windows.Point EndPoint;

            StartPoint = _coordinateTransformations.CoordinateTransformationsPoint(CommonDefine.Coordinate.eImage2Control, new System.Windows.Point(startX, startY), new System.Windows.Size(RatioX, RatioY));
            EndPoint = _coordinateTransformations.CoordinateTransformationsPoint(CommonDefine.Coordinate.eImage2Control, new System.Windows.Point(EndX, EndY), new System.Windows.Size(RatioX, RatioY));

            DrawLine Line = new DrawLine(StartPoint, EndPoint, Color);

            DrawObj.drawLines.Enqueue(Line);
        }

        public void AddDrawObjectRect(double X, double Y, double Width, double Height, System.Windows.Media.Color Color)
        {
            System.Windows.Point point;
            System.Windows.Size size;

            point = _coordinateTransformations.CoordinateTransformationsPoint(CommonDefine.Coordinate.eImage2Control, new System.Windows.Point(X, Y), new System.Windows.Size(RatioX, RatioY));
            size = _coordinateTransformations.CoordinateTransformationsLength(CommonDefine.Coordinate.eImage2Control, new System.Windows.Size(Width, Height), new System.Windows.Size(RatioX, RatioY));

            DrawRect Rect = new DrawRect(point, size, Color);

            DrawObj.drawRects.Enqueue(Rect);
        }

        public void UpdateImage(BitmapSource Bitmap, bool ObjectDraw = false)
        {

            DeleteAllDrawObject();

            ImageWatchViewModel.UpdateImage(Bitmap);

            //CalRatio();

            if (ObjectDraw)
                ImageWatchViewModel.UpdateResult();   
        }

        public void UpdateUIImage(byte[] imageData, int width, int height, int channels)
        {
            ImageWatchViewModel.UpdateImage(imageData, width, height, channels);
            ImageWatchViewModel.UpdateResult();   
        }

        public BitmapSource ByteArrayToBitmapSource(byte[] imageData, int width, int height, int channels)
        {
            // 이미지의 픽셀 형식을 RGB 또는 BGR로 결정
            PixelFormat pixelFormat = channels == 3 ? PixelFormats.Bgr24 : PixelFormats.Gray8;

            // 이미지의 스트라이드 계산
            int stride = width * (pixelFormat.BitsPerPixel / 8);

            // BitmapSource 생성
            BitmapSource bitmapSource = BitmapSource.Create(width, height, 96, 96, pixelFormat, null, imageData, stride);

            return bitmapSource;
        }

        public void ImageFit()
        {
            ImageWatchViewModel.TranslationX = 0;
            ImageWatchViewModel.TranslationY = 0;
            ImageWatchViewModel.Scale = 1;
        }

        public void DrawAllObject()
        {
            ImageWatchViewModel.UpdateResult();
        }

        public void DeleteAllDrawObject()
        {
            DrawObj.DeleteAllDrawObject();
            ImageWatchViewModel.DeleteResult();
        }

        public void Close()
        {
            //UI Draw Object 다 지움
            ImageWatchViewModel.DeleteResult();

            //Draw Object 다 지움
            DrawObj.DeleteAllDrawObject();
        }

        public void MouseRightButtomEvent() 
        {
            if (!MouseRightFlag) return;

            Point startPoint;
            Point EndPoint;

            startPoint = _coordinateTransformations.CoordinateTransformationsPoint(CommonDefine.Coordinate.eControl2Image, new System.Windows.Point(MouseDownX, MouseDownY), new System.Windows.Size(RatioX, RatioY));
            EndPoint = _coordinateTransformations.CoordinateTransformationsPoint(CommonDefine.Coordinate.eControl2Image, new System.Windows.Point(MouseUpX, MouseUpY), new System.Windows.Size(RatioX, RatioY));

            RightMouseEvent?.Invoke(startPoint, EndPoint);
        }
    }
}
