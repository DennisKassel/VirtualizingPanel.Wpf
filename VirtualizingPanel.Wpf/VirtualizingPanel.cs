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
    public class VirtualizingPanel : IScrollInfo
    {
        public bool CanVerticallyScroll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanHorizontallyScroll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double ExtentWidth => throw new NotImplementedException();

        public double ExtentHeight => throw new NotImplementedException();

        public double ViewportWidth => throw new NotImplementedException();

        public double ViewportHeight => throw new NotImplementedException();

        public double HorizontalOffset => throw new NotImplementedException();

        public double VerticalOffset => throw new NotImplementedException();

        public ScrollViewer ScrollOwner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void LineDown()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Rect MakeVisible(Visual visual, Rect rectangle)
        {
            throw new NotImplementedException();
        }

        public void MouseWheelDown()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void PageDown()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void SetHorizontalOffset(double offset)
        {
            throw new NotImplementedException();
        }

        public void SetVerticalOffset(double offset)
        {
            throw new NotImplementedException();
        }
    }
}
