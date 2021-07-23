//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;
using System.Windows.Controls;

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Represents the CheckBox used in the WPFMessageBox.
    /// </summary>
    public class WPFMessageBoxCheckBox : CheckBox
    {
        static WPFMessageBoxCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxCheckBox), new FrameworkPropertyMetadata(typeof(WPFMessageBoxCheckBox)));
        }
    }
}