//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;
using System.Windows.Controls;

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Represents the text block used in the WPFMessageBox.
    /// </summary>
    public class WPFMessageBoxText : ContentControl
    {
        static WPFMessageBoxText()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxText), new FrameworkPropertyMetadata(typeof(WPFMessageBoxText)));
        }
    }
}