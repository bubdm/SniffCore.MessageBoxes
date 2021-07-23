//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SniffCore.MessageBoxes.Internal;

// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Show a WPF window as a message box which is full configurable.
    /// </summary>
    /// <example>
    ///     <code lang="csharp">
    /// <![CDATA[
    /// public void Show1()
    /// {
    ///     WPFMessageBox.Show("Messagebox Text");
    /// }
    /// 
    /// public void Show2()
    /// {
    ///     WPFMessageBox.Show("Messagebox Text", "Caption");
    /// }
    /// 
    /// public void Show3()
    /// {
    ///     WPFMessageBox.Show("Messagebox Text", "Caption", WPFMessageBoxButtons.AbortRetryIgnore);
    /// }
    /// 
    /// public void Show4()
    /// {
    ///     var options = new WPFMessageBoxOptions();
    ///     options.DetailsContent = new Label();
    ///     options.ShowDetails = true;
    ///     options.ShowHelpButton = true;
    ///     options.Strings.Abort = "Go Away";
    ///     options.WindowOptions.DetailedResizeMode = ResizeMode.CanResizeWithGrip;
    /// 
    ///     WPFMessageBox.Show("Messagebox Text",
    ///                        "Caption",
    ///                        WPFMessageBoxButtons.AbortRetryIgnore,
    ///                        WPFMessageBoxImages.Error,
    ///                        WPFMessageBoxResult.Retry, options);
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public partial class WPFMessageBox : INotifyPropertyChanged
    {
        private bool _closeByButtons;
        private Size _oldMaxSize;

        private Size _oldMinSize;
        private Size _oldSize;

        internal WPFMessageBox()
        {
            InitializeComponent();
            DataContext = this;

            Loaded += HandleLoaded;

            AddHandler(WPFMessageBoxButtonsPanel.ClickEvent, (RoutedEventHandler) OnButtonClick);
            AddHandler(WPFMessageBoxButtonsPanel.HelpRequestEvent, (RoutedEventHandler) OnHelpRequestClick);
            AddHandler(WPFMessageBoxButtonsPanel.ExpandDetailsEvent, (RoutedEventHandler) OnExpandDetailsClick);
        }

        /// <summary>
        ///     Gets or sets a value which indicates of the details are shown or not
        /// </summary>
        public bool IsDetailsExpanded { get; set; }

        /// <summary>
        ///     Gets or sets the message to be show.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the icon to show.
        /// </summary>
        public WPFMessageBoxImages Image { get; set; }

        /// <summary>
        ///     Gets or sets which buttons has to be shown.
        /// </summary>
        public WPFMessageBoxButtons Buttons { get; set; }

        /// <summary>
        ///     Gets or sets which button is the default button after showing the WPFMessageBox.
        /// </summary>
        public WPFMessageBoxResult DefaultButton { get; set; }

        /// <summary>
        ///     Gets or sets the result how the user closed the WPFMessageBox.
        /// </summary>
        public WPFMessageBoxResult Result { get; set; }

        /// <summary>
        ///     Gets or sets the additional WPFMessageBox options.
        /// </summary>
        public WPFMessageBoxOptions Options { get; set; }

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            TryApplyStyle(PART_ImageControl, Options.Styles.ImageControlStyle);
            TryApplyStyle(PART_ScrollViewerControl, Options.Styles.ScrollViewerControlStyle);
            TryApplyStyle(PART_TextControl, Options.Styles.TextControlStyle);
            TryApplyStyle(PART_ButtonPanel, Options.Styles.ButtonsPanelStyle);
            TryApplyStyle(PART_DetailsPresenter, Options.Styles.DetailsPresenterStyle);

            PART_ButtonPanel.TakeStyles(Options.Styles);
        }

        private void TryApplyStyle(FrameworkElement targetElement, Style style)
        {
            if (style != null)
                targetElement.Style = style;
        }

        private void OnExpandDetailsClick(object sender, RoutedEventArgs e)
        {
            IsDetailsExpanded = !IsDetailsExpanded;
            OnPropertyChanged(nameof(IsDetailsExpanded));

            if (IsDetailsExpanded)
            {
                UpperArea.Height = new GridLength(UpperArea.ActualHeight);
                LowerArea.Height = new GridLength(1, GridUnitType.Star);

                _oldMinSize = new Size(MinWidth, MinHeight);
                _oldMaxSize = new Size(MaxWidth, MaxHeight);
                _oldSize = new Size(Width, Height);

                MinWidth = Options.WindowOptions.DetailedMinWidth;
                MaxWidth = Options.WindowOptions.DetailedMaxWidth;
                MinHeight = Options.WindowOptions.DetailedMinHeight;
                MaxHeight = Options.WindowOptions.DetailedMaxHeight;

                ResizeMode = Options.WindowOptions.DetailedResizeMode;
            }
            else
            {
                UpperArea.Height = new GridLength(1, GridUnitType.Star);
                LowerArea.Height = new GridLength(0, GridUnitType.Auto);

                MinWidth = _oldMinSize.Width;
                MaxWidth = _oldMaxSize.Width;
                Width = _oldSize.Width;
                MinHeight = _oldMinSize.Height;
                MaxHeight = _oldMaxSize.Height;
                Height = _oldSize.Height;

                ResizeMode = Options.WindowOptions.ResizeMode;
            }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var panel = (WPFMessageBoxButtonsPanel) e.OriginalSource;
            Result = panel.Result;

            _closeByButtons = true;
            DialogResult = true;
        }

        private void OnHelpRequestClick(object sender, RoutedEventArgs e)
        {
            Options.HelpRequestCallback?.Invoke();
        }

        /// <summary>
        ///     Raises the System.Windows.Window.SourceInitialized event.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            if (!Options.WindowOptions.ShowSystemMenu)
                WindowTitleBar.DisableSystemMenu(this);
            else if (Options.WindowOptions.Icon != null)
                Icon = Options.WindowOptions.Icon;

            if (Options.WindowOptions.ResizeMode == ResizeMode.NoResize)
            {
                WindowTitleBar.DisableMinimizeButton(this);
                WindowTitleBar.DisableMaximizeButton(this);
            }

            if (Buttons == WPFMessageBoxButtons.YesNo || Buttons == WPFMessageBoxButtons.AbortRetryIgnore)
                WindowTitleBar.DisableCloseButton(this);
        }

        /// <summary>
        ///     Raises the System.Windows.Window.ContentRendered event.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected override void OnContentRendered(EventArgs e)
        {
            PART_ButtonPanel.Measure(new Size(double.MaxValue, double.MaxValue));
            var panelWidth = PART_ButtonPanel.DesiredSize.Width;

            if (!double.IsNaN(panelWidth))
            {
                if (panelWidth > MaxWidth)
                    MaxWidth = panelWidth + 40;
                if (panelWidth > Options.WindowOptions.DetailedMaxWidth)
                    Options.WindowOptions.DetailedMaxWidth = panelWidth + 40;
                if (panelWidth > MinWidth)
                    MinWidth = panelWidth + 40;
                if (panelWidth > Options.WindowOptions.DetailedMinWidth)
                    Options.WindowOptions.DetailedMinWidth = panelWidth + 40;
            }

            base.OnContentRendered(e);

            PART_ButtonPanel.SetDefaultButton();
        }

        /// <summary>
        ///     Raises the System.Windows.Window.Closing event.
        /// </summary>
        /// <param name="e">A System.ComponentModel.CancelEventArgs that contains the event data.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!_closeByButtons && (Buttons == WPFMessageBoxButtons.YesNo || Buttons == WPFMessageBoxButtons.AbortRetryIgnore))
                e.Cancel = true;

            base.OnClosing(e);
        }

        /// <summary>
        ///     Invoked when an unhandled System.Windows.Input.Keyboard.PreviewKeyDown attached event reaches an element in its
        ///     route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The System.Windows.Input.KeyEventArgs that contains the event data.</param>
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control && Options.MessageCopyFormatter != null)
                Options.MessageCopyFormatter.Copy(Title, Message, Buttons, Image, Options.Strings);

            if (e.Key != Key.Escape)
                return;

            if (Buttons == WPFMessageBoxButtons.AbortRetryIgnore || Buttons == WPFMessageBoxButtons.YesNo)
                return;

            Close();
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText)
        {
            return Show(null, messageBoxText, string.Empty, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption)
        {
            return Show(null, messageBoxText, caption, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which button or buttons to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons)
        {
            return Show(null, messageBoxText, caption, buttons, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which button or buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon)
        {
            return Show(null, messageBoxText, caption, buttons, icon, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which button or buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="defaultButton">A WPFMessageBoxResult value that specifies the default result of the message box.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton)
        {
            return Show(null, messageBoxText, caption, buttons, icon, defaultButton, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which button or buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="defaultButton">A WPFMessageBoxResult value that specifies the default result of the message box.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton, WPFMessageBoxOptions options)
        {
            return Show(null, messageBoxText, caption, buttons, icon, defaultButton, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText)
        {
            return Show(owner, messageBoxText, string.Empty, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption)
        {
            return Show(owner, messageBoxText, caption, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which button or buttons to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons)
        {
            return Show(owner, messageBoxText, caption, buttons, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which button or buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon)
        {
            return Show(owner, messageBoxText, caption, buttons, icon, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which button or buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="defaultButton">A WPFMessageBoxResult value that specifies the default result of the message box.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton)
        {
            return Show(owner, messageBoxText, caption, buttons, icon, defaultButton, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which button or buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="defaultButton">A WPFMessageBoxResult value that specifies the default result of the message box.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton, WPFMessageBoxOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var box = new WPFMessageBox
            {
                Owner = owner,
                Message = messageBoxText,
                Title = caption ?? string.Empty,
                Buttons = buttons,
                Image = icon,
                DefaultButton = defaultButton,
                Options = options
            };

            SetWindowOptions(box, options.WindowOptions);

            var dialogResult = box.ShowDialog();
            if (dialogResult == true)
                return box.Result;

            return buttons == WPFMessageBoxButtons.OK ? WPFMessageBoxResult.OK : WPFMessageBoxResult.Cancel;
        }

        private static void SetWindowOptions(Window window, WPFMessageBoxOptions.WindowOptionsContainer options)
        {
            window.WindowStartupLocation = options.StartupLocation;
            if (window.Owner == null && options.StartupLocation == WindowStartupLocation.CenterOwner)
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (window.WindowStartupLocation == WindowStartupLocation.Manual)
            {
                window.Left = options.Position.X;
                window.Top = options.Position.Y;
            }

            window.ResizeMode = options.ResizeMode;
            window.ShowInTaskbar = options.ShowInTaskbar;

            window.MinWidth = options.MinWidth;
            window.MaxWidth = options.MaxWidth;
            window.MinHeight = options.MinHeight;
            window.MaxHeight = options.MaxHeight;

            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.SnapsToDevicePixels = true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}