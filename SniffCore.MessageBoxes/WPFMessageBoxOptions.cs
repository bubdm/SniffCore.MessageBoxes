//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Hols all available additional <see cref="WPFMessageBox" /> options.
    /// </summary>
    public class WPFMessageBoxOptions
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WPFMessageBoxOptions" /> class.
        /// </summary>
        public WPFMessageBoxOptions()
        {
            WindowOptions = new WindowOptionsContainer();
            Styles = new StylesContainer();

            MessageCopyFormatter = new DefaultMessageCopyFormatter();
            Strings = new MessageBoxStrings();

            ShowHelpButton = false;
            HelpRequestCallback = null;
            ShowYesToAllButton = false;
            ShowNoToAllButton = false;
            ShowDoNotShowAgainCheckBox = false;
            IsDoNotShowAgainChecked = false;
            ShowDetails = false;
            DetailsContent = null;
            CustomItem = null;
            BackgroundControl = null;
        }

        /// <summary>
        ///     Gets or sets the message copy formatter to be called if the user pressed Ctrl+C with the Box open.
        /// </summary>
        public IMessageCopyFormatter MessageCopyFormatter { get; set; }

        /// <summary>
        ///     Gets or sets all strings to be used in the WPFMessageBox buttons.
        /// </summary>
        public MessageBoxStrings Strings { get; set; }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a help button or not.
        /// </summary>
        public bool ShowHelpButton { get; set; }

        /// <summary>
        ///     Gets or sets the callback to be invoked after pressing the Help button.
        /// </summary>
        public Action HelpRequestCallback { get; set; }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a 'Yes To All' button.
        /// </summary>
        public bool ShowYesToAllButton { get; set; }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a 'No To All' button.
        /// </summary>
        public bool ShowNoToAllButton { get; set; }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a details button.
        /// </summary>
        public bool ShowDetails { get; set; }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a 'Do Not Show Again' checkbox.
        /// </summary>
        public bool ShowDoNotShowAgainCheckBox { get; set; }

        /// <summary>
        ///     Gets or sets a value which indicates if the 'Do Not Show Again' is checked on start and the check state after close
        ///     the WPFMessageBox.
        /// </summary>
        public bool IsDoNotShowAgainChecked { get; set; }

        /// <summary>
        ///     Gets or sets the content to be shown in the details area.
        /// </summary>
        public object DetailsContent { get; set; }

        /// <summary>
        ///     Gets or sets a additional control which gets shown between the details and normal buttons.
        /// </summary>
        public object CustomItem { get; set; }

        /// <summary>
        ///     Gets or sets a control which is in the background of the main area of the WPFMessageBox.
        /// </summary>
        public object BackgroundControl { get; set; }

        /// <summary>
        ///     Holds all properties which affects the WPFMessageBox window itself.
        /// </summary>
        public WindowOptionsContainer WindowOptions { get; }

        /// <summary>
        ///     Holds all properties for styling all UI elements.
        /// </summary>
        public StylesContainer Styles { get; }

        /// <summary>
        ///     Holds all properties for styling all UI elements.
        /// </summary>
        public class WindowOptionsContainer
        {
            internal WindowOptionsContainer()
            {
                ShowSystemMenu = false;
                Icon = null;
                StartupLocation = WindowStartupLocation.CenterOwner;
                ShowInTaskbar = false;
                ResizeMode = ResizeMode.NoResize;
                Position = new Point();
                MinWidth = 249;
                MaxWidth = 494;
                MinHeight = 172;
                MaxHeight = double.PositiveInfinity;
                DetailedMinWidth = 249;
                DetailedMaxWidth = 494;
                DetailedMinHeight = 350;
                DetailedMaxHeight = double.PositiveInfinity;
                DetailedResizeMode = ResizeMode.NoResize;
            }

            /// <summary>
            ///     Gets or sets a value which indicates of the window has a system menu and icon.
            /// </summary>
            [DefaultValue(false)]
            public bool ShowSystemMenu { get; set; }

            /// <summary>
            ///     Gets or sets the icon to be used.
            /// </summary>
            [DefaultValue(null)]
            public ImageSource Icon { get; set; }

            /// <summary>
            ///     Gets or sets the startup location of the window.
            /// </summary>
            [DefaultValue(WindowStartupLocation.CenterOwner)]
            public WindowStartupLocation StartupLocation { get; set; }

            /// <summary>
            ///     Gets or sets a value which indicates if the window is shown in the task bar.
            /// </summary>
            [DefaultValue(false)]
            public bool ShowInTaskbar { get; set; }

            /// <summary>
            ///     Gets or sets a value which indicates if and how the window can be resized if the details are closed.
            /// </summary>
            [DefaultValue(ResizeMode.NoResize)]
            public ResizeMode ResizeMode { get; set; }

            /// <summary>
            ///     Gets or sets the position of the WPFMessageBox.
            /// </summary>
            public Point Position { get; set; }

            /// <summary>
            ///     Gets or sets the minimum width of the WPFMessageBox if details are closed.
            /// </summary>
            [DefaultValue(249)]
            public double MinWidth { get; set; }

            /// <summary>
            ///     Gets or sets the maximum width of the WPFMessageBox if details are closed.
            /// </summary>
            [DefaultValue(494)]
            public double MaxWidth { get; set; }

            /// <summary>
            ///     Gets or sets the minimum height of the WPFMessageBox if details are closed.
            /// </summary>
            [DefaultValue(172)]
            public double MinHeight { get; set; }

            /// <summary>
            ///     Gets or sets the maximum height of the WPFMessageBox if details are closed.
            /// </summary>
            [DefaultValue(double.PositiveInfinity)]
            public double MaxHeight { get; set; }

            /// <summary>
            ///     Gets or sets the minimum width of the WPFMessageBox if details are open.
            /// </summary>
            [DefaultValue(249)]
            public double DetailedMinWidth { get; set; }

            /// <summary>
            ///     Gets or sets the maximum width of the WPFMessageBox if details are open.
            /// </summary>
            [DefaultValue(494)]
            public double DetailedMaxWidth { get; set; }

            /// <summary>
            ///     Gets or sets the minimum height of the WPFMessageBox if details are open.
            /// </summary>
            [DefaultValue(350)]
            public double DetailedMinHeight { get; set; }

            /// <summary>
            ///     Gets or sets the maximum height of the WPFMessageBox if details are open.
            /// </summary>
            [DefaultValue(double.PositiveInfinity)]
            public double DetailedMaxHeight { get; set; }

            /// <summary>
            ///     Gets or sets a value which indicates if and how the window can be resized if the details are open.
            /// </summary>
            [DefaultValue(ResizeMode.NoResize)]
            public ResizeMode DetailedResizeMode { get; set; }
        }

        /// <summary>
        ///     Holds all properties for styling all UI elements.
        /// </summary>
        public class StylesContainer
        {
            internal StylesContainer()
            {
                ImageControlStyle = null;
                ScrollViewerControlStyle = null;
                TextControlStyle = null;
                ButtonsPanelStyle = null;
                ButtonControlStyle = null;
                CheckBoxControlStyle = null;
                DetailsButtonControlStyle = null;
                DetailsPresenterStyle = null;
            }

            /// <summary>
            ///     Gets or sets the style to be used in the <see cref="WPFMessageBoxImage" />.
            /// </summary>
            public Style ImageControlStyle { get; set; }

            /// <summary>
            ///     Gets or sets the style to be used in the <see cref="WPFMessageBoxScrollViewer" />.
            /// </summary>
            public Style ScrollViewerControlStyle { get; set; }

            /// <summary>
            ///     Gets or sets the style to be used in the <see cref="WPFMessageBoxText" />.
            /// </summary>
            public Style TextControlStyle { get; set; }

            /// <summary>
            ///     Gets or sets the style to be used in the <see cref="WPFMessageBoxButtonsPanel" />.
            /// </summary>
            public Style ButtonsPanelStyle { get; set; }

            /// <summary>
            ///     Gets or sets the style to be used in the <see cref="WPFMessageBoxButtonControl" />.
            /// </summary>
            public Style ButtonControlStyle { get; set; }

            /// <summary>
            ///     Gets or sets the style to be used in the <see cref="WPFMessageBoxCheckBox" />.
            /// </summary>
            public Style CheckBoxControlStyle { get; set; }

            /// <summary>
            ///     Gets or sets the style to be used in the <see cref="WPFMessageBoxDetailsButton" />.
            /// </summary>
            public Style DetailsButtonControlStyle { get; set; }

            /// <summary>
            ///     Gets or sets the style to be used in the <see cref="WPFMessageBoxDetailsPresenter" />.
            /// </summary>
            public Style DetailsPresenterStyle { get; set; }
        }
    }
}