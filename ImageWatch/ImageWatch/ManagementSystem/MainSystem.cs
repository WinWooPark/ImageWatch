﻿using ImageWatch.Model.DrawObject;
using ImageWatch.Model.ManagementSystem;
using ImageWatch.Define;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Media3D;
using ImageWatch.ViewModel;

namespace ImageWatch.ManagementSystem
{
    public class MainSystem : MainSystemData
    {
        public MainSystem()
        {
            _coordinateTransformations = new CoordinateTransformations();
        }

        CoordinateTransformations _coordinateTransformations;

        public  void CalRatio()
        {
            RatioX = ImageControlWidth / ImageWidth;
            RatioY = ImageControlHeight / ImageHeight;

            CalShift(Scale);
        }

        void CalShift(double scale)
        {
            ShiftWidth = ((CanvasControlWidth - (ImageControlWidth * scale)) / 2);
            ShiftHeight = ((CanvasControlHeight - (ImageControlHeight * scale)) / 2);
        }

        public void ImageScaleChange(int Delta)
        {
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
            //스케일을 곱해주는 이유는 확대 되었을때 그만큼 더 움직일수 있도록 가중치를 부여 한것이다.
            ImageWatchViewModel.TranslationX += (offsetX * Scale * CommonDefine.MouseSensitivity);
            ImageWatchViewModel.TranslationY += (offsetY * Scale * CommonDefine.MouseSensitivity);
        }

        public void AddDrawObjectEllipse(double X, double Y, double Width, double Height, bool Judge)
        {
            Point point = new Point();
            Size size = new Size();


            point = _coordinateTransformations.CoordinateTransformationsPoint(CommonDefine.Coordinate.eImage2Control, new System.Windows.Point(X, Y), new Size(RatioX, RatioY));
            size = _coordinateTransformations.CoordinateTransformationsLength(CommonDefine.Coordinate.eImage2Control, new System.Windows.Size(Width, Height), new Size(RatioX, RatioY));

            DrawEllipse ellipse = new DrawEllipse(point, size);

            ellipse.Fill = Brushes.Green;

            if (Judge == false)
                ellipse.Fill = Brushes.Red;


            DrawObj.drawEllipses.Enqueue(ellipse);
        }

        public void UpdateImage(BitmapSource Bitmap)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                ImageWatchViewModel.MainImage = Bitmap;
                ImageWatchViewModel.UpdateResult();
            });
        }

        public void UpdateUIByteImage(byte[] imageData, int width, int height, int channels)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                ImageWatchViewModel.MainImage = ByteArrayToBitmapSource(imageData, width, height, channels);
                ImageWatchViewModel.UpdateResult();
            });
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
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                ImageWatchViewModel.Scale = 1;
                ImageWatchViewModel.TranslationX = 0;
                ImageWatchViewModel.TranslationY = 0;
            });
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
    }
}
