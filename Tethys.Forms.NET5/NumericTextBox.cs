// ---------------------------------------------------------------------------
// <copyright file="NumericTextBox.cs" company="Tethys">
//   Copyright (C) 1998-2021 T. Graf
// </copyright>
//
// SPDX-License-Identifier: Apache-2.0
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// ---------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace Tethys.Forms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// The numeric text box takes numeric(decimal) values as input.
    /// It has the following extra properties:<br/>
    ///    NumericPrecision: Precision<br/>
    ///    NumericScaleOnFocus: The scale to display when the text box has got the focus.<br/>
    ///    NumericScaleOnLostFocus: The scale to display when the text box hasn't got the focus.<br/>
    ///    NumericValue: The current numeric value displayed in the text box (decimal)<br/>
    ///    ZeroIsValid: Zero is a valid as input<br/>
    ///    AllowNegative: Allow input of negative decimal numbers<br/>
    ///  It has the following extra events:<br/>
    ///    NumericValueChanged: The event fires when the numeric value changes <br/>
    ///               by user input or programmatically.(Like TextChanged)<br/>
    ///  Use NumericValueChanged event instead of the TextChanged event!
    ///  The NumericValue property is also capable of data binding.
    ///  The decimal number is displayed with grouping char.
    /// </summary>
    [DefaultEvent("NumericValueChanged")]
    [DefaultProperty("NumericValue")]
    [ToolboxBitmap(typeof(TextBox))]
    public sealed partial class NumericTextBox : TextBox
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The scale displayed when the textbox has no focus.
        /// </summary>
        private int scaleOnLostFocus;

        /// <summary>
        /// Current internal value.
        /// </summary>
        private decimal internalValue;

        /// <summary>
        /// The current numeric value displayed in the textbox.
        /// </summary>
        private decimal numericValue;

        /// <summary>
        /// The maximum scale allowed.
        /// </summary>
        private int scaleOnFocus;

        /// <summary>
        /// The maximum allowed precision.
        /// </summary>
        private int precision = 1;

        /// <summary>
        /// Flag to block the changed event.
        /// </summary>
        private bool noChangeEvent;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Occurs when the numeric value of the control has changed.
        /// </summary>
        public event EventHandler NumericValueChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the value zero (0) valid.
        /// </summary>
        [Category("Numeric settings")]
        public bool ZeroIsValid { get; set; }

        /// <summary>
        /// Gets or sets the maximum allowed precision.
        /// </summary>
        [Category("Numeric settings")]
        public int NumericPrecision
        {
            get
            {
                return this.precision;
            }

            set
            {
                // Precision cannot be negative
                if (value < 0)
                {
                    // ReSharper disable NotResolvedInText
                    throw new ArgumentOutOfRangeException(
                        "NumericPrecision",
                        // ReSharper restore NotResolvedInText
                        "Precision cannot be negative");
                } // if

                if (value < this.NumericScaleOnFocus)
                {
                    this.NumericScaleOnFocus = value;
                } // if

                this.precision = value;
            }
        } // NumericPrecision

        /// <summary>
        /// Gets or sets the maximum scale allowed.
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        [Category("Numeric settings")]
        public int NumericScaleOnFocus
        {
            get
            {
                return this.scaleOnFocus;
            }

            set
            {
                // Scale cannot be negative
                if (value < 0)
                {
                    // ReSharper disable NotResolvedInText
                    throw new ArgumentOutOfRangeException(
                        "NumericScaleOnFocus",
                        // ReSharper restore NotResolvedInText
                        "Scale cannot be negative");
                } // if

                // Scale cannot be larger than precision
                if (value >= this.NumericPrecision)
                {
                    // ReSharper disable NotResolvedInText
                    throw new ArgumentOutOfRangeException(
                        "NumericScaleOnFocus",
                        // ReSharper restore NotResolvedInText
                        "Scale cannot be larger than precision");
                } // if

                this.scaleOnFocus = value;

                if (this.scaleOnFocus > 0)
                {
                    this.Text = "0" + DecimalSeparator +
                    new string(Convert.ToChar("0", CultureInfo.CurrentCulture), this.scaleOnFocus);
                }
                else
                {
                    this.Text = "0";
                } // if
            }
        } // NumericScaleOnFocus

        /// <summary>
        /// Gets or sets the scale displayed when the textbox has no focus.
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        [Category("Numeric settings")]
        public int NumericScaleOnLostFocus
        {
            get
            {
                return this.scaleOnLostFocus;
            }

            set
            {
                // Scale cannot be negative
                if (value < 0)
                {
                    // ReSharper disable NotResolvedInText
                    throw new ArgumentOutOfRangeException(
                        "NumericScaleOnLostFocus",
                        // ReSharper restore NotResolvedInText
                        "Scale cannot be negative");
                } // if

                // Scale cannot be larger than precision
                if (value >= this.NumericPrecision)
                {
                    // ReSharper disable NotResolvedInText
                    throw new ArgumentOutOfRangeException(
                        "NumericScaleOnLostFocus",
                        // ReSharper restore NotResolvedInText
                        "Scale cannot be larger than precision");
                } // if

                this.scaleOnLostFocus = value;
            }
        } // NumericScaleOnLostFocus

        /// <summary>
        /// Gets the decimal separator.
        /// </summary>
        private static string DecimalSeparator
        {
            get
            {
                return NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            }
        } // DecimalSeparator

        /// <summary>
        /// Gets the group separator.
        /// </summary>
        private static string GroupSeparator
        {
            get
            {
                return NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
            }
        } // GroupSeparator

        /// <summary>
        /// Gets or sets a value indicating whether negative numbers are allowed.
        /// </summary>
        [Category("Numeric settings")]
        public bool AllowNegative { get; set; } = true;

        /// <summary>
        /// Gets or sets the current numeric value displayed in the textbox.
        /// </summary>
        [Bindable(true)]
        [Category("Numeric settings")]
        public object NumericValue
        {
            get
            {
                return this.numericValue;
            }

            set
            {
                if (value.Equals(DBNull.Value))
                {
                    if (value.Equals(0))
                    {
                        this.Text = Convert.ToString(0, CultureInfo.CurrentCulture);
                        this.numericValue = Convert.ToDecimal(0, CultureInfo.CurrentCulture);
                        this.OnNumericValueChanged(new EventArgs());
                        return;
                    } // if
                } // if

                if (!value.Equals(this.numericValue))
                {
                    this.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
                    this.numericValue = Convert.ToDecimal(value, CultureInfo.CurrentCulture);
                    this.OnNumericValueChanged(new EventArgs());
                } // if
            }
        } // NumericValue
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericTextBox"/> class.
        /// </summary>
        public NumericTextBox()
        {
            this.ZeroIsValid = false;
            this.InitializeComponent();

            this.TextAlign = HorizontalAlignment.Right;
            this.Text = "0";
            this.LostFocus += this.NumericTextBoxLostFocus;
            this.GotFocus += this.NumericTextBoxGotFocus;
            this.TextChanged += this.NumericTextBoxTextChanged;
            this.KeyDown += this.NumericTextBoxKeyDown;
            this.KeyPress += this.NumericTextBoxKeyPress;
            this.Validating += this.NumericTextBoxValidating;
        } // NumericTextBox()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region UI MANAGEMENT
        /// <summary>
        /// Occurs when the control loses focus.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance
        /// containing the event data.</param>
        private void NumericTextBoxLostFocus(object sender, EventArgs e)
        {
            this.noChangeEvent = true;

            this.internalValue = Convert.ToDecimal(this.Text, CultureInfo.CurrentCulture);

            if (this.scaleOnLostFocus != 0)
            {
                this.Text = this.FormatNumber();
            }
            else
            {
                if (this.Text.IndexOf('-') < 0)
                {
                    this.Text = this.FormatNumber();
                }
                else
                {
                    if (this.Text == "-")
                    {
                        this.Text = string.Empty;
                    }
                    else
                    {
                        this.Text = this.FormatNumber();
                    } // if
                } // if
            } // if

            this.noChangeEvent = false;
        } // NumericTextBox_LostFocus()

        /// <summary>
        /// Occurs when the control receives focus.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NumericTextBoxGotFocus(object sender, EventArgs e)
        {
            this.noChangeEvent = true;

            this.Text = Convert.ToString(this.internalValue, CultureInfo.CurrentCulture);

            if (this.scaleOnFocus != 0)
            {
                this.Text = this.FormatNumber();
            }
            else
            {
                if (this.Text.IndexOf('-') < 0)
                {
                    this.Text = this.FormatNumber();
                }
                else
                {
                    if (this.Text == "-")
                    {
                        this.Text = string.Empty;
                    }
                    else
                    {
                        this.Text = this.FormatNumber();
                    } // if
                } // if
            } // if

            this.noChangeEvent = false;
        } // NumericTextBox_GotFocus()

        /// <summary>
        /// Occurs when the user changes the text of a TextBox.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NumericTextBoxTextChanged(object sender, EventArgs e)
        {
            var selectionStart = 0;
            var positionCursorBeforeComma = false;

            // Indicates that no change event should happen
            // Prevent event from firing on changing the text in the change
            // event
            if (this.noChangeEvent || (this.SelectionStart == -1))
            {
                return;
            } // if

            // No Change event
            this.noChangeEvent = true;

            if (string.IsNullOrEmpty(this.Text.Trim()))
            {
                this.Text = "0";
            } // if

            if (this.Text.Substring(0, 1) == GroupSeparator)
            {
                this.Text = this.Text.Substring(1);
            } // if

            if (this.scaleOnFocus != 0)
            {
                // if ( the current position is just before the comma
                if (this.SelectionStart == (this.Text.IndexOf(DecimalSeparator, StringComparison.OrdinalIgnoreCase)))
                {
                    positionCursorBeforeComma = true;
                }
                else
                {
                    selectionStart = this.SelectionStart;
                } // if
            }
            else
            {
                selectionStart = this.SelectionStart;
            } // if

            this.internalValue = Convert.ToDecimal(this.Text, CultureInfo.CurrentCulture);
            this.NumericValue = Convert.ToDecimal(this.Text, CultureInfo.CurrentCulture);

            if (this.Focused)
            {
                if (this.scaleOnFocus != 0)
                {
                    this.Text = this.FormatNumber();
                }
                else
                {
                    if (this.Text.IndexOf('-') < 0)
                    {
                        this.Text = this.FormatNumber();
                    }
                    else
                    {
                        if (this.Text.Equals('-'))
                        {
                            this.Text = string.Empty;
                        }
                        else
                        {
                            this.Text = this.FormatNumber();
                        } // if
                    } // if
                } // if
            }
            else
            {
                if (this.scaleOnLostFocus != 0)
                {
                    this.Text = this.FormatNumber();
                }
                else
                {
                    if (this.Text.IndexOf('-') < 0)
                    {
                        this.Text = this.FormatNumber();
                    }
                    else
                    {
                        if (this.Text.Equals('-'))
                        {
                            this.Text = string.Empty;
                        }
                        else
                        {
                            this.Text = this.FormatNumber();
                        } // if
                    } // if
                } // if
            } // if

            // if the position was before the comma
            // then put again before the comma
            if (this.scaleOnFocus != 0)
            {
                if (positionCursorBeforeComma)
                {
                    this.SelectionStart = (this.Text.IndexOf(DecimalSeparator, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    this.SelectionStart = selectionStart;
                } // if
            }
            else
            {
                this.SelectionStart = selectionStart;
            } // if

            // Change event may fire
            this.noChangeEvent = false;
        } // NumericTextBox_TextChanged()

        /// <summary>
        /// Handles the key down event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the
        /// event data.</param>
        private void NumericTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            var positionCursorJustBeforeComma = false;

            if (this.scaleOnFocus != 0)
            {
                // Is the position of the cursor just before the comma
                positionCursorJustBeforeComma
                  = (this.SelectionStart == (this.Text.IndexOf(DecimalSeparator, StringComparison.OrdinalIgnoreCase)));
            } // if

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    // Otherwise strange effect
                    if (positionCursorJustBeforeComma)
                    {
                        this.SelectionStart = this.Text.IndexOf(DecimalSeparator, StringComparison.OrdinalIgnoreCase) + 1;
                        e.Handled = true;
                        break;
                    } // if

                    // if all selected on delete pressed
                    if (this.Text.IndexOf('-') < 0)
                    {
                        if (this.SelectionLength == this.Text.Length)
                        {
                            this.Text = "0";
                            this.SelectionStart = 1;
                            e.Handled = true;
                        } // if
                    }
                    else
                    {
                        if (this.SelectionLength == this.Text.Length)
                        {
                            this.Text = "0";
                            this.SelectionStart = 1;
                            e.Handled = true;
                            break;
                        } // if

                        if (this.SelectionLength > 0)
                        {
                            if (this.SelectedText != "-")
                            {
                                if (Convert.ToDouble(this.SelectedText, CultureInfo.CurrentCulture)
                                  == Math.Abs(Convert.ToDouble(this.Text, CultureInfo.CurrentCulture)))
                                {
                                    this.Text = "0";
                                    this.SelectionStart = 1;
                                    e.Handled = true;
                                } // if
                            } // if
                        } // if
                    } // if

                    break;
            } // switch
        } // NumericTextBox_KeyDown()

        /// <summary>
        /// Handles the key press event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing
        /// the event data.</param>
        private void NumericTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            var positionCursorBeforeComma = false;
            var positionCursorJustAfterComma = false;
            int selectionStart;

            bool inputBeforeCommaValid;

            // Minus pressed
            if (e.KeyChar.Equals('-'))
            {
                if (this.AllowNegative)
                {
                    if (this.Text.IndexOf('-') < 0)
                    {
                        selectionStart = this.SelectionStart;

                        if (Convert.ToDecimal(this.Text, CultureInfo.CurrentCulture) != 0)
                        {
                            this.Text = "-" + this.Text;
                            this.SelectionStart = selectionStart + 1;
                        } // if

                        e.Handled = true;
                        return;
                    } // if

                    switch (this.SelectionLength)
                    {
                        case 0:
                            selectionStart = this.SelectionStart;

                            this.Text = Convert.ToString(
                                Convert.ToDouble(
                                    this.Text,
                                    CultureInfo.CurrentCulture) * -1,
                                CultureInfo.CurrentCulture);

                            this.SelectionStart = selectionStart - 1;

                            e.Handled = true;
                            break;
                        default:
                            // Is everything selected
                            if (this.SelectionLength == this.TextLength)
                            {
                                this.Text = "-0";
                            } // if

                            e.Handled = true;
                            break;
                    } // switch

                    e.Handled = true;
                    return;
                } // if
            } // if

            // The + key
            if (e.KeyChar.Equals('+'))
            {
                if (!(this.Text.IndexOf('-') < 0))
                {
                    // Is everything selected
                    switch (this.SelectionLength)
                    {
                        case 0:
                            selectionStart = this.SelectionStart;

                            this.Text = Convert.ToString(
                                Convert.ToDouble(
                                    this.Text,
                                    CultureInfo.CurrentCulture) * -1,
                                CultureInfo.CurrentCulture);

                            this.SelectionStart = selectionStart - 1;

                            e.Handled = true;
                            break;
                        default:
                            if (this.TextLength == this.SelectionLength)
                            {
                                this.Text = "0";
                                e.Handled = true;
                            } // if

                            break;
                    } // switch
                } // if

                e.Handled = true;
                return;
            } // if

            if (this.scaleOnFocus != 0)
            {
                // Is the position of the cursor just after the comma
                positionCursorJustAfterComma
                  = (this.SelectionStart == this.Text.IndexOf(DecimalSeparator, StringComparison.OrdinalIgnoreCase) + 1);
            } // if

            if (e.KeyChar == '\b')
            {
                // Backspace
                if (positionCursorJustAfterComma)
                {
                    this.SelectionStart = this.Text.IndexOf(DecimalSeparator, StringComparison.OrdinalIgnoreCase);
                    e.Handled = true;
                } // if

                // if ( all selected on delete pressed)
                if (this.SelectionLength == this.Text.Length)
                {
                    this.Text = "0";
                    this.SelectionStart = 1;
                    e.Handled = true;
                } // if

                if (e.KeyChar.Equals(null))
                {
                    e.Handled = true;
                } // if

                return;
            } // if

            // Prevent other keys than numeric and ,
            var allowedKeyChars = "1234567890" + DecimalSeparator;
            if (allowedKeyChars.IndexOf(e.KeyChar) < 0)
            {
                e.Handled = true;
                return;
            } // if

            if (this.scaleOnFocus != 0)
            {
                // position of cursor is before comma?
                positionCursorBeforeComma
                  = !(this.SelectionStart >= this.Text.IndexOf(DecimalSeparator, StringComparison.OrdinalIgnoreCase) + 1);
            } // if

            // Comma pressed
            if (e.KeyChar.ToString(CultureInfo.InvariantCulture)
                == DecimalSeparator)
            {
                if (positionCursorBeforeComma)
                {
                    this.SelectionStart = this.Text.IndexOf(DecimalSeparator, StringComparison.OrdinalIgnoreCase) + 1;
                    this.SelectionLength = 0;
                } // if

                e.Handled = true;
                return;
            } // if

            // Prevent more than the precision numbers entered
            if (this.scaleOnFocus != 0)
            {
                if (this.SelectionStart == this.Text.Length)
                {
                    e.Handled = true;
                    return;
                } // if
            } // if

            if (this.scaleOnFocus != 0)
            {
                // if ( the character entered would violate the numbers before the comma
                if (this.Text.IndexOf('-') < 0)
                {
                    inputBeforeCommaValid = !(this.Text.Substring(0, this.Text.IndexOf(
                        DecimalSeparator,
                        StringComparison.OrdinalIgnoreCase)).Length >= (this.precision - this.scaleOnFocus));
                }
                else
                {
                    inputBeforeCommaValid = !(this.Text.Substring(
                                                  0,
                                                  this.Text.IndexOf(DecimalSeparator, StringComparison.OrdinalIgnoreCase)).Length
                      >= (this.precision - this.scaleOnFocus + 1));
                } // if
            }
            else
            {
                if (this.Text.IndexOf('-') < 0)
                {
                    inputBeforeCommaValid = !((this.Text.Length) >= this.precision);
                }
                else
                {
                    inputBeforeCommaValid = !((this.Text.Length) >= this.precision + 1);
                } // if
            } // if

            // if first char is 0 another may be entered
            if (this.scaleOnFocus != 0)
            {
                if ((this.Text.Substring(0, 1) == "0") && (this.SelectionStart != 0))
                {
                    inputBeforeCommaValid = true;
                } // if

                if (this.SelectionLength > 0)
                {
                    inputBeforeCommaValid = true;
                } // if
            }
            else
            {
                if ((this.Text.Substring(0, 1) == "0")
                  && ((this.SelectionStart == this.Text.Length)
                  || (this.SelectionLength == 1)))
                {
                    inputBeforeCommaValid = true;
                } // if

                if (this.SelectionLength > 0)
                {
                    inputBeforeCommaValid = true;
                } // if
            } // if

            if (this.scaleOnFocus != 0)
            {
                if (positionCursorBeforeComma && !(inputBeforeCommaValid))
                {
                    e.Handled = true;
                } // if
            }
            else
            {
                if (!(inputBeforeCommaValid))
                {
                    e.Handled = true;
                } // if
            } // if
        } // NumericTextBox_KeyPress()

        /// <summary>
        /// Raises the NumericValueChanged event.
        /// </summary>
        /// <param name="e">The event args.</param>
        private void OnNumericValueChanged(EventArgs e)
        {
            this.NumericValueChanged?.Invoke(this, e);
        } // OnNumericValueChanged()

        /// <summary>
        /// Formats a the text in the textbox (which represents a number) according to
        /// the scale, precision and the environment settings.
        /// </summary>
        /// <returns>The formatted string.</returns>
        private string FormatNumber()
        {
            var lsbFormat = new StringBuilder();
            var counter = 1;
            long remainder;

            if (this.Focused)
            {
                while (counter <= this.precision - this.scaleOnFocus)
                {
                    if (counter == 1)
                    {
                        lsbFormat.Insert(0, '0');
                    }
                    else
                    {
                        lsbFormat.Insert(0, '#');
                    } // if

                    DivRem(counter, 3, out remainder);
                    if ((remainder == 0) && (counter + 1 <= this.precision - this.scaleOnFocus))
                    {
                        lsbFormat.Insert(0, ',');
                    } // if

                    counter++;
                } // while

                counter = 1;

                if (this.scaleOnFocus > 0)
                {
                    lsbFormat.Append(".");

                    while (counter <= this.scaleOnFocus)
                    {
                        lsbFormat.Append('0');
                        counter++;
                    } // while
                } // if
            }
            else
            {
                while (counter <= this.precision - this.scaleOnLostFocus)
                {
                    if (counter == 1)
                    {
                        lsbFormat.Insert(0, '0');
                    }
                    else
                    {
                        lsbFormat.Insert(0, '#');
                    } // if

                    DivRem(counter, 3, out remainder);
                    if ((remainder == 0) && (counter + 1 <= this.precision - this.scaleOnLostFocus))
                    {
                        lsbFormat.Insert(0, ',');
                    } // if

                    counter++;
                } // while

                counter = 1;

                if (this.scaleOnLostFocus > 0)
                {
                    lsbFormat.Append(".");

                    while (counter <= this.scaleOnLostFocus)
                    {
                        lsbFormat.Append('0');
                        counter++;
                    } // while
                } // if
            } // if

            return Convert.ToDecimal(this.Text, CultureInfo.CurrentCulture)
              .ToString(lsbFormat.ToString(), CultureInfo.CurrentCulture);
        } // FormatNumber()

        /// <summary>
        /// Handles the Validating event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing
        /// the event data.</param>
        private void NumericTextBoxValidating(object sender, CancelEventArgs e)
        {
            if ((string.IsNullOrEmpty(this.Text)
              || Convert.ToDecimal(this.NumericValue, CultureInfo.CurrentCulture)
              .Equals(Convert.ToDecimal(0, CultureInfo.CurrentCulture)))
              && !this.ZeroIsValid)
            {
                e.Cancel = true;
            } // if
        } // NumericTextBoxValidating()

        /// <summary>
        /// Returns the quotient of two 32-bit signed integers, also passing the
        /// remainder as an output parameter.
        /// </summary>
        /// <remarks>
        /// This function has been implemented here to support the .Net framework 1.0,
        /// it is part of System.Math of the .Net framework 1.1.
        /// </remarks>
        /// <param name="a">The <see cref="long"/> that contains the
        /// dividend.</param>
        /// <param name="b">The <see cref="long"/> that contains the
        /// divisor.</param>
        /// <param name="result">The <see cref="long"/> that receives the
        /// remainder.</param>
        /// <returns>The <see cref="long"/> containing the quotient of the
        /// specified numbers.</returns>
        private static long DivRem(long a, long b, out long result)
        {
            var ret = a / b;
            result = a % b;

            return ret;
        } // DivRem()
        #endregion // UI MANAGEMENT
    } // NumericTextBox
} // Tethys.Forms

// ======================================
// Tethys.Forms: end of NumericTextBox.cs
// ======================================
