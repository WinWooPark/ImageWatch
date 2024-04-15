using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows;
using ImageWatch.ManagementSystem;
using ImageWatch.ViewModel;

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

            ImageCenterX = AssociatedObject.ActualWidth /2;

            ImageCenterY = AssociatedObject.ActualHeight /2;
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
