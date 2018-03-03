#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common for .Net Windows applications.
//
// ===========================================================================
//
// <copyright file="TethysAppConfig.cs" company="Tethys">
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

namespace Tethys.App
{
    using System.Reflection;
    using System.Xml;

    /// <summary>
    /// This class stores the application configuration. At the beginning
    /// of the application all the properties are read from either the
    /// registry or an XML fileName. At the end of the application the data
    /// is stored again.
    /// </summary>
    public class TethysAppConfig : TethysAppConfigBase
    {
        #region PUBLIC PROPERTIES
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="TethysAppConfig"/> class.
        /// </summary>
        /// <param name="applicationAssembly">The application assembly.</param>
        public TethysAppConfig(Assembly applicationAssembly) : base(applicationAssembly)
        {
        } // TethysAppConfig()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region PROTECTED METHODS
        #region VIRTUAL (EMPTY) METHODS
        /// <summary>
        /// Core function to write the application data.
        /// </summary>
        /// <param name="xmlWriter">The XML writer.</param>
        protected virtual void WriteData(TethysXmlTextWriter xmlWriter)
        {
        } // WriteData()

        /// <summary>
        /// Core function to read the application data.
        /// </summary>
        /// <param name="xmlReader">The XML reader.</param>
        protected virtual void ReadData(TethysXmlTextReader xmlReader)
        {
        } // ReadData()
        #endregion // VIRTUAL (EMPTY) METHODS
        #endregion // PROTECTED METHODS

        #region PUBLIC METHODS
        /// <summary>
        /// This function writes the (user dependent) application configuration
        /// to a XML fileName that is located in the path for the application data
        /// of a roaming user, i.e. something like:
        /// Base Path\CompanyName\ProductName\filename
        /// </summary>
        /// <param name="fileName">Name of the XML fileName to be used</param>
        /// <returns>
        /// The function returns true if all configuration data has
        /// been successfully written; otherwise false will be returned.
        /// </returns>
        /// <remarks>
        /// The function does not throw ANY exceptions. All exceptions will be
        /// caught inside of WriteXml().
        /// </remarks>
        public bool Write(string fileName)
        {
            // generate complete filename
            fileName = this.GetCompleteFilename(fileName);

            // Do NOT use UNICODE, because some of the target operating
            // system like Win 98, Win ME can't handle it
            // Do NOT use ASCII, since this does not support german umlaute.
            var xmlwriter = new TethysXmlTextWriter(fileName,
              this.Encoding);
            xmlwriter.XmlWriter.WriteStartDocument(false);
            xmlwriter.XmlWriter.Formatting = Formatting.Indented;
            xmlwriter.XmlWriter.Indentation = 2;

            this.WriteData(xmlwriter);

            xmlwriter.XmlWriter.Flush();
            xmlwriter.XmlWriter.Close();

            return true;
        } // WriteXml()

        /// <summary>
        /// This function reads the (user dependent) application configuration
        /// from a XML fileName that is located in the path for the application data
        /// of a roaming user, i.e. something like:
        ///   Base Path\CompanyName\ProductName\filename
        /// </summary>
        /// <remarks>
        /// This is the SAX-like version.
        /// The function does not throw ANY exceptions. All exceptions will be
        /// caught inside of ReadXml(). 
        /// </remarks>
        /// <param name="fileName">Name of the XML fileName to be used</param>
        /// <returns>The function returns true if all configuration data has
        /// been successfully read; otherwise false will be returned.
        /// </returns>
        public bool Read(string fileName)
        {
            // generate complete filename
            fileName = this.GetCompleteFilename(fileName);

            var xmlreader = new TethysXmlTextReader(fileName);
            xmlreader.WhitespaceHandling = WhitespaceHandling.None;

            try
            {
                this.ReadData(xmlreader);
            }
            finally
            {
                xmlreader.Close();
            } // finally
            return true;
        } // ReadXml()
        #endregion // PUBLIC METHODS
    } // TethysAppConfig
} // Tethys.App

// =================================
// Tethys: end of TethysAppConfig.cs
// =================================
