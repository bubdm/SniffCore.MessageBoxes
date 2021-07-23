//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Windows;

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
    ///                        WPFMessageBoxResult.Retry,
    ///                        options);
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public static class WPFMessageBox
    {
        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText)
        {
            return Show(null, messageBoxText, string.Empty, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption)
        {
            return Show(null, messageBoxText, caption, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons)
        {
            return Show(null, messageBoxText, caption, buttons, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon)
        {
            return Show(null, messageBoxText, caption, buttons, icon, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="defaultButton">A WPFMessageBoxResult value that specifies the default result of the message box.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton)
        {
            return Show(null, messageBoxText, caption, buttons, icon, defaultButton, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText)
        {
            return Show(owner, messageBoxText, string.Empty, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption)
        {
            return Show(owner, messageBoxText, caption, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons)
        {
            return Show(owner, messageBoxText, caption, buttons, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon)
        {
            return Show(owner, messageBoxText, caption, buttons, icon, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="defaultButton">A WPFMessageBoxResult value that specifies the default result of the message box.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton)
        {
            return Show(owner, messageBoxText, caption, buttons, icon, defaultButton, new WPFMessageBoxOptions());
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, WPFMessageBoxOptions options)
        {
            return Show(null, messageBoxText, string.Empty, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxOptions options)
        {
            return Show(null, messageBoxText, caption, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxOptions options)
        {
            return Show(null, messageBoxText, caption, buttons, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxOptions options)
        {
            return Show(null, messageBoxText, caption, buttons, icon, WPFMessageBoxResult.OK, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="defaultButton">A WPFMessageBoxResult value that specifies the default result of the message box.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton, WPFMessageBoxOptions options)
        {
            return Show(null, messageBoxText, caption, buttons, icon, defaultButton, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, WPFMessageBoxOptions options)
        {
            return Show(owner, messageBoxText, string.Empty, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxOptions options)
        {
            return Show(owner, messageBoxText, caption, WPFMessageBoxButtons.OK, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxOptions options)
        {
            return Show(owner, messageBoxText, caption, buttons, WPFMessageBoxImages.None, WPFMessageBoxResult.OK, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxOptions options)
        {
            return Show(owner, messageBoxText, caption, buttons, icon, WPFMessageBoxResult.OK, options);
        }

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="defaultButton">A WPFMessageBoxResult value that specifies the default result of the message box.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        /// <exception cref="ArgumentNullException">options is null.</exception>
        public static WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton, WPFMessageBoxOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var box = new WPFMessageBoxWindow
            {
                Owner = owner,
                Message = messageBoxText,
                Title = caption ?? string.Empty,
                Buttons = buttons,
                Image = icon,
                DefaultButton = defaultButton,
                Options = options
            };

            box.SetWindowOptions(box, options.WindowOptions);

            var dialogResult = box.ShowDialog();
            if (dialogResult == true)
                return box.Result;

            return buttons == WPFMessageBoxButtons.OK ? WPFMessageBoxResult.OK : WPFMessageBoxResult.Cancel;
        }
    }
}