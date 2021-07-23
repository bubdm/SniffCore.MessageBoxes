//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Defines which icon to show in the <see cref="WPFMessageBox" />.
    /// </summary>
    public enum WPFMessageBoxImages
    {
        /// <summary>
        ///     The WPFMessageBox has no icon.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The WPFMessageBox has the Error icon.
        /// </summary>
        Error = 16,

        /// <summary>
        ///     The WPFMessageBox has the Hand icon.
        /// </summary>
        Hand = 16,

        /// <summary>
        ///     The WPFMessageBox has the Stop icon.
        /// </summary>
        Stop = 16,

        /// <summary>
        ///     The WPFMessageBox has the Question icon.
        /// </summary>
        Question = 32,

        /// <summary>
        ///     The WPFMessageBox has the Exclamation icon.
        /// </summary>
        Exclamation = 48,

        /// <summary>
        ///     The WPFMessageBox has the Warning icon.
        /// </summary>
        Warning = 48,

        /// <summary>
        ///     The WPFMessageBox has the Information icon.
        /// </summary>
        Information = 64,

        /// <summary>
        ///     The WPFMessageBox has the Asterisk icon.
        /// </summary>
        Asterisk = 64
    }
}