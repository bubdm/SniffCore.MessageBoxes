//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Holds the details content shown if details in the <see cref="WPFMessageBox" /> are expanded.
    /// </summary>
    public class WPFMessageBoxDetailsPresenter : ContentControl
    {
        /// <summary>
        ///     Identifies the <see cref="IsDetailsExpanded" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsDetailsExpandedProperty =
            DependencyProperty.Register("IsDetailsExpanded", typeof(bool), typeof(WPFMessageBoxDetailsPresenter), new UIPropertyMetadata(false));

        static WPFMessageBoxDetailsPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxDetailsPresenter), new FrameworkPropertyMetadata(typeof(WPFMessageBoxDetailsPresenter)));
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the details are visible or not.
        /// </summary>
        [DefaultValue(false)]
        public bool IsDetailsExpanded
        {
            get => (bool) GetValue(IsDetailsExpandedProperty);
            set => SetValue(IsDetailsExpandedProperty, value);
        }
    }
}