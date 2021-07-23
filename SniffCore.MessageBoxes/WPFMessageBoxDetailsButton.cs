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
    ///     Represents the details button shown in the WPFMessageBox.
    /// </summary>
    public class WPFMessageBoxDetailsButton : Expander
    {
        /// <summary>
        ///     Identifies the <see cref="CollapsedHeaderText" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CollapsedHeaderTextProperty =
            DependencyProperty.Register("CollapsedHeaderText", typeof(string), typeof(WPFMessageBoxDetailsButton), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="ExpandedHeaderText" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExpandedHeaderTextProperty =
            DependencyProperty.Register("ExpandedHeaderText", typeof(string), typeof(WPFMessageBoxDetailsButton), new UIPropertyMetadata(null));

        static WPFMessageBoxDetailsButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxDetailsButton), new FrameworkPropertyMetadata(typeof(WPFMessageBoxDetailsButton)));
        }

        /// <summary>
        ///     Gets or sets the text to show on the button if the details are not shown.
        /// </summary>
        [DefaultValue(null)]
        public string CollapsedHeaderText
        {
            get => (string) GetValue(CollapsedHeaderTextProperty);
            set => SetValue(CollapsedHeaderTextProperty, value);
        }

        /// <summary>
        ///     Gets or sets the text to show on the button if the details are shown.
        /// </summary>
        [DefaultValue(null)]
        public string ExpandedHeaderText
        {
            get => (string) GetValue(ExpandedHeaderTextProperty);
            set => SetValue(ExpandedHeaderTextProperty, value);
        }
    }
}