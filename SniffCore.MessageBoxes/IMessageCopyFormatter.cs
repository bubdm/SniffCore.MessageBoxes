//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Represents the formatter to be used after pressing Ctrl+C with the <see cref="WPFMessageBox" /> open.
    /// </summary>
    public interface IMessageCopyFormatter
    {
        /// <summary>
        ///     Called to copy the WPFMessageBox content somewhere to.
        /// </summary>
        /// <param name="title">The WPFMessageBox title.</param>
        /// <param name="message">The message shown in the WPFMessageBox.</param>
        /// <param name="buttons">The buttons available in the WPFMessageBox.</param>
        /// <param name="icon">The icon shown in the WPFMessageBox.</param>
        /// <param name="strings">The strings used in the WPFMessageBox.</param>
        void Copy(string title, string message, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, MessageBoxStrings strings);
    }
}