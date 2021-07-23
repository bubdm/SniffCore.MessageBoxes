//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Defines which buttons to show in the <see cref="WPFMessageBox" />.
    /// </summary>
    public enum WPFMessageBoxButtons
    {
        /// <summary>
        ///     The WPFMessageBox has just the OK button.
        /// </summary>
        OK = 0,

        /// <summary>
        ///     The WPFMessageBox has the OK and Cancel buttons.
        /// </summary>
        OKCancel = 1,

        /// <summary>
        ///     The WPFMessageBox has the Abort, Retry and Ignore buttons.
        /// </summary>
        AbortRetryIgnore = 2,

        /// <summary>
        ///     The WPFMessageBox has the Yes, No and Cancel buttons.
        /// </summary>
        YesNoCancel = 3,

        /// <summary>
        ///     The WPFMessageBox has the Yes and No buttons.
        /// </summary>
        YesNo = 4,

        /// <summary>
        ///     The WPFMessageBox has the Retry and Cancel buttons.
        /// </summary>
        RetryCancel = 5,

        /// <summary>
        ///     The WPFMessageBox has the Cancel, Try Again and Continue buttons.
        /// </summary>
        CancelTryAgainContinue = 6
    }
}