using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows;
using ImageWatch.ManagementSystem;
using ImageWatch.ViewModel;
using System.Windows.Input;

namespace ImageWatch.Behaviors
{
    public class ImageSizeBehavior : Behavior<Image>
    {
        static ImageSizeBehavior()
        {
            ImageWidthProperty = DependencyProperty.RegisterAttached("ImageWidth", typeof(double), typeof(ImageSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            ImageHeightProperty =  DependencyProperty.RegisterAttached("ImageHeight", typeof(double), typeof(ImageSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            ImageCenterXProperty = DependencyProperty.RegisterAttached("ImageCenterX", typeof(double), typeof(ImageSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            ImageCenterYProperty = DependencyProperty.RegisterAttached("ImageCenterY", typeof(double), typeof(ImageSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

        }

        public static readonly DependencyProperty ImageWidthProperty;

        public static readonly DependencyProperty ImageHeightProperty;

        public static readonly DependencyProperty ImageCenterXProperty;

        public static readonly DependencyProperty ImageCenterYProperty;
          
        public double ImageWidth 
        { 
            get 
            {
                return (double)base.GetValue(ImageWidthProperty); 
            } 
            set 
            {
                base.SetValue(ImageWidthProperty, value); 
            } 
        }

        public double ImageHeight
        {
            get
            {
                return (double)base.GetValue(ImageHeightProperty);
            }
            set
            {
                base.SetValue(ImageHeightProperty, value);
            }
        }

        public double ImageCenterX
        {
            get
            {
                return (double)base.GetValue(ImageCenterXProperty);
            }
            set
            {
                base.SetValue(ImageCenterXProperty, value);
            }
        }

        public double ImageCenterY
        {
            get
            {
                return (double)base.GetValue(ImageCenterYProperty);
            }
            set
            {
                base.SetValue(ImageCenterYProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SizeChanged += OnSizeChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ImageWidth = AssociatedObject.ActualWidth;

            ImageHeight = AssociatedObject.ActualHeight;

            ImageCenterX = AssociatedObject.ActualWidth / 2;

            ImageCenterY = AssociatedObject.ActualHeight / 2;
        }
    }

    public class GridSizeBehavior : Behavior<Grid>
    {
        static GridSizeBehavior()
        {
            GridWidthProperty = DependencyProperty.RegisterAttached("GridWidth", typeof(double), typeof(GridSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            GridHeightProperty = DependencyProperty.RegisterAttached("GridHeight", typeof(double), typeof(GridSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            GridCenterXProperty = DependencyProperty.RegisterAttached("GridCenterX", typeof(double), typeof(GridSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
            GridCenterYProperty = DependencyProperty.RegisterAttached("GridCenterY", typeof(double), typeof(GridSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

        }

        public static readonly DependencyProperty GridWidthProperty;

        public static readonly DependencyProperty GridHeightProperty;

        public static readonly DependencyProperty GridCenterXProperty;

        public static readonly DependencyProperty GridCenterYProperty;

        public double GridWidth
        {
            get
            {
                return (double)base.GetValue(GridWidthProperty);
            }
            set
            {
                base.SetValue(GridWidthProperty, value);
            }
        }

        public double GridHeight
        {
            get
            {
                return (double)base.GetValue(GridHeightProperty);
            }
            set
            {
                base.SetValue(GridHeightProperty, value);
            }
        }

        public double GridCenterX
        {
            get
            {
                return (double)base.GetValue(GridCenterXProperty);
            }
            set
            {
                base.SetValue(GridCenterXProperty, value);
            }
        }

        public double GridCenterY
        {
            get
            {
                return (double)base.GetValue(GridCenterYProperty);
            }
            set
            {
                base.SetValue(GridCenterYProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SizeChanged += OnSizeChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            GridWidth = AssociatedObject.ActualWidth;

            GridHeight = AssociatedObject.ActualHeight;

            //GridCenterX = AssociatedObject.ActualWidth / 2;

            //GridCenterY = AssociatedObject.ActualHeight / 2;
        }
    }

    public class CanvasSizeBehavior : Behavior<Canvas>
    {
        public static readonly DependencyProperty CanvasWidthProperty =
             DependencyProperty.RegisterAttached("CanvasWidth", typeof(double), typeof(CanvasSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty CanvasHeightProperty =
            DependencyProperty.RegisterAttached("CanvasHeight", typeof(double), typeof(CanvasSizeBehavior), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public double CanvasWidth
        {
            get
            {
                return (double)base.GetValue(CanvasWidthProperty);
            }
            set
            {
                base.SetValue(CanvasWidthProperty, value);
            }
        }

        public double CanvasHeight
        {
            get
            {
                return (double)base.GetValue(CanvasHeightProperty);
            }
            set
            {
                base.SetValue(CanvasHeightProperty, value);
            }
        }

        protected override void OnAttached()
        {
            AssociatedObject.SizeChanged += OnSizeChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            CanvasWidth = AssociatedObject.ActualWidth;
            CanvasHeight = AssociatedObject.ActualHeight;
        }
    }
}
