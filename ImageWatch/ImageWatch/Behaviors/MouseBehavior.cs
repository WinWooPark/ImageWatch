using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows;
using ImageWatch.ManagementSystem;
using ImageWatch.Define;
using ImageWatch.ViewModel;


namespace ImageWatch.Behaviors
{
    internal class MouseEventBehavior : Behavior<Image>
    {
        System.Windows.Point _startPoint;
        System.Windows.Point _currentPoint;

        bool _isLMouseMove;

        bool _isRMouseMove;

        static  MouseEventBehavior()
        {
            MouseMoveXProperty = DependencyProperty.RegisterAttached("MouseMoveX", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            MouseMoveYProperty = DependencyProperty.RegisterAttached("MouseMoveY", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            MouseWheelProperty = DependencyProperty.RegisterAttached("MouseWheel", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

            MouseDownXProperty = DependencyProperty.RegisterAttached("MouseDownX", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            MouseDownYProperty = DependencyProperty.RegisterAttached("MouseDownY", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            MouseUpXProperty = DependencyProperty.RegisterAttached("MouseUpX", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            MouseUpYProperty = DependencyProperty.RegisterAttached("MouseUpY", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
        }

        public static readonly DependencyProperty MouseMoveXProperty;

        public static readonly DependencyProperty MouseMoveYProperty;

        public static readonly DependencyProperty MouseWheelProperty;

        public static readonly DependencyProperty MouseDownXProperty;

        public static readonly DependencyProperty MouseDownYProperty;

        public static readonly DependencyProperty MouseUpXProperty;

        public static readonly DependencyProperty MouseUpYProperty;


        public double MouseMoveX
        {
            get
            {
                return (double)base.GetValue(MouseMoveXProperty);
            }
            set
            {
                base.SetValue(MouseMoveXProperty, value);
            }
        }

        public double MouseMoveY
        {
            get
            {
                return (double)base.GetValue(MouseMoveYProperty);
            }
            set
            {
                base.SetValue(MouseMoveYProperty, value);
            }
        }

        public double MouseWheel
        {
            get
            {
                return (double)base.GetValue(MouseWheelProperty);
            }
            set
            {
                base.SetValue(MouseWheelProperty, value);
            }
        }



        public double MouseDownX
        {
            get
            {
                return (double)base.GetValue(MouseDownXProperty);
            }
            set
            {
                base.SetValue(MouseDownXProperty, value);
            }
        }

        public double MouseDownY
        {
            get
            {
                return (double)base.GetValue(MouseDownYProperty);
            }
            set
            {
                base.SetValue(MouseDownYProperty, value);
            }
        }

        public double MouseUpX
        {
            get
            {
                return (double)base.GetValue(MouseUpXProperty);
            }
            set
            {
                base.SetValue(MouseUpXProperty, value);
            }
        }

        public double MouseUpY
        {
            get
            {
                return (double)base.GetValue(MouseUpYProperty);
            }
            set
            {
                base.SetValue(MouseUpYProperty, value);
            }
        }


        public MouseEventBehavior()
        {
            _isLMouseMove = false;
            _isRMouseMove = false;
        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLButtomDown;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLButtomUp;
           
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;

            AssociatedObject.MouseRightButtonDown += AssociatedObject_MouseRButtomDown;
            AssociatedObject.MouseRightButtonUp += AssociatedObject_MouseRButtomUp;
        }


        protected override void OnDetaching()
        {
            AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLButtomDown;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLButtomUp;
            
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;

            AssociatedObject.MouseRightButtonDown -= AssociatedObject_MouseLButtomDown;
            AssociatedObject.MouseRightButtonUp -= AssociatedObject_MouseLButtomUp;
        }

        private void AssociatedObject_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            MouseWheel = e.Delta;
        }

        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isLMouseMove == true)
            {
                _currentPoint = e.GetPosition(e.OriginalSource as IInputElement);

                double offsetX = (_currentPoint.X - _startPoint.X);
                double offsetY = (_currentPoint.Y - _startPoint.Y);
                
                MouseMoveX = offsetX;
                MouseMoveY = offsetY;

                _startPoint = _currentPoint;
            }

            if (_isRMouseMove == true)
            {
                _currentPoint = e.GetPosition(e.OriginalSource as IInputElement);

                MouseUpX = _currentPoint.X;
                MouseUpY = _currentPoint.Y;
            }
        }

        private void AssociatedObject_MouseLButtomDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(e.OriginalSource as IInputElement);
            _isLMouseMove = true;
        }

        private void AssociatedObject_MouseLButtomUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isLMouseMove = false;
        }

        private void AssociatedObject_MouseRButtomDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(e.OriginalSource as IInputElement);

            MouseDownX = _startPoint.X;
            MouseDownY = _startPoint.Y;

            _isRMouseMove = true;
        }

        private void AssociatedObject_MouseRButtomUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isRMouseMove = false;
        }
    }
}
