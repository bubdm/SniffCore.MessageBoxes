//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Represents the icon shown in the WPFMessageBox.
    /// </summary>
    public class WPFMessageBoxImage : Control
    {
        /// <summary>
        ///     Identifies the <see cref="WPFMessageBoxImage.Image" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(WPFMessageBoxImages), typeof(WPFMessageBoxImage), new PropertyMetadata(WPFMessageBoxImages.None, OnImageChanged));

        /// <summary>
        ///     Identifies the <see cref="BitmapSource" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BitmapSourceProperty =
            DependencyProperty.Register("BitmapSource", typeof(BitmapSource), typeof(WPFMessageBoxImage), new PropertyMetadata(null));

        static WPFMessageBoxImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxImage), new FrameworkPropertyMetadata(typeof(WPFMessageBoxImage)));
        }

        /// <summary>
        ///     Gets or sets the image to be shown.
        /// </summary>
        [DefaultValue(WPFMessageBoxImages.None)]
        public WPFMessageBoxImages Image
        {
            get => (WPFMessageBoxImages) GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        /// <summary>
        ///     Gets or sets the BitmapSource which represents the image to show.
        /// </summary>
        [DefaultValue(null)]
        public BitmapSource BitmapSource
        {
            get => (BitmapSource) GetValue(BitmapSourceProperty);
            set => SetValue(BitmapSourceProperty, value);
        }

        private static void OnImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (WPFMessageBoxImage) d;
            control.OnImageChanged();
        }

        private void OnImageChanged()
        {
            BitmapSource = Image switch
            {
                //WPFMessageBoxImages.Error:
                //WPFMessageBoxImages.Hand:
                WPFMessageBoxImages.Stop => IconToImage(SystemIcons.Error),
                //WPFMessageBoxImages.Exclamation:
                WPFMessageBoxImages.Warning => IconToImage(SystemIcons.Warning),
                //WPFMessageBoxImages.Asterisk:
                WPFMessageBoxImages.Information => IconToImage(SystemIcons.Information),
                WPFMessageBoxImages.Question => IconToImage(SystemIcons.Question),
                _ => BitmapSource
            };
        }

        private BitmapSource IconToImage(Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}