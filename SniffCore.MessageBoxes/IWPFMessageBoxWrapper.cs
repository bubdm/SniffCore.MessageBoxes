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
    /// public class ViewModel : ObservableObject
    /// {
    ///     private IWPFMessageBoxWrapper _messageBox
    ///     public ViewModel(IWPFMessageBoxWrapper messageBox)
    ///     {
    ///         _messageBox = messageBox;
    ///     }
    /// 
    ///     public void Show()
    ///     {
    ///         messageBox.Show("Messagebox Text");
    ///     }
    /// }
    ///
    /// [TestFixture]
    /// public class ViewModelTests
    /// {
    ///     private Mock<IWPFMessageBoxWrapper> _messageBox;
    ///     private ViewModel _target;
    ///
    ///     [SetUp]
    ///     public void Setup()
    ///     {
    ///         _messageBox = new Mock<IWPFMessageBoxWrapper>();
    ///         _target = new ViewModel(_messageBox.Object);
    ///     }
    ///
    ///     [Test]
    ///     public void Show_Called_ShowsMessageBox()
    ///     {
    ///         _target.Show();
    ///
    ///         _messageBox.Verify(x => x.Show("Messagebox Text"), Times.Once);
    ///     }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public interface IWPFMessageBoxWrapper
    {
        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(string messageBoxText);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(string messageBoxText, string caption);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="defaultButton">A WPFMessageBoxResult value that specifies the default result of the message box.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(Window owner, string messageBoxText);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon);

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
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(string messageBoxText, WPFMessageBoxOptions options);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxOptions options);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxOptions options);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="icon">A WPFMessageBoxImages value that specifies the icon to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxOptions options);

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
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton, WPFMessageBoxOptions options);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, WPFMessageBoxOptions options);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxOptions options);

        /// <summary>
        ///     Displays a message box that has a message and that returns a result of the button the user pressed.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A String that specifies the text to display.</param>
        /// <param name="caption">A String that specifies the title bar caption to display.</param>
        /// <param name="buttons">A WPFMessageBoxButtons value that specifies which buttons to display.</param>
        /// <param name="options">A WPFMessageBoxOptions value object that specifies the options.</param>
        /// <returns>A WPFMessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxOptions options);

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
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxOptions options);

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
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton, WPFMessageBoxOptions options);
    }
}