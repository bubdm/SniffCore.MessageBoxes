//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;
using System.Windows.Controls;

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Represents the ScrollViewer used in the <see cref="WPFMessageBox" />.
    /// </summary>
    public class WPFMessageBoxScrollViewer : ScrollViewer
    {
        static WPFMessageBoxScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxScrollViewer), new FrameworkPropertyMetadata(typeof(WPFMessageBoxScrollViewer)));
        }
    }
}