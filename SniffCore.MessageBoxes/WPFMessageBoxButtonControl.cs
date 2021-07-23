//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;
using System.Windows.Controls;

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Represents a button used in the <see cref="WPFMessageBox" />.
    /// </summary>
    public class WPFMessageBoxButtonControl : Button
    {
        static WPFMessageBoxButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxButtonControl), new FrameworkPropertyMetadata(typeof(WPFMessageBoxButtonControl)));
        }
    }
}