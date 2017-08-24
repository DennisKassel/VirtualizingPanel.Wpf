using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace VirtualizingPanel.Wpf
{
    public static class DependencyObjectExtensions
    {
        public static T FindChild<T>(this DependencyObject dependencyObject)
            where T : DependencyObject
        {
            if (dependencyObject == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                var child = VisualTreeHelper.GetChild(dependencyObject, i);

                var result = (child as T) ?? FindChild<T>(child);
                if (result != null) return result;
            }
            return null;
        }
    }
}
