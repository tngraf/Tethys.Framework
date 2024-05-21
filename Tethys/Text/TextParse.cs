// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="TextParse.cs" company="Tethys">
// Copyright  1998-2020 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing,
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied.
// </copyright>
//
// System ... netstandard2.0
// Tools .... Microsoft Visual Studio 2019
//
// ---------------------------------------------------------------------------

namespace Tethys.Text
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// The TextParse class implements a large number of text parsing
    /// methods.
    /// </summary>
    public class TextParse
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The text to be parsed.
        /// </summary>
        private string text;

        /// <summary>
        /// Current location.
        /// </summary>
        private int location;

        /// <summary>
        /// Current white space list.
        /// </summary>
        private string whiteSpaceList;

        /// <summary>
        /// Start token.
        /// </summary>
        private int tokenStart;

        /// <summary>
        /// End token.
        /// </summary>
        private int tokenEnd;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// List of default whitespace characters.
        /// </summary>
        public const string DefaultWhiteSpaceList = " \t";

        /// <summary>
        /// Gets the text to be parsed.
        /// </summary>
        public string Text
        {
            get { return this.text; }
        }

        /// <summary>
        /// Gets the text at the current parsing location.
        /// </summary>
        public string TextAtLocation
        {
            get
            {
                if (this.text == null)
                {
                    return null;
                } // if

                return this.text.Substring(this.location);
            }
        }

        /// <summary>
        /// Gets the current parsing location.
        /// </summary>
        public int Location
        {
            get { return this.location; }
        }

        /// <summary>
        /// Gets or sets the whitespace character list.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "Best place for exception..")]
        public string WhiteSpaceList
        {
            get
            {
                return this.whiteSpaceList;
            }

            set
            {
                if (this.whiteSpaceList == null)
                {
                    // ReSharper disable NotResolvedInText
                    throw new ArgumentNullException("Value");
                    // ReSharper restore NotResolvedInText
                } // if

                this.whiteSpaceList = value;
            }
        }
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="TextParse"/>
        /// class.
        /// </summary>
        public TextParse()
        {
            this.whiteSpaceList = DefaultWhiteSpaceList;
            this.Init(string.Empty);
        } // TextParse()

        /// <summary>
        /// Initializes a new instance of the <see cref="TextParse"/>
        /// class.
        /// </summary>
        /// <param name="text">text to be parsed.</param>
        public TextParse(string text)
        {
            this.whiteSpaceList = " \t";
            this.Init(text);
        } // TextParse()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Initializes the parsing engine with the specified text.
        /// </summary>
        /// <param name="inittext">text to be parsed.</param>
        public void Init(string inittext)
        {
            if (this.whiteSpaceList == null)
            {
                throw new ArgumentNullException(nameof(inittext));
            } // if

            this.text = inittext;
            this.location = 0;
            this.tokenStart = 0;
            this.tokenEnd = 0;
        } // Init()

        /// <summary>
        /// Sets the parsing location to the specified text position.
        /// </summary>
        /// <param name="newLocation">new parsing location.</param>
        public void SetLocation(int newLocation)
        {
            if ((newLocation < 0) || (newLocation > this.text.Length))
            {
                throw new ArgumentOutOfRangeException(
                  nameof(newLocation),
                  "location is outside of string boundaries");
            } // if

            this.location = newLocation;
            this.tokenStart = this.location;
            this.tokenEnd = this.location;
        } // SetLocation()

        /// <summary>
        /// Moves the parsing location into front or backwards by
        /// a delta value.
        /// </summary>
        /// <param name="delta">positive or negative delta.</param>
        public void MoveLocation(int delta)
        {
            var help = this.location + delta;
            if ((help < 0) || (help > this.text.Length))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(delta), "new location is outside of string boundaries");
            } // if

            this.location = help;
        } // MoveLocation()

        /// <summary>
        /// Returns the last set token as string. Optionally, the end of
        /// the token may be set; otherwise the end location must be determined
        /// before.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetLastToken are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>ToSpace = limit end of the token to the next space
        /// area.</description>
        /// </item>
        /// <item>
        /// <description>ToLocation = limit end of the token to the current
        /// location. If both options are set, the first end location is used.
        /// </description>
        /// </item>
        /// <item>
        /// <description>ToEnd = activates the determining of the token-end
        /// which must be set when no other flags are set.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>The last token.</returns>
        public string GetLastToken(ParseOptions parseflags)
        {
            if (parseflags != ParseOptions.None)
            {
                // end control specified too: determine & set it
                this.DetermineLastTokenEnd(parseflags);
            }
            else if (this.tokenEnd < this.tokenStart)
            {
                // determine end of last-token automatically
                this.DetermineLastTokenEnd(ParseOptions.ToSpace);
            } // if

            int lenToken = this.tokenEnd - this.tokenStart;
            Debug.Assert(this.tokenEnd >= 0, "TokenEnd must be >= 0");
            return this.text.Substring(this.tokenStart, lenToken);
        } // GetLastToken()

        /// <summary>
        /// Returns the last set token as string.
        /// </summary>
        /// <returns>The last token.</returns>
        public string GetLastToken()
        {
            return this.GetLastToken(ParseOptions.None);
        } // GetLastToken()

        /// <summary>
        /// Sets the current parsing location at the beginning of the last token.
        /// </summary>
        public void SetLastToken()
        {
            this.tokenStart = this.location;
        } // SetLastToken()

        /// <summary>
        /// Sets the specified text position as begin of the last token location.
        /// </summary>
        /// <param name="start">the new start position of the last token.</param>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for SetLastToken are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>ToSpace = limit end of the token to the next space
        /// area.</description>
        /// </item>
        /// <item>
        /// <description>ToLocation = limit end of the token to the current
        /// location. If both options are set, the first end location is used.
        /// </description>
        /// </item>
        /// <item>
        /// <description>ToEnd = activates the determining of the token-end
        /// which must  be set when no other flags are set.</description>
        /// </item>
        /// </list>
        /// </param>
        public void SetLastToken(int start, ParseOptions parseflags)
        {
            this.tokenStart = start;

            Debug.Assert(this.tokenStart >= 0, "Invalid token position!");
            Debug.Assert(this.tokenStart < this.text.Length, "Invalid token position!");

            if (parseflags != ParseOptions.None)
            {
                // end control specified too: determine & set it
                this.DetermineLastTokenEnd(parseflags);
            } // if
        } // SetLastToken()

        /// <summary>
        /// Sets the specified text position as begin of the last token location.
        /// </summary>
        /// <param name="start">The new start position of the last token.</param>
        public void SetLastToken(int start)
        {
            this.SetLastToken(start, ParseOptions.None);
        } // SetLastToken()

        /// <summary>
        /// Determines the end of the last token relative to the begin of
        /// the set token start location.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for SetLastToken are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>ToSpace = limit end of the token to the next space
        /// area.</description>
        /// </item>
        /// <item>
        /// <description>ToLocation = limit end of the token to the current
        /// location.
        /// If both options are set, the first end location is used.
        /// </description>
        /// </item>
        /// </list>
        /// </param>
        public void SetLastToken(ParseOptions parseflags)
        {
            // call common (protected) function
            this.DetermineLastTokenEnd(parseflags);
        } // SetLastToken()

        /// <summary>
        /// Returns the character at the current position, possibly
        /// after skipping space characters.
        /// </summary>
        /// <returns>Character at the current position.</returns>
        public char GetChar()
        {
            return this.GetChar(ParseOptions.None);
        } // GetChar()

        /// <summary>
        /// Returns the character at the current position, possibly
        /// after skipping space characters.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetChar are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace =accepts whitespace before and after the
        /// parsing location</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>Character at the current position.</returns>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "This parameter is the better help for the developer")]
        public char GetChar(ParseOptions parseflags)
        {
            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            if (this.location >= this.text.Length)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentOutOfRangeException("location");
                // ReSharper restore NotResolvedInText
            } // if

            return this.text[this.location];
        } // GetChar()

        /// <summary>
        /// Checks whether the character at the current parsing location
        /// belongs to a number.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for IsNumber are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace =skip space characters.</description>
        /// </item>
        /// <item>
        /// <description>Signed = allow '-'.</description>
        /// </item>
        /// <item>
        /// <description>Signed = allow hex digits.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>Returns true if the character at the current parsing
        /// location belongs to a number.</returns>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "This parameter is the better help for the developer")]
        public bool IsNumber(ParseOptions parseflags)
        {
            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            if (this.location >= this.text.Length)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentOutOfRangeException("location");
                // ReSharper restore NotResolvedInText
            } // if

            if ((this.text[this.location] >= '0')
                && (this.text[this.location] <= '9'))
            {
                return true;
            } // if

            if ((this.text[this.location] == '-')
                && ((parseflags & ParseOptions.Signed) > 0))
            {
                return true;
            } // if

            if ((parseflags & ParseOptions.Hex) > 0)
            {
                var tocheck = this.text.Substring(this.location, 1).ToUpperInvariant()[0];
                if ((tocheck >= 'A') && (tocheck <= 'F'))
                {
                    return true;
                } // if
            } // if

            return false;
        } // IsNumber()

        /// <summary>
        /// Checks whether the character at the current parsing location
        /// belongs to a number.
        /// </summary>
        /// <returns>Returns true if the character at the current parsing location
        /// belongs to a number.</returns>
        public bool IsNumber()
        {
            return this.IsNumber(ParseOptions.None);
        } // IsNumber()

        /// <summary>
        /// Sets the parsing location to the next character, optionally
        /// spaces are skipped, and returns the character at this location.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetNextChar are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace = accepts whitespace before and after the parsing
        /// location</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>Returns the character read.</returns>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "This parameter is the better help for the developer")]
        public char GetNextChar(ParseOptions parseflags)
        {
            if (this.location < this.text.Length)
            {
                this.location++;
            } // if

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            if (this.location >= this.text.Length)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentOutOfRangeException("location");
                // ReSharper restore NotResolvedInText
            } // if

            return this.text[this.location];
        } // GetNextChar()

        /// <summary>
        /// Sets the parsing location to the next character, optionally
        /// spaces are skipped, and returns the character at this location.
        /// </summary>
        /// <returns>Returns the character read.</returns>
        public char GetNextChar()
        {
            return this.GetNextChar(ParseOptions.None);
        } // GetNextChar()

        /// <summary>
        /// Reads the character from the subsequent parsing location,
        /// optionally spaces are skipped, and returns this character without
        /// changing the current parsing location.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for LookNextChar are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace =accepts whitespace before and after the parsing
        /// location.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>Returns the character read.</returns>
        public char LookNextChar(ParseOptions parseflags)
        {
            // save location
            var locSave = this.location;

            var ch = this.GetNextChar(parseflags);

            // set previous location
            this.location = locSave;

            // return read character
            return ch;
        } // LookNextChar()

        /// <summary>
        /// Reads the character from the subsequent parsing location,
        /// optionally spaces are skipped, and returns this character without
        /// changing the current parsing location.
        /// </summary>
        /// <returns>Returns the character read.</returns>
        public char LookNextChar()
        {
            return this.LookNextChar(ParseOptions.None);
        } // LookNextChar()

        /// <summary>
        /// Checks if the end of line (= end of string, 0-terminator) is
        /// reached. Space characters from the current location to the end
        /// location are skipped if the specific option is set (default).
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for IsEndOfLine are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace =accepts whitespace before and after the parsing
        /// location.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// Returns TRUE if the end of line is reached and FALSE if not.
        /// </returns>
        public bool IsEndOfLine(ParseOptions parseflags)
        {
            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            return (this.location >= this.text.Length);
        } // IsEndOfLine()

        /// <summary>
        /// Checks if the end of line (= end of string, 0-terminator) is
        /// reached. Space characters from the current location to the end
        /// location are skipped if the specific option is set (default).
        /// </summary>
        /// <returns>
        /// Returns TRUE if the end of line is reached and FALSE if not.
        /// </returns>
        public bool IsEndOfLine()
        {
            return this.IsEndOfLine(ParseOptions.SkipSpace);
        } // IsEndOfLine()

        /// <summary>
        /// This function checks if - except trailing spaces - the parsing string
        /// is terminated. If so the function returns. Otherwise an EndExpected
        /// exception is thrown with the first next token as parameter.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for CheckEndOfLine are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace =accepts whitespace before and after the parsing
        /// location.</description>
        /// </item>
        /// </list>
        /// </param>
        public void CheckEndOfLine(ParseOptions parseflags)
        {
            if (!this.IsEndOfLine(parseflags))
            {
                this.SetLastToken(this.location, ParseOptions.SetEnd);
                throw new ParsingException(ParsingError.EndExpected, this.GetLastToken());
            } // if
        } // CheckEndOfLine()

        /// <summary>
        /// This function checks if - except trailing spaces - the parsing string
        /// is terminated. If so the function returns. Otherwise an EndExpected
        /// exception is thrown with the first next token as parameter.
        /// </summary>
        public void CheckEndOfLine()
        {
            this.CheckEndOfLine(ParseOptions.SkipSpace);
        } // CheckEndOfLine()

        /// <summary>
        ///  Tests if the next character (after skipping space characters)
        ///  is the specified character. The character is consumed.
        /// </summary>
        /// <param name="ch">The character which is must match.</param>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for IsFixChar are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace =accepts whitespace before and after the parsing
        /// location.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>If the character at the parsing location matches the
        /// specification, TRUE is returned and FALSE if not.</returns>
        public bool IsFixChar(char ch, ParseOptions parseflags)
        {
            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            if ((this.location >= this.text.Length) || (this.text[this.location] != ch))
            {
                // character doesn't match: return FALSE
                return false;
            } // if

            // consume character
            this.location++;

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            // character matches: return TRUE
            return true;
        } // IsFixChar()

        /// <summary>
        ///  Tests if the next character (after skipping space characters)
        ///  is the specified character. The character is consumed.
        /// </summary>
        /// <param name="ch">the character which is must match.</param>
        /// <returns>If the character at the parsing location matches the
        /// specification, TRUE is returned and FALSE if not.</returns>
        public bool IsFixChar(char ch)
        {
            return this.IsFixChar(ch, ParseOptions.None);
        } // IsFixChar()

        /// <summary>
        /// Tests if the next character (after skipping space characters)
        /// is one of the characters in the specified character list. The
        /// character is consumed. The character comparison is case sensitive.
        /// </summary>
        /// <param name="charlist">List of valid characters. The first
        /// character has the return index 1, the next 2 etc.</param>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for CheckEndOfLine are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace =accepts whitespace before and after the parsing
        /// location.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>If the character at the parsing location matches the string,
        /// its index (relative to 1) is returned. If the character doesn't match,
        /// 0 is returned.</returns>
        public int GetFixChar(string charlist, ParseOptions parseflags)
        {
            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            if (this.location >= this.text.Length)
            {
                // end of line: no match
                return 0;
            } // if

            var index = charlist.IndexOf(this.text[this.location]);
            if (index < 0)
            {
                // character not found: no match
                return 0;
            } // if

            // consume character
            this.location++;

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            // return index of character (relative to 1)
            return index + 1;
        } // GetFixChar()

        /// <summary>
        /// Tests if the next character (after skipping space characters)
        /// is one of the characters in the specified character list. The
        /// character is consumed.
        /// </summary>
        /// <param name="charlist">List of valid characters. The first
        /// character has the return index 1, the next 2 etc.</param>
        /// <returns>If the character at the parsing location matches the string,
        /// its index (relative to 1) is returned. If the character doesn't match,
        /// 0 is returned.</returns>
        public int GetFixChar(string charlist)
        {
            return this.GetFixChar(charlist, ParseOptions.None);
        } // GetFixChar()

        /// <summary>
        /// Tests if the next character (after skipping space characters)
        /// is one of the characters in the specified character list. The
        /// character is skipped.
        /// </summary>
        /// <param name="ch">Contains the character which is must match.</param>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for CheckFixChar are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace =accepts whitespace before and after the parsing
        /// location.</description>
        /// </item>
        /// </list>
        /// </param>
        public void CheckFixChar(char ch, ParseOptions parseflags)
        {
            if (!this.IsFixChar(ch, parseflags))
            {
                this.SetLastToken(this.location, ParseOptions.ToSpace);
                throw new ParsingException(ParsingError.SpecNotFound, this.GetLastToken());
            } // if
        } // CheckFixChar()

        /// <summary>
        /// Tests if the next character (after skipping space characters)
        /// is one of the characters in the specified character list. The
        /// character is skipped.
        /// </summary>
        /// <param name="charlist">List of valid characters. The first
        /// character has the return index 1, the next 2 etc.</param>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for CheckFixChar are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace =accepts whitespace before and after the parsing
        /// location.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>If the character at the parsing location matches the string,
        /// its index (relative to 1) is returned. If the character doesn't match,
        /// an exception is thrown.</returns>
        public int CheckFixChar(string charlist, ParseOptions parseflags)
        {
            var index = this.GetFixChar(charlist, parseflags);
            if (index == 0)
            {
                // character doesn't match
                if (this.text.Length > 0)
                {
                    this.SetLastToken(this.location, ParseOptions.ToSpace);
                } // if

                throw new ParsingException(ParsingError.SpecNotFound, this.GetLastToken());
            } // if

            // character matched
            return index;
        } // CheckFixChar()

        /// <summary>
        /// Tests if the next character (after skipping space characters)
        /// is one of the characters in the specified character list. The
        /// character is skipped.
        /// </summary>
        /// <param name="charlist">List of valid characters. The first
        /// character has the return index 1, the next 2 etc.</param>
        /// <returns>If the character at the parsing location matches the string,
        /// its index (relative to 1) is returned. If the character doesn't match,
        /// an exception is thrown.</returns>
        public int CheckFixChar(string charlist)
        {
            return this.CheckFixChar(charlist, ParseOptions.None);
        } // CheckFixChar()

        /// <summary>
        /// Checks if at the current parsing location one or more space
        /// characters follows and skips it. The end of the parsing line is
        /// also accepted. If no space follows, an exception is thrown and
        /// the next token is printed.
        /// </summary>
        public void CheckSpace()
        {
            if (this.location >= this.text.Length)
            {
                // end of line
                return;
            } // if

            if (this.IsSpace())
            {
                // skip determined space & return
                this.SkipSpace();
                return;
            } // if

            // exception: print characters until next space
            this.SetLastToken();
            throw new ParsingException(ParsingError.SpecNotFound, this.GetLastToken());
        } // CheckSpace()

        /// <summary>
        /// Parses the name at the current parsing location and returns its
        /// position in the specified string. The function doesn't select between
        /// uppercase and lowercase characters. Commands may be abbreviated but
        /// must be unambiguous within the specified name list. A command name
        /// may contain all characters in the range A..Z or a..z or
        /// (if Digits is set) also digits in range 0..9.
        /// </summary>
        /// <param name="namelist">String which contains the permitted names,
        /// separated by the horizontal tabulator character (\t). The names must
        /// be specified in lower case.</param>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetFixName are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>Digits = Accept also digits 0..9 in a name.</description>
        /// </item>
        /// <item>
        /// <description>FullName = Accept only full names (no proper abbreviations).</description>
        /// </item>
        /// <item>
        /// <description>ExtraChar = Allow also '_' and '-' within a name.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>The function returns the relative position of the matched name
        /// within the string, started with 1. If no command is specified, 0 is
        /// returned. If the command name is not found, -1 is returned.</returns>
        /// <remarks>
        /// If no name is parsed, the parsing location is not changed. Otherwise (also
        /// if the name is ambiguous) the parsing location is set after the parsed
        /// command. Trailing and leading spaces are only skipped if the option
        /// Space is set.
        /// </remarks>
        public int GetFixName(string namelist, ParseOptions parseflags)
        {
            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            if (this.location >= this.text.Length)
            {
                // end of line: no match
                return -1;
            } // if

            if (namelist.Length == 0)
            {
                // end of line: no match
                return 0;
            } // if

            // save begin of name as token
            this.SetLastToken();

            var sb = new StringBuilder(30);
            while (this.location < this.text.Length)
            {
                var ch = this.text.ToUpperInvariant()[this.location];

                if ((((parseflags & ParseOptions.Digits) > 0)
                  && ch >= '0' && ch <= '9')
                  || (ch >= 'A' && ch <= 'Z')
                  || (((parseflags & ParseOptions.ExtraChar) > 0)
                  && (ch == '_' || ch == '-')))
                {
                    // consume character
                    this.location++;
                }
                else
                {
                    if ((parseflags & ParseOptions.Umlaute) > 0)
                    {
                        // do an additional check for german umlaute
                        if ((ch != 'Ä') && (ch != 'Ö') && (ch != 'Ü') && (ch != 'ß'))
                        {
                            // exit loop
                            break;
                        } // if

                        // consume character
                        this.location++;
                    }
                    else
                    {
                        // exit loop
                        break;
                    } // if
                } // if

                sb.Append(ch);
            } // while

            var chunk = sb.ToString();
            if (chunk.Length < 1)
            {
                // no name parsed
                return -1;
            } // if

            var names = namelist.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var found = -1;
            for (var i = 0; i < names.Length; i++)
            {
                if (names[i].StartsWith(chunk, StringComparison.OrdinalIgnoreCase))
                {
                    // name found: check if not ambiguous
                    if (((parseflags & ParseOptions.FullName) == 0)
                      || (names[i].Length == chunk.Length))
                    {
                        // abbreviation permitted or full name => found
                        if (found > 0)
                        {
                            // ambiguous => throw exception
                            throw new ParsingException(
                                ParsingError.SpecAmbiguous, this.GetLastToken());
                        } // if

                        found = i + 1;
                    } // if
                } // if
            } // for

            // name not found => resetting parsing location
            if (found < 0)
            {
                this.location = this.tokenStart;
            } // if

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            // return index of character (relative to 1)
            return found;
        } // GetFixName()

        /// <summary>
        ///  Converts the specified hexadecimal character ('0'..'9',
        ///  'A'..'F', 'a'..'f') into the binary representation (0..15).
        /// </summary>
        /// <param name="ch">Character to be handled as hex digit.</param>
        /// <returns>Returns the binary representation of the character if it a
        /// hexadecimal character; otherwise -1 is returned.</returns>
        public static int GetHexDigit(char ch)
        {
            var val = -1;

            if (ch < '0')
            {
                // outside any range => no hexadecimal digit
                return val;
            } // if

            if (ch <= '9')
            {
                // range 0..9
                val = ch - '0';
                return val;
            } // if

            if (ch < 'A')
            {
                // between '9'+1 and 'A'-1 => no hexadecimal digit
                return val;
            } // if

            if (ch <= 'F')
            {
                // range 10..15 in uppercase
                val = ch - 'A';
                val += 10;
                return val;
            } // if

            if (ch < 'a')
            {
                // between 'F'+1 and 'a'-1 => no hexadecimal digit
                return val;
            } // if

            if (ch <= 'f')
            {
                // range 10..15 in lowercase
                val = ch - 'a';
                val += 10;
                return val;
            } // if

            // greater 'f' => no valid hexadecimal digit
            return val;
        } // GetHexDigit()

        /// <summary>
        /// Checks whether the specified character is a hexadecimal digit
        /// (0..9, a..f, A..F).
        /// </summary>
        /// <param name="ch">Character to check.</param>
        /// <returns>Returns true if the character is a hexadecimal digit;
        /// otherwise false.</returns>
        public static bool IsHexDigit(char ch)
        {
            if (ch < '0')
            {
                // outside any range => no hexadecimal digit
                return false;
            } // if

            if (ch <= '9')
            {
                // range 0..9
                return true;
            } // if

            if (ch < 'A')
            {
                // between '9'+1 and 'A'-1 => no hexadecimal digit
                return false;
            } // if

            if (ch <= 'F')
            {
                // range 10..15 in uppercase
                return true;
            } // if

            if (ch < 'a')
            {
                // between 'F'+1 and 'a'-1 => no hexadecimal digit
                return false;
            } // if

            if (ch <= 'f')
            {
                // range 10..15 in lowercase
                return true;
            } // if

            return false;
        } // IsHexDigit()

        /// <summary>
        /// Reads an unsigned number in decimal, hexadecimal or optional octal
        /// notation from the parsing location, converts it into its binary
        /// representation and returns this value.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetUnsignedNumber are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// SkipSpace = Accepts whitespace before and after the parsing location.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Hex =  Allow hex digits with leading '0x'.</description>
        /// </item>
        /// <item>
        /// <description>
        /// HexOnly =  accept only hex values without leading '0x'</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="maxValue">
        /// Contains the maximum value which is permitted. If the read value is
        /// larger than this value, the OverflowException exception is thrown.
        /// If this value is 0, no maximum value is checked.
        /// </param>
        /// <returns>Returns the unsigned number read at the current location.</returns>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1720:IdentifiersShouldNotContainTypeNames",
            MessageId = "unsigned",
            Justification = "This is here the best solution!")]
        public uint GetUnsignedNumber(ParseOptions parseflags, uint maxValue)
        {
            if (this.location >= this.text.Length)
            {
                // end of line => spec not found
                throw new ParsingException(
                    ParsingError.NumberExpected, this.GetLastToken());
            } // if

            // check for missing flags
            if (((parseflags & ParseOptions.HexOnly) > 0)
              && ((parseflags & ParseOptions.Hex) == 0))
            {
                parseflags |= ParseOptions.Hex;
            } // if

            uint val;

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            // set token start location
            this.SetLastToken();

            // analyse characters at <location>
            var sb = new StringBuilder(20);

            var isHex = false;
            var leadingX = false;
            while ((this.location < this.text.Length))
            {
                var ch = this.text[this.location];
                var valid = char.IsDigit(ch);
                if ((!valid) && ((parseflags & ParseOptions.Hex) > 0))
                {
                    valid = IsHexDigit(ch);
                    if (valid)
                    {
                        isHex = true;
                    } // if
                } // if

                if (ch == 'x')
                {
                    if (((parseflags & ParseOptions.Hex) > 0)
                      && ((parseflags & ParseOptions.HexOnly) == 0))
                    {
                        leadingX = true;
                        valid = true;
                    }
                    else
                    {
                        // set valid to true in spite of that we should not
                        // handle leading 'x'
                        // => this will then result in a parsing error
                        valid = true;
                    } // if
                } // if

                if (valid)
                {
                    sb.Append(ch);
                }
                else
                {
                    // no number
                    break;
                } // if

                this.location++;
            } // while

            // use .Net method to parse string
            string num = sb.ToString();
            if (leadingX)
            {
                if ((num.Length > 2) && (num[0] == '0'))
                {
                    num = num.Substring(2);
                }
                else
                {
                    throw new ParsingException(
                    ParsingError.NumberExpected, this.GetLastToken());
                } // if
            } // if

            try
            {
                if ((isHex) || ((parseflags & ParseOptions.Hex) > 0)
                  || ((parseflags & ParseOptions.HexOnly) > 0))
                {
                    val = uint.Parse(num, NumberStyles.HexNumber, CultureInfo.CurrentCulture);
                }
                else
                {
                    val = uint.Parse(num, CultureInfo.CurrentCulture);
                } // if
            }
            catch (ArgumentException)
            {
                throw new ParsingException(ParsingError.NumberExpected, this.GetLastToken());
            }
            catch (FormatException)
            {
                throw new ParsingException(ParsingError.NumberExpected, this.GetLastToken());
            } // catch

            if ((maxValue > 0) && (val > maxValue))
            {
                throw new OverflowException("number > maxValue");
            } // if

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            return val;
        } // GetUnsignedNumber()

        /// <summary>
        /// Reads an signed number in decimal, hexadecimal or optional octal
        /// notation from the parsing location, converts it into its binary
        /// representation and returns this value.<br/>
        /// This function is an enhanced version of get GetUnsignedNumber().
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetSignedNumber are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// SkipSpace = Accepts whitespace before and after the parsing location.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Hex =  Allow hex digits with leading '0x'.</description>
        /// </item>
        /// <item>
        /// <description>
        /// HexOnly =  accept only hex values without leading '0x'.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="maxValue">
        /// Contains the maximum value which is permitted. If the read value is
        /// larger than this value, the OverflowException exception is thrown.
        /// If this value is 0, no maximum value is checked.
        /// </param>
        /// <returns>Returns the signed number read at the current location.</returns>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1720:IdentifiersShouldNotContainTypeNames",
            MessageId = "signed",
            Justification = "This is here the best solution!")]
        public int GetSignedNumber(ParseOptions parseflags, int maxValue)
        {
            if (this.location >= this.text.Length)
            {
                // end of line => spec not found
                throw new ParsingException(ParsingError.NumberExpected, this.GetLastToken());
            } // if

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            // set token start location
            this.SetLastToken();

            if (this.location >= this.text.Length)
            {
                // end of line => spec not found
                throw new ParsingException(ParsingError.NumberExpected, this.GetLastToken());
            } // if

            bool minusSign = false;
            if (this.text[this.location] == '-')
            {
                minusSign = true;
                this.location++;
            } // if

            var val = (int)this.GetUnsignedNumber(parseflags, (uint)maxValue);

            if (minusSign)
            {
                val = -val;
            } // if

            return val;
        } // GetSignedNumber()

        /// <summary>
        /// Reads an unsigned decimal number at the parsing location, converts
        /// it into its binary representation and returns this value. If the
        /// SkipSpace flag is set, leading or trailing space characters are
        /// skipped.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetUnsignedDecimal are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// SkipSpace = Accepts whitespace before and after the parsing location.
        /// </description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="maxValue">
        /// Contains the maximum value which is permitted. If the read value is
        /// larger than this value, the OverflowException exception is thrown.
        /// If this value is 0, no maximum value is checked.
        /// </param>
        /// <returns>Returns the unsigned number read at the current location.
        /// </returns>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1720:IdentifiersShouldNotContainTypeNames",
            MessageId = "unsigned",
            Justification = "This is here the best solution!")]
        public uint GetUnsignedDecimal(ParseOptions parseflags, uint maxValue)
        {
            if (this.location >= this.text.Length)
            {
                // end of line => spec not found
                throw new ParsingException(ParsingError.DecimalNumberExpected, this.GetLastToken());
            } // if

            uint val;

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            // set token start location
            this.SetLastToken();

            // analyse characters at <location>
            var sb = new StringBuilder(20);

            while ((this.location < this.text.Length))
            {
                var ch = this.text[this.location];
                var valid = char.IsDigit(ch);

                if (valid)
                {
                    sb.Append(ch);
                }
                else
                {
                    // no number
                    break;
                } // if

                this.location++;
            } // while

            // use .Net method to parse string
            var num = sb.ToString();
            try
            {
                val = uint.Parse(num, CultureInfo.CurrentCulture);
            }
            catch (ArgumentException)
            {
                throw new ParsingException(ParsingError.DecimalNumberExpected, this.GetLastToken());
            }
            catch (FormatException)
            {
                throw new ParsingException(ParsingError.DecimalNumberExpected, this.GetLastToken());
            } // catch

            if ((maxValue > 0) && (val > maxValue))
            {
                throw new OverflowException("number > maxValue");
            } // if

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            return val;
        } // GetUnsignedDecimal()

        /// <summary>
        /// Reads an signed decimal number at the parsing location, converts
        /// it into its binary representation and returns this value. If the
        /// SkipSpace flag is set, leading or trailing space characters are
        /// skipped.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetSignedDecimal are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// SkipSpace = Accepts whitespace before and after the parsing location.
        /// </description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="maxValue">
        /// Contains the maximum value which is permitted. If the read value is
        /// larger than this value, the OverflowException exception is thrown
        /// If this value is 0, no maximum value is checked.
        /// </param>
        /// <returns>Returns the signed number read at the current location.</returns>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1720:IdentifiersShouldNotContainTypeNames",
            MessageId = "signed",
            Justification = "This is here the best solution!")]
        public int GetSignedDecimal(ParseOptions parseflags, int maxValue)
        {
            if (this.location >= this.text.Length)
            {
                // end of line => spec not found
                throw new ParsingException(ParsingError.DecimalNumberExpected, this.GetLastToken());
            } // if

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            // set token start location
            this.SetLastToken();

            if (this.location >= this.text.Length)
            {
                // end of line => spec not found
                throw new ParsingException(ParsingError.DecimalNumberExpected, this.GetLastToken());
            } // if

            var minusSign = false;
            if (this.text[this.location] == '-')
            {
                minusSign = true;
                this.location++;
            } // if

            var val = (int)this.GetUnsignedDecimal(parseflags, (uint)maxValue);

            if (minusSign)
            {
                val = -val;
            } // if

            return val;
        } // GetSignedDecimal()

        /// <summary>
        /// Reads a signed floating point value at the parsing location, converts
        /// it into its binary representation and returns this value. If the
        /// SkipSpace flag is set, leading or trailing space characters are
        /// skipped. The number may be started with a '+' or a '-' character.
        /// Spaces between the leading sign and the first digit are also skipped
        /// if the SkipSpace option is set.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetDouble are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// SkipSpace = Accepts whitespace before and after the parsing location.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Comma = Besides '.' also ',' is allowed as decimal separator.
        /// </description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>Returns the number read at the current location.</returns>
        public double GetDouble(ParseOptions parseflags)
        {
            if (this.location >= this.text.Length)
            {
                // end of line => spec not found
                throw new ParsingException(ParsingError.FloatNumberExpected, this.GetLastToken());
            } // if

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            // set token start location
            this.SetLastToken();

            if (this.location >= this.text.Length)
            {
                // end of line => spec not found
                throw new ParsingException(ParsingError.FloatNumberExpected, this.GetLastToken());
            } // if

            var minusSign = false;
            if (this.text[this.location] == '-')
            {
                minusSign = true;
                this.location++;
            }
            else if (this.text[this.location] == '+')
            {
                this.location++;
            } // if

            var intval = (int)this.GetUnsignedDecimal(parseflags, 0);
            var intval2 = 0;
            var pos = this.location;

            if ((this.text[this.location] == '.')
              || (((parseflags & ParseOptions.Comma) > 0)
              && (this.text[this.location] == ',')))
            {
                // decimal separator found
                this.location++;
                pos = this.location;
                intval2 = (int)this.GetUnsignedDecimal(parseflags, 0);
            } // if

            double val = intval;

            if (intval2 > 0)
            {
                double df2 = intval2;
                var digits = (this.location - pos);
                val += (df2 / Math.Pow(10, digits));
            } // if

            if (minusSign)
            {
                val = -val;
            } // if

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                // skip spaces before next character
                this.SkipSpace();
            } // if

            return val;
        } // GetDouble()

        /// <summary>
        /// Parses a string at the current parsing location and stores it into the
        /// specified CTgString parameter. In dependence of the specified options,
        /// the string may be quoted or unquoted. In the first case, it is
        /// encapsulated with "...". Spaces before the first between
        /// and after the final double quote are ignored if the SkipSpace flag
        /// is specified. Unquoted strings are terminated by a space or tabulate
        /// character or the end of the parsing string or any other separator
        /// character defined by SetWhitespaceList().<br/>
        /// Leading spaces before an unquoted string are not permitted. Subsequent
        /// quoted strings are concatenated by removing the quotation characters
        /// and optionally the space characters between the strings.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetSignedDecimal are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// SkipSpace = Accepts whitespace before and after the parsing location.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Quoted = specifies that the string must be specified in quotes. If
        /// this flag is not specified, the string may be specified optionally
        /// without quotes, but it is limited by the first subsequent space or
        /// tabulator character.
        /// </description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>The string read a the current parsing location.</returns>
        public string GetQuotedString(ParseOptions parseflags)
        {
            var quoted = false;

            if (this.location >= this.text.Length)
            {
                // end of parsing line: throw exception
                throw new ParsingException(ParsingError.StringExpected, this.GetLastToken());
            } // if

            // determine start of string
            if (this.IsSpace())
            {
                // leading space: quoted string or empty string
                this.SetLastToken();
                if ((parseflags & ParseOptions.SkipSpace) > 0)
                {
                    this.SkipSpace();
                } // if
            } // if

            // set token position to real start
            this.SetLastToken();
            if (this.text[this.location] == '\"')
            {
                // quoted string
                quoted = true;
                this.location++;
            }
            else if (this.location >= this.text.Length)
            {
                // end of parsing line: throw exception
                throw new ParsingException(ParsingError.StringExpected, this.GetLastToken());
            }
            else if ((parseflags & ParseOptions.Quoted) > 0)
            {
                // no quotes & string must be quoted: throw exception
                throw new ParsingException(ParsingError.StringExpected, this.GetLastToken());
            } // if

            var sb = new StringBuilder(255);
            while (this.location < this.text.Length)
            {
                // get & consume current character
                var ch = this.text[this.location++];

                if (quoted && ch == '\"')
                {
                    // quote character: check if further string follows
                    if ((parseflags & ParseOptions.SkipSpace) > 0)
                    {
                        this.SkipSpace();
                    } // if

                    if ((this.location < this.text.Length)
                        && (this.text[this.location] == '\"'))
                    {
                        // next string follows immediately: skip & ignore both
                        // quote chars
                        this.location++;
                    }
                    else
                    {
                        // end of string: exit loop
                        quoted = false;
                        break;
                    } // if
                }
                else if (!quoted && (this.IsSpace(ch)))
                {
                    // end of non-quoted/skip-space string: exit loop
                    // * this character is not consumed
                    this.location--;
                    break;
                }
                else if (ch >= 0 && ch < ' ')
                {
                    // store this character as new line begin
                    sb.Append('\n');

                    // skip next character if sequence is \n\r or \r\n
                    var next = this.text[this.location];
                    if ((next == '\n' || next == '\r') && (ch ^ next) ==
                     ('\n' ^ '\r'))
                    {
                        this.location++;
                    } // if
                }
                else
                {
                    // store all other characters without change
                    sb.Append(ch);
                } // if
            } // while

            if (quoted)
            {
                // infinite string in current line
                throw new ParsingException(ParsingError.StringEndExpected, this.GetLastToken());
            } // if

            return sb.ToString();
        } // GetQuotedString()

        /// <summary>
        /// Returns the next token, i.e. next next continuous string of characters
        /// starting at the current parsing location, that does not contain
        /// any whitespace characters.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetNextToken are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace = accepts whitespace before and after the
        /// parsing location.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>The token is returned.</returns>
        public string GetNextToken(ParseOptions parseflags)
        {
            var sb = new StringBuilder(30);

            if (this.IsEndOfLine(parseflags))
            {
                // check for end of line,
                // includes skipping spaces before next character
                return string.Empty;
            } // if

            while ((this.location < this.text.Length) && (!this.IsSpace()))
            {
                sb.Append(this.text[this.location]);
                this.location++;
            } // while

            if ((parseflags & ParseOptions.SkipSpace) > 0)
            {
                this.SkipSpace();
            } // if

            return sb.ToString();
        } // GetNextToken()

        /// <summary>
        /// Returns the next token, i.e. next next continuous string of
        /// characters starting at the current parsing location, that does not
        /// contain any whitespace characters.
        /// </summary>
        /// <returns>The token is returned.</returns>
        public string GetNextToken()
        {
            return this.GetNextToken(ParseOptions.None);
        } // GetNextToken()

        /// <summary>
        /// Skips the next token, i.e. next next continuous string of characters
        /// starting at the current parsing location, that does not contain
        /// any whitespace characters.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for SkipNextToken are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace = accepts whitespace before and after the
        /// parsing location.</description>
        /// </item>
        /// </list>
        /// </param>
        public void SkipNextToken(ParseOptions parseflags)
        {
            this.GetNextToken(parseflags);
        } // SkipNextToken()

        /// <summary>
        /// Skips the next token, i.e. next next continuous string of characters
        /// starting at the current parsing location, that does not contain
        /// any whitespace characters.
        /// </summary>
        public void SkipNextToken()
        {
            this.SkipNextToken(ParseOptions.None);
        } // SkipNextToken()

        /// <summary>
        /// Returns the next line of text starting with the current position
        /// and ending with CR/LF or LF/CR.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetNextToken are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>SkipSpace = accepts whitespace before the parsing
        /// location.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>The next line of text.</returns>
        public string GetNextLine(ParseOptions parseflags)
        {
            if (this.location >= this.text.Length)
            {
                return string.Empty;
            } // if

            // determine start of string
            if (this.IsSpace())
            {
                this.SetLastToken();

                // skip leading space
                if ((parseflags & ParseOptions.SkipSpace) > 0)
                {
                    this.SkipSpace();
                } // if
            } // if

            // set token position to real start
            this.SetLastToken();
            if (this.location >= this.text.Length)
            {
                // end of parsing line: throw exception
                throw new ParsingException(ParsingError.SpecNotFound, this.GetLastToken());
            } // if

            var sb = new StringBuilder(255);

            // read string until end
            while (this.location < this.text.Length)
            {
                // get & consume current character
                var ch = this.text[this.location++];

                if ((this.location < this.text.Length) && (ch < ' '))
                {
                    // stop reading if sequence is \n\r or \r\n
                    char next = this.text[this.location];
                    if ((next == '\n' || next == '\r') && (ch ^ next) ==
                     ('\n' ^ '\r'))
                    {
                        this.location++;
                        break;
                    } // if

                    // store this character as new line begin
                    sb.Append('\n');
                }
                else
                {
                    // store all other characters without change
                    sb.Append(ch);
                } // if
            } // while

            return sb.ToString();
        } // GetNextLine()

        /// <summary>
        /// Returns the next line of text starting with the current position
        /// and ending with CR/LF or LF/CR.
        /// </summary>
        /// <returns>The next line of text.</returns>
        public string GetNextLine()
        {
            return this.GetNextLine(ParseOptions.SkipSpace);
        } // GetNextLine()

        /// <summary>
        /// Skips the space area at the current location.
        /// </summary>
        public void SkipSpace()
        {
            while ((this.location < this.text.Length) && (this.IsSpace()))
            {
                this.location++;
            } // if
        } // SkipSpace()

        /// <summary>
        /// Checks if a true space area follows. This area is not consumed.
        /// </summary>
        /// <param name="ch">Character to check.</param>
        /// <returns>
        /// Returns TRUE if a valid space area follows and FALSE if not.
        /// </returns>
        public bool IsSpace(char ch)
        {
            for (var i = 0; i < this.whiteSpaceList.Length; i++)
            {
                if (this.whiteSpaceList[i] == ch)
                {
                    return true;
                } // if
            } // for

            // this is not a whitespace
            return false;
        } // IsSpace()

        /// <summary>
        /// Checks if a true space area follows at the current parsing location.
        /// This area is not consumed.
        /// </summary>
        /// <returns>
        /// Returns TRUE if a valid space area follows and FALSE if not.
        /// </returns>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "This parameter is the better help for the developer")]
        public bool IsSpace()
        {
            if ((this.location < 0) || (this.location >= this.text.Length))
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentOutOfRangeException("location");
                // ReSharper restore NotResolvedInText
            } // if

            return this.IsSpace(this.text[this.location]);
        } // IsSpace()

        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (this.location >= this.text.Length)
            {
                return "0, <empty>";
            } // if

            var str = string.Format(
                CultureInfo.CurrentUICulture,
                "{0}, \"{1}\"",
                this.location,
                this.text.Substring(this.location));

            return str;
        } // ToString()
        #endregion // PUBLIC METHODS

        //// ------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Determines the end position of the last token and saves it
        /// to the tokenEnd.
        /// </summary>
        /// <param name="parseflags">
        /// Parsing flags. Valid flags for GetLastToken are:<br/>
        /// <list type="bullet">
        /// <item>
        /// <description>ToSpace = limit end of the token to the next space area.
        /// </description>
        /// </item>
        /// <item>
        /// <description>ToLocation = limit end of the token to the current
        /// location. If both options are set, the first end location is used.
        /// </description>
        /// </item>
        /// <item>
        /// <description>ToEnd = activates the determining of the token-end
        /// which must be set when no other flags are set.</description>
        /// </item>
        /// </list>
        /// </param>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "This parameter is the better help for the developer")]
        private void DetermineLastTokenEnd(ParseOptions parseflags)
        {
            if (this.tokenStart < 0)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentOutOfRangeException("tokenStart");
                // ReSharper restore NotResolvedInText
            } // if

            if (this.tokenStart >= this.text.Length)
            {
                this.tokenEnd = this.tokenStart;
                return;
            } // if

            int end = this.tokenStart;

            if (parseflags == ParseOptions.None)
            {
                end = this.text.Length - 1;
            }
            else if (parseflags == ParseOptions.ToLocation)
            {
                // set current location as end
                Debug.Assert(
                    this.location >= this.tokenStart,
                    "Invalid token position");
                end = this.location;
            }
            else
            {
                // search next space location
                while ((end < this.text.Length)
                  && (!this.IsSpace(this.text[end])))
                {
                    end++;
                } // while

                if (((parseflags & ParseOptions.ToLocation) > 0)
                    && (end > this.location))
                {
                    end = this.location;
                } // if
            } // if

            // save last-token end position (at first character after token)
            this.tokenEnd = end;
        } // DetermineLastTokenEnd()
        #endregion // PRIVATE METHODS
    } // TextParse
} // Tethys.Text

// ===================
// End of TextParse.cs
// ===================
