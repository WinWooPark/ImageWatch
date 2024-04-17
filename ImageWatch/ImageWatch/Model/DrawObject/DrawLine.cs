using ImageWatch.ManagementSystem;
using System.Windows;
using System.Windows.Media;

namespace ImageWatch.Model.DrawObject
{
    public class DrawLine
    {
        public DrawLine() { }

        public DrawLine(Point StartPoint, Point EndPoint, SolidColorBrush color)
        {
            _originStartPoint = StartPoint;
            _originEndPoint = EndPoint;
            _fill = color;
        }

        public void UpdatePosition(double Scale, double ShiftX, double ShiftY, double TranslationX, double TranslationY)
        {
            // 현재 zoom 과 Pan이 안먹힌 상태의 좌표이다. 여기에서 Zoom과 Pan을 먹힌다.

            _startPoint.X = (_originStartPoint.X * Scale) + ShiftX + TranslationX;
            _startPoint.Y = (_originStartPoint.Y * Scale) + ShiftY + TranslationY;

            _endPoint.X = (_originEndPoint.X * Scale) + ShiftX + TranslationX;
            _endPoint.Y = (_originEndPoint.Y * Scale) + ShiftY + TranslationY;
        }

        SolidColorBrush _fill;
        public SolidColorBrush Fill
        {
            get { return _fill; }
            set { _fill = value; }
        }

        Point _originStartPoint;
        public Point StartPoint
        {
            get { return _originStartPoint; }
            set { _originStartPoint = value; }
        }

        Point _originEndPoint;
        public Point EndPoint
        {
            get { return _originEndPoint; }
            set { _originEndPoint = value; }
        }

        Point _startPoint;
        Point _endPoint;

        public double StartPointX
        {
            get { return _startPoint.X; }
            set { _startPoint.X = value; }
        }

        public double StartPointY
        {
            get { return _startPoint.Y; }
            set { _startPoint.Y = value; }
        }
        public double EndPointX
        {
            get { return _endPoint.X; }
            set { _endPoint.X = value; }
        }

        public double EndPointY
        {
            get { return _endPoint.Y; }
            set { _endPoint.Y = value; }
        }
    }
}
