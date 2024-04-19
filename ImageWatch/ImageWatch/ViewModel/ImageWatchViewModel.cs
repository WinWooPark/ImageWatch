using CommunityToolkit.Mvvm.ComponentModel;
using ImageWatch.Model.DrawObject;
using ImageWatch.ManagementSystem;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Channels;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace ImageWatch.ViewModel
{
    public class ImageWatchViewModel : ObservableObject
    {
        private MainSystem _mainSystem = null;
        public MainSystem MainSystem 
        {
            get { return _mainSystem;}
            set { _mainSystem = value; }
        }

        public ImageWatchViewModel(MainSystem MainSystem)
        {
            _mainSystem = MainSystem;
            _drawEllipse = new ObservableCollection<DrawEllipse>();
            _drawLine = new ObservableCollection<DrawLine>();
            _drawRect = new ObservableCollection<DrawRect>();
        }

        BitmapSource _mainImage;
        public BitmapSource MainImage
        {
            get { return _mainImage; }
            set
            {
                if (_mainImage != value)
                {
                    _mainImage = value;
                    OnPropertyChanged(nameof(MainImage));
                }
            }
        }

        public double Scale
        {
            get { return _mainSystem.Scale; }
            set
            {
                _mainSystem.Scale = value;
                OnPropertyChanged(nameof(Scale));

                _mainSystem.CalShift(_mainSystem.Scale);
                DeleteResult();
                UpdateResult();   
            }
        }
        
        int _delta;
        public int Delta
        {
            get { return _delta; }
            set
            {
                _delta = value;
                OnPropertyChanged(nameof(Delta));
                _mainSystem.ImageScaleChange(_delta);
            }
        }

        public double CenterPointX
        {
            get { return _mainSystem.CenterPointX; }
            set
            {
                if (_mainSystem.CenterPointX != value)
                {
                    _mainSystem.CenterPointX = value;
                    OnPropertyChanged(nameof(CenterPointX));
                }
            }
        }

        public double CenterPointY
        {
            get { return _mainSystem.CenterPointY; }
            set
            {
                if (_mainSystem.CenterPointY != value)
                {
                    _mainSystem.CenterPointY = value;
                    OnPropertyChanged(nameof(CenterPointY));
                }
            }
        }

        double _mouseMoveX;
        public double MouseMoveX 
        {
            get { return _mouseMoveX; }
            set 
            {
                _mouseMoveX = value;
                _mainSystem.ImageTranslationChange(_mouseMoveX, _mouseMoveY);
            }
        }

        double _mouseMoveY;
        public double MouseMoveY
        {
            get { return _mouseMoveY; }
            set
            {
                _mouseMoveY = value;
                _mainSystem.ImageTranslationChange(_mouseMoveX, _mouseMoveY);
            }
        }

        public double TranslationX
        {
            get { return _mainSystem.TranslationX; }
            set
            {
                _mainSystem.TranslationX = value;
                OnPropertyChanged(nameof(TranslationX));
                DeleteResult();
                UpdateResult();
            }
        }

        public double TranslationY
        {
            get { return _mainSystem.TranslationY; }
            set
            {
                _mainSystem.TranslationY = value;
                OnPropertyChanged(nameof(TranslationY));
                DeleteResult();
                UpdateResult();
            }
        }

        public double CanvasWidth
        {
            get { return _mainSystem.ImageControlWidth; }
            set
            {
                if (_mainSystem.CanvasControlWidth != value)
                {
                    _mainSystem.CanvasControlWidth = value;
                    OnPropertyChanged(nameof(CanvasWidth));
                }
            }
        }

        public double CanvasHeight
        {
            get { return _mainSystem.CanvasControlHeight; }
            set
            {
                if (_mainSystem.CanvasControlHeight != value)
                {
                    _mainSystem.CanvasControlHeight = value;
                    OnPropertyChanged(nameof(CanvasHeight));
                }
            }
        }

        public double GridWidth
        {
            get { return _mainSystem.GridControlWidth; }
            set
            {
                if (_mainSystem.GridControlWidth != value)
                {
                    _mainSystem.GridControlWidth = value;
                    OnPropertyChanged(nameof(GridWidth));
                    _mainSystem.CalRatio();
                }
            }
        }

        public double GridHeight
        {
            get { return _mainSystem.GridControlHeight; }
            set
            {
                if (_mainSystem.GridControlHeight != value)
                {
                    _mainSystem.GridControlHeight = value;
                    OnPropertyChanged(nameof(GridHeight));
                    _mainSystem.CalRatio();
                }
            }
        }

        public double GridCenterPointX
        {
            get { return _mainSystem.GridCenterPointX; }
            set
            {
                if (_mainSystem.GridCenterPointX != value)
                {
                    _mainSystem.GridCenterPointX = value;
                    OnPropertyChanged(nameof(GridCenterPointX));
                    
                }
            }
        }

        public double GridCenterPointY
        {
            get { return _mainSystem.GridCenterPointY; }
            set
            {
                if (_mainSystem.GridCenterPointY != value)
                {
                    _mainSystem.GridCenterPointY = value;
                    OnPropertyChanged(nameof(GridCenterPointY));
                    
                }
            }
        }

        public double RMouseDownX
        {
            get { return _mainSystem.MouseDownX; }
            set
            {
                if (_mainSystem.MouseDownX != value)
                {
                    _mainSystem.MouseDownX = value;
                    OnPropertyChanged(nameof(RMouseDownX));

                }
            }
        }

        public double RMouseDownY
        {
            get { return _mainSystem.MouseDownY; }
            set
            {
                if (_mainSystem.MouseDownY != value)
                {
                    _mainSystem.MouseDownY = value;
                    OnPropertyChanged(nameof(RMouseDownY));

                }
            }
        }

        public double RMouseUpX
        {
            get { return _mainSystem.MouseUpX; }
            set
            {
                if (_mainSystem.MouseUpX != value)
                {
                    _mainSystem.MouseUpX = value;
                    OnPropertyChanged(nameof(RMouseUpX));
                    _mainSystem.RightMouseButtomEvent();
                }
            }
        }

        public double RMouseUpY
        {
            get { return _mainSystem.MouseUpY; }
            set
            {
                if (_mainSystem.MouseUpY != value)
                {
                    _mainSystem.MouseUpY = value;
                    OnPropertyChanged(nameof(RMouseUpY));
                    _mainSystem.RightMouseButtomEvent();
                }
            }
        }

        private ObservableCollection<DrawEllipse> _drawEllipse;
        public ObservableCollection<DrawEllipse> DrawEllipses
        {
            get { return _drawEllipse; }
            set
            {
                _drawEllipse = value;
                OnPropertyChanged(nameof(DrawEllipses));   
            }
        }

        private ObservableCollection<DrawLine> _drawLine;
        public ObservableCollection<DrawLine> DrawLine
        {
            get { return _drawLine; }
            set
            {
                _drawLine = value;
                OnPropertyChanged(nameof(DrawLine));
            }
        }

        private ObservableCollection<DrawRect> _drawRect;
        public ObservableCollection<DrawRect> DrawRect
        {
            get { return _drawRect; }
            set
            {
                _drawRect = value;
                OnPropertyChanged(nameof(DrawRect));
            }
        }

        public void UpdateImage(BitmapSource mainImage) 
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                MainImage = mainImage;
            });
        }

        public void UpdateImage(byte[] imageData, int width, int height, int channels)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                MainImage = _mainSystem.ByteArrayToBitmapSource(imageData, width, height, channels);
            });
        }

        public void UpdateResult()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                UpdateEllipseResult();
                UpdateLineResult();
                UpdateRectResult();
            });
        }

        public void DeleteResult()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                if(DrawEllipses.Count != 0)
                    DrawEllipses.Clear();

                if (DrawLine.Count != 0)
                    DrawLine.Clear();

                if (DrawRect.Count != 0)
                    DrawRect.Clear();
            });
        }

        void UpdateEllipseResult()
        {
            Queue<DrawEllipse> obj = _mainSystem.DrawObj.drawEllipses;

            foreach (DrawEllipse drawEllipse in obj)
            {
                DrawEllipse draw = drawEllipse.Clone();
                draw.UpdatePosition(Scale, _mainSystem.ShiftWidth, _mainSystem.ShiftHeight, TranslationX, TranslationY);
                DrawEllipses.Add(draw);
            }
        }

        void UpdateLineResult()
        {
            Queue<DrawLine> obj = _mainSystem.DrawObj.drawLines;

            foreach (DrawLine drawLines in obj) 
            {
                DrawLine draw = drawLines.Clone();
                draw.UpdatePosition(Scale, _mainSystem.ShiftWidth, _mainSystem.ShiftHeight, TranslationX, TranslationY);
                DrawLine.Add(draw);
            }
        }

        void UpdateRectResult()
        {
            Queue<DrawRect> obj = _mainSystem.DrawObj.drawRects;

            foreach (DrawRect drawRects in obj)
            {
                DrawRect draw = drawRects.Clone();
                draw.UpdatePosition(Scale, _mainSystem.ShiftWidth, _mainSystem.ShiftHeight, TranslationX, TranslationY);
                DrawRect.Add(draw);
            }
        }
    }
}
