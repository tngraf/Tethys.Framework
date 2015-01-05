#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for Windows Forms applications.
//
// ===========================================================================
//
// <copyright file="FilterTextBox.cs" company="Tethys">
// Copyright  1998-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2013
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Forms
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Windows.Forms;
    using Tethys.Win32;

    /// <summary>
    /// Type of characters the FilterTextBox should accept.
    /// </summary>
    [Flags]
    public enum CharacterTypes
    {
        /// <summary>
        /// No characters.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// letters (no numbers).
        /// </summary>
        Letters = 0x01,

        /// <summary>
        /// Only numbers 0..9.
        /// </summary>
        Numbers = 0x02,

        /// <summary>
        /// Only hex numbers 0..9, A..F.
        /// </summary>
        HexNumbers = 0x04,

        /// <summary>
        /// Spaces allowed.
        /// </summary>
        Space = 0x08
    } // CharacterType

    /// <summary>
    /// FilterTextBox implements an enhanced textbox control that can restrict
    /// the type of character that can be entered: only letters, only numbers,
    /// or both (default).
    /// </summary>
    [ComVisible(false)]
    [ToolboxBitmap(typeof(TextBox))]
    [SecurityCritical]
    public class FilterTextBox : TextBox
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Internal property: Type of characters the textbox should accept.
        /// </summary>
        private CharacterTypes characterType;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the type of characters the textbox should accept.
        /// </summary>
        [Category("Behavior"),
        Description("Type of characters the textbox should accept")]
        public CharacterTypes CharacterType
        {
            get { return this.characterType; }
            set { this.characterType = value; }
        } // CharacterType
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterTextBox"/> class.
        /// </summary>
        public FilterTextBox()
        {
            // set default values
            this.characterType = CharacterTypes.Letters | CharacterTypes.Numbers
              | CharacterTypes.HexNumbers | CharacterTypes.Space;
        } // FilterTextBox()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region CORE METHODS
        /// <summary>
        /// Determines if a character is an input character that the
        /// control recognizes.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        ///   <c>true</c> if this is valid char; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsValidChar(char code)
        {
            if (((this.characterType & CharacterTypes.Space) > 0)
              && (code == ' '))
            {
                return true;
            } // if

            if (((this.characterType & CharacterTypes.Numbers) > 0)
              && (char.IsDigit(code)))
            {
                return true;
            } // if

            if (((this.characterType & CharacterTypes.Letters) > 0)
              && (char.IsLetter(code)))
            {
                return true;
            } // if

            if ((this.characterType & CharacterTypes.HexNumbers) > 0)
            {
                if ((char.IsDigit(code))
                  || ((char.ToUpper(code, CultureInfo.CurrentCulture) >= 'A')
                  && (char.ToUpper(code, CultureInfo.CurrentCulture) <= 'F')))
                {
                    return true;
                }
            } // if

            return false;
        } // IsInputChar()

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">A Windows Message object.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)Msg.WM_CHAR)
            {
                char test = (char)m.WParam;

                // some characters always pass through
                switch (test)
                {
                    case (char)(int)VirtualKeys.VK_BACK:
                    case (char)(int)VirtualKeys.VK_CLEAR:
                    case (char)(int)VirtualKeys.VK_RETURN:
                    case (char)(int)VirtualKeys.VK_TAB:
                    case (char)(int)VirtualKeys.VK_CTRLC:
                    case (char)(int)VirtualKeys.VK_CTRLV:
                    case (char)(int)VirtualKeys.VK_CTRLX:
                        base.WndProc(ref m);
                        return;
                } // switch

                // start validation
                if (IsValidChar(test))
                {
                    base.WndProc(ref m);
                }
                else
                {
                    // beep!
                    int result = Win32Api.MessageBeep(-1);
                    Debug.Assert(result > 0, "MessageBeep reports error!");
                } // if
            }
            else
            {
                // other than WM_CHAR message
                base.WndProc(ref m);
            } // if
        } // WndProc()
        #endregion // CORE METHODS
    } // FilterTextBox
} // Tethys.Forms

// =====================================
// Tethys.forms: end of FilterTextBox.cs
// =====================================
