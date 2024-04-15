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
        bool _isMouseMove;

        static  MouseEventBehavior()
        {
            MouseMoveXProperty = DependencyProperty.RegisterAttached("MouseMoveX", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            MouseMoveYProperty = DependencyProperty.RegisterAttached("MouseMoveY", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            MouseWheelProperty = DependencyProperty.RegisterAttached("MouseWheel", typeof(double), typeof(MouseEventBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
        }

        public static readonly DependencyProperty MouseMoveXProperty;


        public static readonly DependencyProperty MouseMoveYProperty;


        public static readonly DependencyProperty MouseWheelProperty;
           

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


        public MouseEventBehavior()
        {
            _isMouseMove = false;
        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLButtomDown;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLButtomUp;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }


        protected override void OnDetaching()
        {
            AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLButtomDown;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLButtomUp;
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            MouseWheel = e.Delta;
        }

        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isMouseMove == true)
            {
                _currentPoint = e.GetPosition(e.OriginalSource as IInputElement);

                double offsetX = (_currentPoint.X - _startPoint.X);
                double offsetY = (_currentPoint.Y - _startPoint.Y);
                
                MouseMoveX = offsetX;
                MouseMoveY = offsetY;

                _startPoint = _currentPoint;
            }
        }

        private void AssociatedObject_MouseLButtomDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(e.OriginalSource as IInputElement);
            _isMouseMove = true;
        }

        private void AssociatedObject_MouseLButtomUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isMouseMove = false;
        }
    }
}
