using ImageWatch.ManagementSystem;
using System.Windows;
using System.Windows.Media;

namespace ImageWatch.Model.DrawObject
{
    public class DrawRect
    {
        public DrawRect() { }

        public DrawRect(Point point, Size size, Color color)
        {
            _originLeftTopPoint = point;
            _origineRectSize = size;
            _strokeColor = color;
            _stroke = new SolidColorBrush(color);
        }

        public void UpdatePosition(double Scale, double ShiftX, double ShiftY, double TranslationX, double TranslationY)
        {
            // 현재 zoom 과 Pan이 안먹힌 상태의 좌표이다. 여기에서 Zoom과 Pan을 먹힌다.

            _leftTopPoint.X = (_originLeftTopPoint.X * Scale) + ShiftX + TranslationX;
            _leftTopPoint.Y = (_originLeftTopPoint.Y * Scale) + ShiftY + TranslationY;

            _rectSize.Width = (_origineRectSize.Width * Scale);
            _rectSize.Height = (_origineRectSize.Height * Scale);
        }

        public DrawRect Clone()
        {
            return new DrawRect(this.OriginLeftTopPoint, this.OrigineRectSize, this.StrokeColor);
        }

        System.Windows.Media.Color _strokeColor;
        public System.Windows.Media.Color StrokeColor
        {
            get { return _strokeColor; }
            set { _strokeColor = value; }
        }

        SolidColorBrush _stroke;
        public SolidColorBrush Stroke
        {
            get { return _stroke; }
            set { _stroke = value; }
        }

        Point _originLeftTopPoint;
        public Point OriginLeftTopPoint
        {
            get { return _originLeftTopPoint; }
            set { _originLeftTopPoint = value; }
        }

        Point _leftTopPoint;
        public Point LeftTopPoint
        {
            get { return _leftTopPoint; }
            set { _leftTopPoint = value; }
        }

        Size _rectSize;
        public Size RectSize
        {
            get { return _rectSize; }
            set { _rectSize = value; }
        }

        Size _origineRectSize;
        public Size OrigineRectSize
        {
            get { return _origineRectSize; }
            set { _origineRectSize = value; }
        }

        public double RectPointX
        {
            get { return _leftTopPoint.X; }
            set { _leftTopPoint.X = value; }
        }

        public double RectPointY
        {
            get { return _leftTopPoint.Y; }
            set { _leftTopPoint.Y = value; }
        }

        public double RectWidth
        {
            get { return _rectSize.Width; }
            set { _rectSize.Width = value; }
        }

        public double RectHight
        {
            get { return _rectSize.Height; }
            set { _rectSize.Height = value; }
        }
    }
}
