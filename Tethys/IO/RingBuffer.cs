// --------------------------------------------------------------------------
// Tethys.Framework
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="RingBuffer.cs" company="Tethys">
// Copyright  1998-2020 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing,
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied.
// </copyright>
//
// System ... Library netstandard2.0
// Tools .... Microsoft Visual Studio 2019
//
// ---------------------------------------------------------------------------

namespace Tethys.IO
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// This class implements a circular buffer, i.e new incoming data that does not
    /// fit in the buffer overwrites the data at the beginning of the buffer. This is
    /// the official definition of a ring buffer. The ring buffer implemented here was
    /// designed to get primarily a text ring buffer, that concatenates incoming text
    /// to the text already in the buffer. To achieve this the current contents of the
    /// buffer is moved within the buffer so that the first characters are cut off and the
    /// new text fits completely at the end of the buffer. The advantage of this
    /// architecture is a very simple and fast GetData() function.
    /// </summary>
    public class RingBuffer
    {
        // TODO: TG: reimplement using MemoryStream!

        /// <summary>
        /// Default size for the ring buffer.
        /// </summary>
        public const int DefaultSize = 100;

        /// <summary>
        /// Internal property: current size of the ring buffer in characters.
        /// </summary>
        private int size;

        /// <summary>
        /// Internal property: current (insert) position within the ring buffer.
        /// </summary>
        private int position;

        /// <summary>
        /// Internal property: the character ring buffer.
        /// </summary>
        private char[] buffer;

        #region ACCESS FUNCTIONS FOR PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the current size of the ring buffer in characters.
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
                this.Init();
            }
        } // Size

        /// <summary>
        /// Gets the current (insert) position within the ring buffer.
        /// </summary>
        public int Position
        {
            get
            {
                return this.position;
            }
        } // Position
        #endregion // ACCESS FUNCTIONS FOR PUBLIC PROPERTIES

        /// <summary>
        /// Initializes a new instance of the <see cref="RingBuffer"/> class.
        /// </summary>
        public RingBuffer()
        {
            this.size = DefaultSize;
            this.Init();
        } // RingBuffer()

        /// <summary>
        /// Initializes a new instance of the <see cref="RingBuffer"/> class.
        /// </summary>
        /// <param name="size">Size in characters of the ring buffer.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">size;
        /// size must be > 0.</exception>
        public RingBuffer(int size)
        {
            if (size == 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(size), "size must be > 0");
            } // if

            this.size = size;
            this.Init();
        } // RingBuffer()

        /// <summary>
        /// This function resets the ring buffer, i.e. the current insert
        /// position is set to the beginning of the buffer.
        /// </summary>
        public void Reset()
        {
            this.position = 0;
        } // Reset()

        /// <summary>
        /// This function adds string data to the ring buffer.
        /// </summary>
        /// <param name="data">The data.</param>
        public void AddData(string data)
        {
            this.AddData(data.ToCharArray(), data.Length);
        } // AddData()

        /// <summary>
        /// This function adds character data to the ring buffer.
        /// </summary>
        /// <param name="data">array of characters.</param>
        /// <param name="count">umber of characters to be added.</param>
        public void AddData(char[] data, int count)
        {
            int i;

            if (count > this.size)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(count), "ring buffer too small");
            } // if

            if (this.position + count < this.size)
            {
                // new data fits into buffer
                for (i = 0; i < count; i++)
                {
                    this.buffer[this.position + i] = data[i];
                } // for

                this.position = this.position + count;
            }
            else
            {
                // overflow
                var diff = this.position + count - this.size;

                // move current data
                for (i = 0; i < this.size - diff; i++)
                {
                    this.buffer[i] = this.buffer[diff + i];
                } // for

                // add new data
                for (i = 0; i < count; i++)
                {
                    this.buffer[this.position - diff + i] = data[i];
                } // for

                this.position = this.size;
            } // if
        } // AddData()

        /// <summary>
        /// This function returns the (complete) current contents of the ring
        /// buffer.
        /// </summary>
        /// <returns>
        /// String containing the complete current contents of the ring buffer.
        /// </returns>
        public string GetData()
        {
            return this.GetData(this.position);
        } // GetData()

        /// <summary>
        /// This function returns the current contents of the ring buffer.
        /// </summary>
        /// <param name="count">maximum number of characters to return.</param>
        /// <returns>
        /// String containing up to count characters of the  contents of the
        /// ring buffer.
        /// </returns>
        public string GetData(int count)
        {
            var help = count;
            if (help > this.position)
            {
                help = this.position;
            } // if

            var data = new string(this.buffer, 0, help);

            return data;
        } // GetData()

        /// <summary>
        /// This function consumes the specified amount of data characters,
        /// i.e. the internal start of data pointer is increased by the given
        /// amount.
        /// </summary>
        /// <param name="amount">number of characters to consume.</param>
        public void Consume(int amount)
        {
            if (amount > this.size)
            {
                // throw new ArgumentOutOfRangeException("amount",
                //  "ring buffer smaller than amount");
                // consume ALL data
                this.position = 0;
            } // if

            if (amount > this.position)
            {
                // consume ALL data
                this.position = 0;
            }
            else
            {
                int diff = this.position - amount;

                // move buffer contents, skipping the first <amount> characters
                // memmove(mpabBuffer, mpabBuffer + cbData, nDiff);
                int i;
                for (i = 0; i < diff; i++)
                {
                    this.buffer[i] = this.buffer[this.position - diff + i];
                } // for

                this.position = diff;
            } // if
        } // Consume()

        /// <summary>
        /// This function returns the next full line from the ring buffer.
        /// If no line end delimiter ('\n') is found an empty string will be
        /// returned.
        /// </summary>
        /// <remarks>
        /// Expected is CR/LF = "\r\n" = 0x0D 0x0A.<br/>
        /// Also allowed is only LF = '\n' = 0x0A.<br/>
        /// <b>NOT</b> allowed is only CR = '\r' = 0x0D !!!!.<br/>
        /// </remarks>
        /// <returns>The next line.</returns>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1024:UsePropertiesWhereAppropriate",
            Justification = "Best solution here.")]
        public string GetNextLine()
        {
            var strReturn = string.Empty;

            // find end of line: delimiters are '\n' or '\r\n'
            var endPos = 0;

            while ((endPos < this.position)
              && (this.buffer[endPos] != '\n'))
            {
                endPos++;
            } // while

            // do we really have a line end or a buffer end
            if ((endPos == this.position) || (this.buffer[endPos] != '\n'))
            {
                // no line end found
                // -> return empty string
                return strReturn;
            } // if

            endPos += 1;

            // create return string
            strReturn = new string(this.buffer, 0, endPos);

            return strReturn;
        } // GetNextLine()

        /// <summary>
        /// Initializes a new buffer of the given size.
        /// </summary>
        private void Init()
        {
            this.position = 0;
            this.buffer = new char[this.size];
        } // Init()
    } // RingBuffer
} // Tethys.IO

// ==============================================
// software/projects/Tethys: end of ringbuffer.cs
// ==============================================