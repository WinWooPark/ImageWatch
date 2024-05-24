﻿
using ImageWatch.ManagementSystem;
using System.Windows;
using System.Windows.Media;

namespace ImageWatch.Model.DrawObject
{
    public class DrawEllipse
    {
        public DrawEllipse(){}

        public DrawEllipse(Point point , Size size, Color color)
        {
            _originPoint = point;
            _origineEllipseSize = size;
            _strokeColor = color;
            _stroke = new SolidColorBrush(color);
        }

        public void UpdatePosition(double Scale, double ShiftX, double ShiftY, double TranslationX, double TranslationY) 
        {
            // 현재 zoom 과 Pan이 안먹힌 상태의 좌표이다. 여기에서 Zoom과 Pan을 먹힌다.

            _centerPoint.X = (_originPoint.X * Scale) + ShiftX + TranslationX;
            _centerPoint.Y = (_originPoint.Y * Scale) + ShiftY + TranslationY;

            _ellipseSize.Width = (_origineEllipseSize.Width * Scale);
            _ellipseSize.Height = (_origineEllipseSize.Height * Scale);
        }

        public DrawEllipse Clone() 
        {
            return new DrawEllipse(this.OriginPoint, this.OrigineEllipseSize, this.StrokeColor);
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

        Point _originPoint;
        public Point OriginPoint
        {
            get { return _originPoint; }
            set { _originPoint = value; }
        }

        Point _centerPoint;
        public Point CenterPoint 
        {
            get { return _centerPoint; }
            set { _centerPoint = value; }
        }

        Size _ellipseSize;
        public Size EllipseSize 
        {
            get { return _ellipseSize; }
            set { _ellipseSize = value; }
        }

        Size _origineEllipseSize;
        public Size OrigineEllipseSize
        {
            get { return _origineEllipseSize; }
            set { _origineEllipseSize = value; }
        }

        public double CenterPointX 
        {
            get { return _centerPoint.X; }
            set { _centerPoint.X = value; }
        }

        public double CenterPointY
        {
            get { return _centerPoint.Y; }
            set { _centerPoint.Y = value; }
        }

        public double EllipseWidth
        {
            get { return _ellipseSize.Width; }
            set { _ellipseSize.Width = value; }
        }

        public double EllipseHight
        {
            get { return _ellipseSize.Height; }
            set { _ellipseSize.Height = value; }
        }
    }
}
