using ImageWatch.ViewModel;
using ImageWatch.Model.DrawObject;

using Size = System.Windows.Size;
using Point = System.Windows.Point;

namespace ImageWatch.ManagementSystem
{
    //여기 안에서 이미지 Zoom Pan Roi 그리기 다 한다.
    //외부에서는 이미지와 ROI 좌표들만 보내준다.

    public class MainSystemData
    {
        public MainSystemData() 
        {
            _drawObj = new DrawObject();
        }

        DrawObject _drawObj;
        public DrawObject DrawObj
        {
            get { return _drawObj; }
            set { _drawObj = value; }
        }

        ImageWatchViewModel _imageWatchViewModel;
        public ImageWatchViewModel ImageWatchViewModel
        {
            get { return _imageWatchViewModel; }
            set { _imageWatchViewModel = value; }
        }

        public Action<Point, Point> RightMouseEvent;


        bool _mouseLeftFlag;
        public bool MouseLeftFlag
        {
            get { return _mouseLeftFlag; }
            set { _mouseLeftFlag = value; }
        }

        bool _mouseWheelFlag;
        public bool MouseWheelFlag
        {
            get { return _mouseWheelFlag; }
            set { _mouseWheelFlag = value; }
        }

        bool _mouseRightFlag;
        public bool MouseRightFlag
        {
            get { return _mouseRightFlag; }
            set { _mouseRightFlag = value; }
        }

        int _imageWidth;
        public int ImageWidth
        {
            get { return _imageWidth; }
            set { if (_imageWidth != value) _imageWidth = value; }
        }

        int _imageHeight;
        public int ImageHeight
        {
            get { return _imageHeight; }
            set { if (_imageHeight != value) _imageHeight = value; }
        }

        double _imageControlWidth;
        public double ImageControlWidth
        {
            get { return _imageControlWidth; }
            set { if (_imageControlWidth != value) _imageControlWidth = value; }
        }

        double _imageControlHeight;
        public double ImageControlHeight
        {
            get { return _imageControlHeight; }
            set { if (_imageControlHeight != value) _imageControlHeight = value; }
        }

        double _gridControlWidth;
        public double GridControlWidth
        {
            get { return _gridControlWidth; }
            set { if (_gridControlWidth != value) _gridControlWidth = value; }
        }

        double _gridControlHeight;
        public double GridControlHeight
        {
            get { return _gridControlHeight; }
            set { if (_gridControlHeight != value) _gridControlHeight = value; }
        }

        double _gridCenterPointX;
        public double GridCenterPointX
        {
            get { return _gridCenterPointX; }
            set { if (_gridCenterPointX != value) _gridCenterPointX = value; }
        }

        double _gridCenterPointY;
        public double GridCenterPointY
        {
            get { return _gridCenterPointY; }
            set { if (_gridCenterPointY != value) _gridCenterPointY = value; }
        }

        double _canvasControlWidth;
        public double CanvasControlWidth
        {
            get { return _canvasControlWidth; }
            set { if (_canvasControlWidth != value) _canvasControlWidth = value; }
        }

        double _canvasControlHeight;
        public double CanvasControlHeight
        {
            get { return _canvasControlHeight; }
            set { if (_canvasControlHeight != value) _canvasControlHeight = value; }
        }

        double _scale = 1;
        public double Scale
        {
            get { return _scale; }
            set { if (_scale != value) _scale = value; }
        }

        double _centerPointX;
        public double CenterPointX
        {
            get { return _centerPointX; }
            set { if (_centerPointX != value) _centerPointX = value; }
        }

        double _centerPointY;
        public double CenterPointY
        {
            get { return _centerPointY; }
            set { if (_centerPointY != value) _centerPointY = value; }
        }

        double _translationX = 0;
        public double TranslationX
        {
            get { return _translationX; }
            set { if (_translationX != value) _translationX = value; }
        }

        double _translationY = 0;
        public double TranslationY
        {
            get { return _translationY; }
            set { if (_translationY != value) _translationY = value; }
        }

        
        double _shiftWidth = 0;
        public double ShiftWidth 
        {
            get { return _shiftWidth; }
            set 
            {
                if (_shiftWidth != value) _shiftWidth = value;
            }
        }
        double _shiftHeight = 0;
        public double ShiftHeight
        {
            get { return _shiftHeight; }
            set
            {
                if (_shiftHeight != value) _shiftHeight = value;
            }
        }

        double _ratioX = 0;
        public double RatioX
        {
            get { return _ratioX; }
            set
            {
                if (_ratioX != value) _ratioX = value;
            }
        }
        double _ratioY = 0;
        public double RatioY
        {
            get { return _ratioY; }
            set
            {
                if (_ratioY != value) _ratioY = value;
            }
        }
        double _rMouseDownX;
        public double MouseDownX
        {
            get { return _rMouseDownX; }
            set
            {
                if (_rMouseDownX != value) _rMouseDownX = value;
            }
        }

        double _rMouseDownY;
        public double MouseDownY
        {
            get { return _rMouseDownY; }
            set
            {
                if (_rMouseDownY != value) _rMouseDownY = value;
            }
        }

        double _rMouseUpX;
        public double MouseUpX
        {
            get { return _rMouseUpX; }
            set
            {
                if (_rMouseUpX != value) _rMouseUpX = value;
            }
        }

        double _rMouseUpY;
        public double MouseUpY
        {
            get { return _rMouseUpY; }
            set
            {
                if (_rMouseUpY != value) _rMouseUpY = value;
            }
        }

    }
}
