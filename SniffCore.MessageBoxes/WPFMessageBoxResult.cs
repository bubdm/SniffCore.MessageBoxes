﻿//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Represents the result of the <see cref="WPFMessageBox" /> and its default button after calling show.
    /// </summary>
    public enum WPFMessageBoxResult
    {
        /// <summary>
        ///     The WPFMessageBox has been closed without a result and has no default button.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The WPFMessageBox has been closed by the OK button and the OK button is the default button.
        /// </summary>
        OK = 1,

        /// <summary>
        ///     The WPFMessageBox has been closed by the Cancel button and the Cancel button is the default button.
        /// </summary>
        Cancel = 2,

        /// <summary>
        ///     The WPFMessageBox has been closed by the Abort button and the Abort button is the default button.
        /// </summary>
        Abort = 3,

        /// <summary>
        ///     The WPFMessageBox has been closed by the Retry button and the Retry button is the default button.
        /// </summary>
        Retry = 4,

        /// <summary>
        ///     The WPFMessageBox has been closed by the Ignore button and the Ignore button is the default button.
        /// </summary>
        Ignore = 5,

        /// <summary>
        ///     The WPFMessageBox has been closed by the Yes button and the Yes button is the default button.
        /// </summary>
        Yes = 6,

        /// <summary>
        ///     The WPFMessageBox has been closed by the No button and the No button is the default button.
        /// </summary>
        No = 7,

        /// <summary>
        ///     The WPFMessageBox has been closed by the Continue button and the Continue button is the default button.
        /// </summary>
        Continue = 8,

        /// <summary>
        ///     The WPFMessageBox has been closed by the YesToAll button and the YesToAll button is the default button.
        /// </summary>
        YesToAll = 9,

        /// <summary>
        ///     The WPFMessageBox has been closed by the NoToAll button and the NoToAll button is the default button.
        /// </summary>
        NoToAll = 10
    }
}