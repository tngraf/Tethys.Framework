﻿// ---------------------------------------------------------------------------
// <copyright file="TethysXmlTextWriter.cs" company="Tethys">
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
namespace Tethys.App
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// An enhanced XmlTextWriter.
    /// </summary>
    public class TethysXmlTextWriter : IDisposable
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Internal XML writer object.
        /// </summary>
        private readonly XmlTextWriter writer;

        /// <summary>
        /// Internal property: use XmlConvert for type conversions (otherwise
        /// the default conversion function are used).
        /// </summary>
        private bool useXmlConvert;
        #endregion // PRIVATE PROPERTIES

        //// ------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the internal XML writer object.
        /// </summary>
        public XmlTextWriter XmlWriter
        {
            get { return this.writer; }
        } // XmlWriter

        /// <summary>
        /// Gets or sets a value indicating whether to use XmlConvert for type
        /// conversions (otherwise the default conversion function are used).
        /// </summary>
        public bool UseXmlConvert
        {
            get { return this.useXmlConvert; }
            set { this.useXmlConvert = value; }
        } // UseXmlConvert
        #endregion // PUBLIC PROPERTIES

        //// ------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="TethysXmlTextWriter"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public TethysXmlTextWriter(TextWriter writer)
        {
            this.writer = new XmlTextWriter(writer);
        } // TgXmlTextWriter()

        /// <summary>
        /// Initializes a new instance of the <see cref="TethysXmlTextWriter"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="encoding">The encoding.</param>
        public TethysXmlTextWriter(string fileName, Encoding encoding)
        {
            this.writer = new XmlTextWriter(fileName, encoding);
        } // TgXmlTextWriter()
        #endregion // CONSTRUCTION

        //// ------------------------------------------------------------------

        #region PUBLIC ELEMENT WRITER METHODS
        /// <summary>
        /// When overridden in a derived class, writes an element with the
        /// specified local name and value.
        /// </summary>
        /// <param name="localName">Name of the local.</param>
        /// <param name="value">The value.</param>
        public void WriteElementString(string localName, string value)
        {
            this.writer.WriteElementString(localName, value);
        } // WriteElementString()

        /// <summary>
        /// Writes the specified integer value a XML node.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="value">The value.</param>
        public void WriteElementInteger(string nodeName, int value)
        {
            if (this.useXmlConvert)
            {
                this.writer.WriteElementString(nodeName, XmlConvert.ToString(value));
            }
            else
            {
                this.writer.WriteElementString(nodeName, value.ToString(CultureInfo.CurrentCulture));
            } // if
        } // WriteElementInteger()

        /// <summary>
        /// Writes the specified double value a XML node.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="value">The value.</param>
        public void WriteElementDouble(string nodeName, double value)
        {
            if (this.useXmlConvert)
            {
                this.writer.WriteElementString(nodeName, XmlConvert.ToString(value));
            }
            else
            {
                this.writer.WriteElementString(nodeName, value.ToString(CultureInfo.CurrentCulture));
            } // if
        } // WriteElementDouble()

        /// <summary>
        /// Writes the specified boolean value a XML node.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void WriteElementBool(string nodeName, bool value)
        {
            if (value)
            {
                this.writer.WriteElementString(nodeName, "1");
            }
            else
            {
                this.writer.WriteElementString(nodeName, "0");
            } // if
        } // WriteElementBool()
        #endregion // PUBLIC ELEMENT WRITER METHODS

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            this.Dispose(true);

            // Suppress finalization.
            GC.SuppressFinalize(this);
        } // Dispose()

        /// <summary>
        /// Releases unmanaged and managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            this.writer?.Dispose();
        } // Dispose()
    } // TethysXmlTextWriter
} // Tethys.App

// =====================================
// Tethys: end of TethysXmlTextWriter.cs
// =====================================
