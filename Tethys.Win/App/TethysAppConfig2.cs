#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common for .Net Windows applications.
//
// ===========================================================================
//
// <copyright file="TethysAppConfig2.cs" company="Tethys">
// Copyright  1998-2018 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2017
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.App
{
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// This class stores the application configuration. At the beginning
    /// of the application all the properties are read from either the
    /// registry or an XML fileName. At the end of the application the data
    /// is stored again.
    /// </summary>
    public class TethysAppConfig2 : TethysAppConfigBase
    {
        #region PUBLIC PROPERTIES
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="TethysAppConfig2"/> class.
        /// </summary>
        /// <param name="applicationAssembly">The application assembly.</param>
        public TethysAppConfig2(Assembly applicationAssembly) : base(applicationAssembly)
        {
        } // TethysAppConfig2()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region PROTECTED METHODS
        #region VIRTUAL (EMPTY) METHODS
        /// <summary>
        /// Reads the application configuration from a string.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <returns>The function returns true if all configuration data has
        /// been successfully read; otherwise false will be returned.
        /// </returns>
        protected virtual bool ReadFromString(string fileContents)
        {
            return true;
        } // ReadFromString()

        /// <summary>
        /// Writes the configuration to an <see cref="XDocument"/>.
        /// </summary>
        /// <returns>An <see cref="XDocument"/>.</returns>
        public virtual XDocument WriteToXDocument()
        {
            return null;
        } // WriteToXDocument()
        #endregion // VIRTUAL (EMPTY) METHODS
        #endregion // PROTECTED METHODS

        //// ---------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// This function writes the (user dependent) application configuration
        /// to an XML file that is located in the path for the application data
        /// of a roaming user, i.e. something like:
        /// Base Path\CompanyName\ProductName\filename
        /// </summary>
        /// <param name="fileName">Name of the XML fileName to be used</param>
        public void WriteToFile(string fileName)
        {
            // generate complete filename
            fileName = this.GetCompleteFilename(fileName);

            // we have to delete the previous files, because
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            } // if

            using (var stream = File.OpenWrite(fileName))
            {
                this.WriteToFile(stream);
            } // using
        } // WriteToFile()

        /// <summary>
        /// This function writes the (user dependent) application configuration to 
        /// the given file stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void WriteToFile(Stream stream)
        {
            using (var sw = new StreamWriter(stream, this.Encoding))
            {
                var xdoc = this.WriteToXDocument();
                xdoc?.Save(sw);
                sw.Flush();
            } // using
        } // WriteToFile()

        /// <summary>
        /// This function reads the (user dependent) application configuration
        /// from a XML file that is located in the path for the application data
        /// of a roaming user, i.e. something like:
        ///   Base Path\CompanyName\ProductName\filename
        /// </summary>
        /// <param name="fileName">Name of the XML fileName to be used</param>
        /// <returns>The function returns true if all configuration data has
        /// been successfully read; otherwise false will be returned.
        /// </returns>
        public bool ReadFromFile(string fileName)
        {
            // generate complete filename
            fileName = this.GetCompleteFilename(fileName);

            var encoding = this.Encoding;
            using (var stream = File.OpenRead(fileName))
            {
                return this.ReadFromFile(stream, encoding);
            } // using
        } // ReadFromFile()

        /// <summary>
        /// This function reads the (user dependent) application configuration
        /// from a XML file using the given encoding
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>The function returns true if all configuration data has
        /// been successfully read; otherwise false will be returned.
        /// </returns>
        public bool ReadFromFile(Stream stream, Encoding encoding)
        {
            using (var sr = new StreamReader(stream, encoding))
            {
                return this.ReadFromString(sr.ReadToEnd());
            } // using
        } // ReadFromFile()

        //// ===== Taken from Tethys.XmlSupport =====

        /// <summary>
        /// Gets the attribute value.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="throwException">if set to <c>true</c> throws an exception
        /// if the node was not found.</param>
        /// <returns>The requested attribute value.</returns>
        public static string GetAttributeValue(XElement parent, string name, bool throwException = true)
        {
            var attribute = parent.Attributes().FirstOrDefault(e => e.Name.LocalName == name);
            if (attribute == null)
            {
                if (throwException)
                {
                    throw new XmlException($"No attribute '{name}' found!");
                } // if

                return null;
            } // if

            return attribute.Value;
        } // GetAttributeValue()

        /// <summary>
        /// Gets the first sub node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="throwException">if set to <c>true</c> throws an exception
        /// if the node was not found.</param>
        /// <returns>The requested sub node.</returns>
        public static XElement GetFirstSubNode(XContainer parent, string name, bool throwException = true)
        {
            var nodes = parent.Elements().Where(e => e.Name.LocalName == name);
            var xnode = nodes.FirstOrDefault();
            if ((xnode == null) && throwException)
            {
                throw new XmlException($"No node '{name}' found!");
            } // if

            return xnode;
        } // GetFirstSubNode()

        /// <summary>
        /// Gets the value of the first sub node with the given name.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="throwException">if set to <c>true</c> throws an exception
        /// if the node was not found.</param>
        /// <returns>The requested sub node value as string.</returns>
        public static string GetFirstSubNodeValue(XContainer parent, string name, bool throwException = true)
        {
            var nodes = parent.Elements().Where(e => e.Name.LocalName == name);
            var xnode = nodes.FirstOrDefault();
            if (xnode == null)
            {
                if (throwException)
                {
                    throw new XmlException($"No node '{name}' found!");
                } // if

                return null;
            } // if

            return xnode.Value;
        } // GetFirstSubNode()
        #endregion // PUBLIC METHODS
    } // TethysAppConfig2
} // Tethys.App
