//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;

namespace SniffCore.MessageBoxes
{
    /// <inheritdoc />
    public class WPFMessageBoxWrapper : IWPFMessageBoxWrapper
    {
        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText)
        {
            return WPFMessageBox.Show(messageBoxText);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText, string caption)
        {
            return WPFMessageBox.Show(messageBoxText, caption);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons)
        {
            return WPFMessageBox.Show(messageBoxText, caption, buttons);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon)
        {
            return WPFMessageBox.Show(messageBoxText, caption, buttons, icon);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton)
        {
            return WPFMessageBox.Show(messageBoxText, caption, buttons, icon, defaultButton);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText)
        {
            return WPFMessageBox.Show(owner, messageBoxText);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption)
        {
            return WPFMessageBox.Show(owner, messageBoxText, caption);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons)
        {
            return WPFMessageBox.Show(owner, messageBoxText, caption, buttons);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon)
        {
            return WPFMessageBox.Show(owner, messageBoxText, caption, buttons, icon);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton)
        {
            return WPFMessageBox.Show(owner, messageBoxText, caption, buttons, icon, defaultButton);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(messageBoxText, options);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(messageBoxText, caption, options);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(messageBoxText, caption, buttons, options);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(messageBoxText, caption, buttons, icon, options);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(messageBoxText, caption, buttons, icon, defaultButton, options);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(owner, messageBoxText, options);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(owner, messageBoxText, caption, options);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(owner, messageBoxText, caption, buttons, options);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(owner, messageBoxText, caption, buttons, icon, options);
        }

        /// <inheritdoc />
        public WPFMessageBoxResult Show(Window owner, string messageBoxText, string caption, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, WPFMessageBoxResult defaultButton, WPFMessageBoxOptions options)
        {
            return WPFMessageBox.Show(owner, messageBoxText, caption, buttons, icon, defaultButton, options);
        }
    }
}