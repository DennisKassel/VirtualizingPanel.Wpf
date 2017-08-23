using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace VirtualizingPanel.Wpf
{
    public class VirtualizingTilePanel : Panel, IScrollInfo
    {
        private Size extent;
        private Size viewport;
        private Point offset;
        private ScrollViewer scrollOwner;
        private TranslateTransform transform = new TranslateTransform();

        public bool CanVerticallyScroll { get; set; } = true;

        public bool CanHorizontallyScroll { get; set; }

        public double ExtentWidth
        {
            get { return this.extent.Width; }
        }

        public double ExtentHeight
        {
            get { return this.extent.Height; }
        }

        public double ViewportWidth
        {
            get { return this.viewport.Width; }
        }

        public double ViewportHeight
        {
            get { return this.viewport.Height; }
        }

        public double HorizontalOffset
        {
            get { return this.offset.X; }
        }

        public double VerticalOffset
        {
            get { return this.offset.Y; }
        }

        public ScrollViewer ScrollOwner
        {
            get { return this.scrollOwner; }
            set { this.scrollOwner = value; }
        }

        public VirtualizingTilePanel()
        {
            this.RenderTransform = this.transform;
        }
        public void LineDown()
        {
            double childHeight = (this.viewport.Height * 2) / this.InternalChildren.Count;

            this.SetVerticalOffset(this.VerticalOffset + childHeight / 2);
        }

        public void LineLeft()
        {
            throw new NotImplementedException();
        }

        public void LineRight()
        {
            throw new NotImplementedException();
        }

        public void LineUp()
        {
            double childHeight = (this.viewport.Height * 2) / this.InternalChildren.Count;

            this.SetVerticalOffset(this.VerticalOffset - childHeight / 2);
        }

        public Rect MakeVisible(Visual visual, Rect rectangle)
        {
            throw new NotImplementedException();
        }

        public void MouseWheelDown()
        {
            this.SetVerticalOffset(this.VerticalOffset + 10);
        }

        public void MouseWheelLeft()
        {
            throw new NotImplementedException();
        }

        public void MouseWheelRight()
        {
            throw new NotImplementedException();
        }

        public void MouseWheelUp()
        {
            this.SetVerticalOffset(this.VerticalOffset - 10);
        }

        public void PageDown()
        {
            double childHeight = (this.viewport.Height * 2) / this.InternalChildren.Count;

            this.SetVerticalOffset(this.VerticalOffset + childHeight);
        }

        public void PageLeft()
        {
            throw new NotImplementedException();
        }

        public void PageRight()
        {
            throw new NotImplementedException();
        }

        public void PageUp()
        {
            double childHeight = (this.viewport.Height * 2) / this.InternalChildren.Count;

            this.SetVerticalOffset(this.VerticalOffset - childHeight);
        }

        public void SetHorizontalOffset(double offset)
        {

        }

        public void SetVerticalOffset(double offset)
        {
            if (offset < 0 || this.viewport.Height >= this.extent.Height)
            {
                offset = 0;
            }
            else
            {
                if (offset + this.viewport.Height >= this.extent.Height)
                {
                    offset = this.extent.Height - this.viewport.Height;
                }
            }

            this.offset.Y = offset;

            if (this.scrollOwner != null)
                this.scrollOwner.InvalidateScrollInfo();

            this.transform.Y = -offset;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var itemsControl = ItemsControl.GetItemsOwner(this);
            var generator = itemsControl.ItemContainerGenerator;

            var childSize = new Size(availableSize.Width / 2, availableSize.Height * 2 / this.InternalChildren.Count);
            Size extent = new Size(availableSize.Width, childSize.Height * this.InternalChildren.Count);

            if (extent != this.extent)
            {
                this.extent = extent;

                if (this.scrollOwner != null)
                    this.scrollOwner.InvalidateScrollInfo();
            }

            if (availableSize != this.viewport)
            {
                this.viewport = availableSize;

                if (this.scrollOwner != null)
                    this.scrollOwner.InvalidateScrollInfo();
            }

            foreach (UIElement child in this.InternalChildren)
            {
                child.Measure(childSize);
            }

            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var childSize = new Size(finalSize.Width / 2, finalSize.Height * 2 / this.InternalChildren.Count);
            Size extent = new Size(finalSize.Width, childSize.Height * this.InternalChildren.Count);

            if (extent != this.extent)
            {
                this.extent = extent;

                if (this.scrollOwner != null)
                    this.scrollOwner.InvalidateScrollInfo();
            }

            if (finalSize != this.viewport)
            {
                this.viewport = finalSize;

                if (this.scrollOwner != null)
                    this.scrollOwner.InvalidateScrollInfo();
            }

            for (int i = 0; i < this.InternalChildren.Count; i++)
            {
                this.InternalChildren[i].Arrange(new Rect(i % 2 == 1 ? 0 : childSize.Width, childSize.Height * i, childSize.Width, childSize.Height));
            }

            return finalSize;
        }
    }
}
