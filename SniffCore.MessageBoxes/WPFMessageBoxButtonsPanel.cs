//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using SniffCore.MessageBoxes.Internal;

namespace SniffCore.MessageBoxes
{
    /// <summary>
    ///     Represents the buttons panel hosted in the <see cref="WPFMessageBox" />.
    /// </summary>
    [TemplatePart(Name = "PART_SingleOKButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_OKButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_YesButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_YesToAllButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_NoButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_NoToAllButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_RetryButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_IgnoreButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CancelButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_AbortButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_HelpButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_TryAgainButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ContinueButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_DoNotShowAgainCheckBox", Type = typeof(CheckBox))]
    [TemplatePart(Name = "PART_DetailsExpander", Type = typeof(Expander))]
    public class WPFMessageBoxButtonsPanel : Control
    {
        /// <summary>
        ///     Identifies the <see cref="Result" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(WPFMessageBoxResult), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(WPFMessageBoxResult.None));

        /// <summary>
        ///     Identifies the <see cref="Buttons" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(WPFMessageBoxButtons), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(WPFMessageBoxButtons.OK));

        /// <summary>
        ///     Identifies the <see cref="DefaultButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DefaultButtonProperty =
            DependencyProperty.Register("DefaultButton", typeof(WPFMessageBoxResult), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(WPFMessageBoxResult.None));

        /// <summary>
        ///     Identifies the <see cref="Strings" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty StringsProperty =
            DependencyProperty.Register("Strings", typeof(MessageBoxStrings), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="ShowHelpButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowHelpButtonProperty =
            DependencyProperty.Register("ShowHelpButton", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(false));

        /// <summary>
        ///     Identifies the <see cref="ShowYesToAllButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowYesToAllButtonProperty =
            DependencyProperty.Register("ShowYesToAllButton", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(false));

        /// <summary>
        ///     Identifies the <see cref="ShowNoToAllButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowNoToAllButtonProperty =
            DependencyProperty.Register("ShowNoToAllButton", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(false));

        /// <summary>
        ///     Identifies the <see cref="ShowDoNotShowAgainCheckBox" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowDoNotShowAgainCheckBoxProperty =
            DependencyProperty.Register("ShowDoNotShowAgainCheckBox", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new UIPropertyMetadata(false));

        /// <summary>
        ///     Identifies the <see cref="IsDoNotShowAgainChecked" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsDoNotShowAgainCheckedProperty =
            DependencyProperty.Register("IsDoNotShowAgainChecked", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new UIPropertyMetadata(false));

        /// <summary>
        ///     Identifies the <see cref="ShowDetails" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowDetailsProperty =
            DependencyProperty.Register("ShowDetails", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new UIPropertyMetadata(false));

        /// <summary>
        ///     Identifies the <see cref="CustomItem" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CustomItemProperty =
            DependencyProperty.Register("CustomItem", typeof(object), typeof(WPFMessageBoxButtonsPanel), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="Click" /> routed event.
        /// </summary>
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WPFMessageBoxButtonsPanel));

        /// <summary>
        ///     Identifies the <see cref="HelpRequest" /> routed event.
        /// </summary>
        public static readonly RoutedEvent HelpRequestEvent = EventManager.RegisterRoutedEvent("HelpRequest", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WPFMessageBoxButtonsPanel));

        /// <summary>
        ///     Identifies the <see cref="ExpandDetails" /> routed event.
        /// </summary>
        public static readonly RoutedEvent ExpandDetailsEvent = EventManager.RegisterRoutedEvent("ExpandDetails", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WPFMessageBoxButtonsPanel));

        static WPFMessageBoxButtonsPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxButtonsPanel), new FrameworkPropertyMetadata(typeof(WPFMessageBoxButtonsPanel)));
        }

        /// <summary>
        ///     Gets or sets the result how the user closed the WPFMessageBox.
        /// </summary>
        [DefaultValue(WPFMessageBoxResult.None)]
        public WPFMessageBoxResult Result
        {
            get => (WPFMessageBoxResult) GetValue(ResultProperty);
            set => SetValue(ResultProperty, value);
        }

        /// <summary>
        ///     Gets or sets which buttons has to be shown.
        /// </summary>
        [DefaultValue(WPFMessageBoxButtons.OK)]
        public WPFMessageBoxButtons Buttons
        {
            get => (WPFMessageBoxButtons) GetValue(ButtonsProperty);
            set => SetValue(ButtonsProperty, value);
        }

        /// <summary>
        ///     Gets or sets which button is the default button after showing the WPFMessageBox.
        /// </summary>
        [DefaultValue(WPFMessageBoxResult.None)]
        public WPFMessageBoxResult DefaultButton
        {
            get => (WPFMessageBoxResult) GetValue(DefaultButtonProperty);
            set => SetValue(DefaultButtonProperty, value);
        }

        /// <summary>
        ///     Gets or sets all strings to be used in the WPFMessageBox buttons.
        /// </summary>
        [DefaultValue(null)]
        public MessageBoxStrings Strings
        {
            get => (MessageBoxStrings) GetValue(StringsProperty);
            set => SetValue(StringsProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a help button or not.
        /// </summary>
        [DefaultValue(false)]
        public bool ShowHelpButton
        {
            get => (bool) GetValue(ShowHelpButtonProperty);
            set => SetValue(ShowHelpButtonProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a 'Yes To All' button.
        /// </summary>
        [DefaultValue(false)]
        public bool ShowYesToAllButton
        {
            get => (bool) GetValue(ShowYesToAllButtonProperty);
            set => SetValue(ShowYesToAllButtonProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a 'No To All' button.
        /// </summary>
        [DefaultValue(false)]
        public bool ShowNoToAllButton
        {
            get => (bool) GetValue(ShowNoToAllButtonProperty);
            set => SetValue(ShowNoToAllButtonProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a 'Do Not Show Again' checkbox.
        /// </summary>
        [DefaultValue(false)]
        public bool ShowDoNotShowAgainCheckBox
        {
            get => (bool) GetValue(ShowDoNotShowAgainCheckBoxProperty);
            set => SetValue(ShowDoNotShowAgainCheckBoxProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the 'Do Not Show Again' is checked on start and the check state after close
        ///     the WPFMessageBox.
        /// </summary>
        [DefaultValue(false)]
        public bool IsDoNotShowAgainChecked
        {
            get => (bool) GetValue(IsDoNotShowAgainCheckedProperty);
            set => SetValue(IsDoNotShowAgainCheckedProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the WPFMessageBox has a details button.
        /// </summary>
        [DefaultValue(false)]
        public bool ShowDetails
        {
            get => (bool) GetValue(ShowDetailsProperty);
            set => SetValue(ShowDetailsProperty, value);
        }

        /// <summary>
        ///     Gets or sets a additional control which gets shown between the details and normal buttons.
        /// </summary>
        [DefaultValue(null)]
        public object CustomItem
        {
            get => GetValue(CustomItemProperty);
            set => SetValue(CustomItemProperty, value);
        }

        /// <summary>
        ///     The template gets added to the control.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            AddHandler(ButtonBase.ClickEvent, (RoutedEventHandler) OnMessageBoxButtonClick);
        }

        private void OnMessageBoxButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (ButtonBase) e.OriginalSource;
            switch (button.Name)
            {
                case "PART_SingleOKButton":
                    Result = WPFMessageBoxResult.OK;
                    break;
                case "PART_OKButton":
                    Result = WPFMessageBoxResult.OK;
                    break;
                case "PART_YesButton":
                    Result = WPFMessageBoxResult.Yes;
                    break;
                case "PART_YesToAllButton":
                    Result = WPFMessageBoxResult.YesToAll;
                    break;
                case "PART_NoButton":
                    Result = WPFMessageBoxResult.No;
                    break;
                case "PART_NoToAllButton":
                    Result = WPFMessageBoxResult.NoToAll;
                    break;
                case "PART_RetryButton":
                    Result = WPFMessageBoxResult.Retry;
                    break;
                case "PART_IgnoreButton":
                    Result = WPFMessageBoxResult.Ignore;
                    break;
                case "PART_CancelButton":
                    Result = WPFMessageBoxResult.Cancel;
                    break;
                case "PART_AbortButton":
                    Result = WPFMessageBoxResult.Abort;
                    break;
                case "PART_TryAgainButton":
                    Result = WPFMessageBoxResult.Retry;
                    break;
                case "PART_ContinueButton":
                    Result = WPFMessageBoxResult.Continue;
                    break;
                case "PART_HelpButton":
                    OnHelpRequest();
                    return;
                case "HeaderSite": // Details expander
                    OnExpandDetails();
                    return;
                default:
                    return;
            }

            OnClick();
        }

        internal void SetDefaultButton()
        {
            switch (DefaultButton)
            {
                case WPFMessageBoxResult.Abort:
                    SetDefaultButton("PART_AbortButton");
                    break;
                case WPFMessageBoxResult.Cancel:
                    SetDefaultButton("PART_CancelButton");
                    break;
                case WPFMessageBoxResult.Ignore:
                    SetDefaultButton("PART_IgnoreButton");
                    break;
                case WPFMessageBoxResult.No:
                    SetDefaultButton("PART_NoButton");
                    break;
                case WPFMessageBoxResult.None:
                    CalculateDefaultButton();
                    break;
                case WPFMessageBoxResult.Continue:
                    SetDefaultButton("PART_ContinueButton");
                    break;
                case WPFMessageBoxResult.OK:
                    if (Buttons == WPFMessageBoxButtons.OK)
                        SetDefaultButton("PART_SingleOKButton");
                    else
                        SetDefaultButton("PART_OKButton");
                    break;
                case WPFMessageBoxResult.Retry:
                    if (!SetDefaultButton("PART_TryAgainButton"))
                        SetDefaultButton("PART_RetryButton");
                    break;
                case WPFMessageBoxResult.Yes:
                    SetDefaultButton("PART_YesButton");
                    break;
                case WPFMessageBoxResult.YesToAll:
                    SetDefaultButton("PART_YesToAllButton");
                    break;
                case WPFMessageBoxResult.NoToAll:
                    SetDefaultButton("PART_NoToAllButton");
                    break;
            }
        }

        private void CalculateDefaultButton()
        {
            switch (Buttons)
            {
                case WPFMessageBoxButtons.OK:
                    SetDefaultButton("PART_SingleOKButton");
                    break;
                case WPFMessageBoxButtons.OKCancel:
                    SetDefaultButton("PART_OKButton");
                    break;
                case WPFMessageBoxButtons.RetryCancel:
                case WPFMessageBoxButtons.AbortRetryIgnore:
                    SetDefaultButton("PART_RetryButton");
                    break;
                case WPFMessageBoxButtons.YesNo:
                case WPFMessageBoxButtons.YesNoCancel:
                    SetDefaultButton("PART_YesButton");
                    break;
                case WPFMessageBoxButtons.CancelTryAgainContinue:
                    SetDefaultButton("PART_TryAgainButton");
                    break;
            }
        }

        private bool SetDefaultButton(string elementName)
        {
            if (GetTemplateChild(elementName) is UIElement button && button.Visibility == Visibility.Visible)
            {
                button.Focus();
                Keyboard.Focus(button);
                return true;
            }

            CalculateDefaultButton();
            return false;
        }

        internal void TakeStyles(WPFMessageBoxOptions.StylesContainer styles)
        {
            TryApplyStyle<WPFMessageBoxButtonControl>(styles.ButtonControlStyle);
            TryApplyStyle<WPFMessageBoxCheckBox>(styles.CheckBoxControlStyle);
            TryApplyStyle<WPFMessageBoxDetailsButton>(styles.DetailsButtonControlStyle);
        }

        private void TryApplyStyle<T>(Style style) where T : FrameworkElement
        {
            if (style == null)
                return;

            var controls = VisualTreeAssist.GetChildren<T>(this);
            foreach (var control in controls)
                control.Style = style;
        }

        /// <summary>
        ///     Occurs when a button got clicked.
        /// </summary>
        public event RoutedEventHandler Click
        {
            add => AddHandler(ClickEvent, value);
            remove => RemoveHandler(ClickEvent, value);
        }

        private void OnClick()
        {
            var newEventArgs = new RoutedEventArgs(ClickEvent);
            RaiseEvent(newEventArgs);
        }

        /// <summary>
        ///     Occurs when the help button got clicked.
        /// </summary>
        public event RoutedEventHandler HelpRequest
        {
            add => AddHandler(HelpRequestEvent, value);
            remove => RemoveHandler(HelpRequestEvent, value);
        }

        private void OnHelpRequest()
        {
            var newEventArgs = new RoutedEventArgs(HelpRequestEvent);
            RaiseEvent(newEventArgs);
        }

        /// <summary>
        ///     Occurs when the details button got clicked.
        /// </summary>
        public event RoutedEventHandler ExpandDetails
        {
            add => AddHandler(ExpandDetailsEvent, value);
            remove => RemoveHandler(ExpandDetailsEvent, value);
        }

        private void OnExpandDetails()
        {
            var newEventArgs = new RoutedEventArgs(ExpandDetailsEvent);
            RaiseEvent(newEventArgs);
        }
    }
}