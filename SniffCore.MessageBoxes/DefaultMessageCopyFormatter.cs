//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Text;
using System.Windows;

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Takes all data from the <see cref="WPFMessageBox" /> after user pressed Ctrl+C and copy its information to the
    ///     clipboard.
    /// </summary>
    public sealed class DefaultMessageCopyFormatter : IMessageCopyFormatter
    {
        /// <summary>
        ///     Called to copy the WPFMessageBox content somewhere to.
        /// </summary>
        /// <param name="title">The WPFMessageBox title.</param>
        /// <param name="message">The message shown in the WPFMessageBox.</param>
        /// <param name="buttons">The buttons available in the WPFMessageBox.</param>
        /// <param name="icon">The icon shown in the WPFMessageBox.</param>
        /// <param name="strings">The strings used in the WPFMessageBox.</param>
        public void Copy(string title, string message, WPFMessageBoxButtons buttons, WPFMessageBoxImages icon, MessageBoxStrings strings)
        {
            var builder = new StringBuilder();
            builder.AppendLine("---------------------------");
            builder.AppendLine(title);
            builder.AppendLine("---------------------------");
            builder.AppendLine(message);
            builder.AppendLine("---------------------------");
            AppendButtons(builder, buttons, strings);
            builder.AppendLine("---------------------------");

            Clipboard.SetText(builder.ToString());
        }

        private void AppendButtons(StringBuilder builder, WPFMessageBoxButtons buttons, MessageBoxStrings strings)
        {
            switch (buttons)
            {
                case WPFMessageBoxButtons.OK:
                    builder.AppendLine($"{GetString(strings.OK)}   ");
                    break;
                case WPFMessageBoxButtons.OKCancel:
                    builder.AppendLine($"{GetString(strings.OK)}   {GetString(strings.Cancel)}   ");
                    break;
                case WPFMessageBoxButtons.RetryCancel:
                    builder.AppendLine($"{GetString(strings.Retry)}   {GetString(strings.Cancel)}   ");
                    break;
                case WPFMessageBoxButtons.YesNo:
                    builder.AppendLine($"{GetString(strings.Yes)}   {GetString(strings.No)}   ");
                    break;
                case WPFMessageBoxButtons.YesNoCancel:
                    builder.AppendLine($"{GetString(strings.Yes)}   {GetString(strings.No)}   {GetString(strings.Cancel)}   ");
                    break;
                case WPFMessageBoxButtons.AbortRetryIgnore:
                    builder.AppendLine($"{GetString(strings.Abort)}   {GetString(strings.Retry)}   {GetString(strings.Ignore)}   ");
                    break;
            }
        }

        private string GetString(string original)
        {
            return original.Replace("_", "");
        }
    }
}