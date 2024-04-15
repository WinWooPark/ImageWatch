using ImageWatch.Define;
using System.Windows;

namespace ImageWatch.Model.ManagementSystem
{
    internal class CoordinateTransformations
    {
        public CoordinateTransformations(){}

        public Point CoordinateTransformationsPoint(CommonDefine.Coordinate Mode, Point InputPoint , Size Ratio)
        {
            Point OutputPoint = new Point();

            switch (Mode)
            {
                case CommonDefine.Coordinate.eImage2Control:
                    OutputPoint = CoordinateTransformationsImageToControlPoint(InputPoint, Ratio);
                    break;
                case CommonDefine.Coordinate.eControl2Image:
                    OutputPoint = CoordinateTransformationsControlToImagePoint(InputPoint, Ratio);
                    break;
            }
            return OutputPoint;
        }

        Point CoordinateTransformationsImageToControlPoint(Point InputPoint , Size Ratio)
        {
            Point OutputPoint = new Point();
            
            OutputPoint.X = InputPoint.X * Ratio.Width;
            OutputPoint.Y = InputPoint.Y * Ratio.Height;

            return OutputPoint;
        }

        Point CoordinateTransformationsControlToImagePoint(Point InputPoint, Size Ratio)
        {
            Point OutputPoint = new Point();

            OutputPoint.X = InputPoint.X / Ratio.Width;
            OutputPoint.Y = InputPoint.Y / Ratio.Height;

            return OutputPoint;
        }

        public Size CoordinateTransformationsLength(CommonDefine.Coordinate Mode, Size Input , Size Ratio)
        {
            Size Output = new Size();

            switch (Mode)
            {
                case CommonDefine.Coordinate.eImage2Control:
                    Output = CoordinateTransformationsImageToControlLength(Input, Ratio);
                    break;
                case CommonDefine.Coordinate.eControl2Image:
                    Output = CoordinateTransformationsControlToImageLength(Input, Ratio);
                    break;
            }
            return Output;
        }

        Size CoordinateTransformationsImageToControlLength(Size Input, Size Ratio)
        {
            Size Output = new Size();
            
            Output.Width = Input.Width   * Ratio.Width;
            Output.Height = Input.Height * Ratio.Height;

            return Output;
        }

        Size CoordinateTransformationsControlToImageLength(Size Input, Size Ratio)
        {
            Size Output = new Size();
     
            Output.Width = Input.Width   / Ratio.Width;
            Output.Height = Input.Height / Ratio.Height;

            return Output;
        }

    }
}
