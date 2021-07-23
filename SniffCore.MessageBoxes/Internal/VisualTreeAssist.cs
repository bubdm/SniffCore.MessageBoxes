//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace SniffCore.MessageBoxes.Internal
{
    internal static class VisualTreeAssist
    {
        internal static List<TChildType> GetChildren<TChildType>(DependencyObject item) where TChildType : DependencyObject
        {
            var children = new List<TChildType>();
            GetChildren(item, children);
            return children;
        }

        private static void GetChildren<TChildType>(DependencyObject item, ICollection<TChildType> target) where TChildType : DependencyObject
        {
            if (item == null)
                return;

            var childrenCount = VisualTreeHelper.GetChildrenCount(item);
            for (var i = 0; i < childrenCount; ++i)
            {
                var child = VisualTreeHelper.GetChild(item, i);
                if (child is TChildType childType)
                    target.Add(childType);
                GetChildren(child, target);
            }
        }
    }
}