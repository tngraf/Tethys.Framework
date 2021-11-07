// ---------------------------------------------------------------------------
// <copyright file="TethysXmlTextReader.cs" company="Tethys">
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
    using System.Xml;

    /// <summary>
    /// An enhanced XmlTextReader.
    /// </summary>
    public class TethysXmlTextReader : XmlTextReader
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets a value indicating whether to use XmlConvert for type
        /// conversions (otherwise the default conversion function are used).
        /// </summary>
        public bool UseXmlConvert { get; set; } // UseXmlConvert
        #endregion // PUBLIC PROPERTIES

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="TethysXmlTextReader"/> class.
        /// </summary>
        protected TethysXmlTextReader()
        {
            // nothing to do
        } // TgXmlTextReader()

        /// <summary>
        /// Initializes a new instance of the <see cref="TethysXmlTextReader"/> class.
        /// </summary>
        /// <param name="file">The fileName.</param>
        public TethysXmlTextReader(string file)
            : base(file)
        {
            // nothing to do
        } // TgXmlTextReader()
        #endregion // CONSTRUCTION

        #region PUBLIC ELEMENT READER METHODS
        /// <summary>
        /// Returns the next node with the given name as string.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>The string.</returns>
        public string ReadString(string nodeName)
        {
            return this.GetNextNode(nodeName);
        } // ReadString()

        /// <summary>
        /// Returns the next node with the given name as integer value.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>The integer value.</returns>
        public int ReadElementInteger(string nodeName)
        {
            if (this.UseXmlConvert)
            {
                return XmlConvert.ToInt32(this.GetNextNode(nodeName));
            } // if

            return int.Parse(this.GetNextNode(nodeName), CultureInfo.CurrentCulture);
        } // ReadElementInteger()

        /// <summary>
        /// Returns the next node with the given name as double value.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>The double value.</returns>
        public double ReadElementDouble(string nodeName)
        {
            if (this.UseXmlConvert)
            {
                return XmlConvert.ToDouble(this.GetNextNode(nodeName));
            } // if

            return double.Parse(this.GetNextNode(nodeName), CultureInfo.CurrentCulture);
        } // ReadElementDouble()

        /// <summary>
        /// Returns the next node with the given name as boolean value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The boolean value.</returns>
        public bool ReadElementBool(string value)
        {
            if (this.UseXmlConvert)
            {
                return (XmlConvert.ToInt32(this.GetNextNode(value)) != 0);
            } // if

            return (int.Parse(this.GetNextNode(value), CultureInfo.CurrentCulture) != 0);
        } // ReadElementBool()

        /// <summary>
        /// Helper function: searches for the next node with the
        /// the specified node name.
        /// </summary>
        /// <param name="nodeName">Expected name of the node.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown if the specified node is not found.
        /// </exception>
        public void SearchNodeName(string nodeName)
        {
            do
            {
                if ((this.NodeType == XmlNodeType.Element)
                  && (this.LocalName == nodeName))
                {
                    return;
                } // if

                this.Read();
            }
            while (!this.EOF);

            throw new ArgumentException("Requested node not found");
        } // SearchNodeName()
        #endregion // PUBLIC ELEMENT READER METHODS

        #region PRIVATE METHODS
        /// <summary>
        /// Helper function: returns the value for the specified text node
        /// or throws an exception if the node is not found.
        /// </summary>
        /// <param name="nodeName">Name of the node to be read.</param>
        /// <returns>The value for the specified text node.</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown if the specified node is not found.
        /// </exception>
        protected string GetNextNode(string nodeName)
        {
            do
            {
                if ((this.NodeType == XmlNodeType.Element)
                  && (this.LocalName == nodeName))
                {
                    return this.ReadInnerXml();
                } // if

                this.Read();
            }
            while (!this.EOF);

            throw new ArgumentException("Requested node not found");
        } // GetNextNode()
        #endregion // PRIVATE METHODS
    } // TethysXmlTextReader
} // Tethys.App

// =====================================
// Tethys: end of TethysXmlTextReader.cs
// =====================================
