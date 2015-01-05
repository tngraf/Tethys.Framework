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
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Locations to store the application configuration.
    /// </summary>
    public enum ConfigLocation
    {
        /// <summary>
        /// User specific path, i.e. ...\Documents and Settings\user\ApplicationData\...
        /// </summary>
        UserData,

        /// <summary>
        /// Application specific path, i.e. ...\Documents and Settings\All Users\ApplicationData\...
        /// </summary>
        AppData,

        /// <summary>
        /// Executable dependent path (same folder as executable)
        /// </summary>
        Executable
    } // ConfigLocation

    /// <summary>
    /// This class stores the application configuration. At the beginning
    /// of the application all the properties are read from either the
    /// registry or an XML fileName. At the end of the application the data
    /// is stored again.
    /// </summary>
    public class TethysAppConfig
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the encoding for read/write operations.
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Gets or sets the location of the application configuration.
        /// </summary>
        public ConfigLocation Location { get; set; }

        /// <summary>
        /// Gets or sets the application assembly.
        /// </summary>
        public Assembly ApplicationAssembly { get; set; }

        /// <summary>
        /// Gets the assembly company.
        /// </summary>
        public string AssemblyCompany
        {
            get
            {
                var assembly = this.ApplicationAssembly ?? Assembly.GetEntryAssembly();
                if (assembly == null)
                {
                    return string.Empty;
                } // if
                var attributes = assembly.GetCustomAttributes(
                  typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                } // if
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="TethysAppConfig"/> class.
        /// </summary>
        /// <param name="applicationAssembly">The application assembly.</param>
        public TethysAppConfig(Assembly applicationAssembly)
        {
            ApplicationAssembly = applicationAssembly;
            Encoding = Encoding.UTF8;
            Location = ConfigLocation.UserData;
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

        /// <summary>
        /// Returns the complete path for the fileName to be stored.
        /// The following possibilities exist:<br />
        /// (a) The fileName is already a fully qualified path -&gt; no change<br />
        /// (b) Return executable dependent path (same folder as executable)<br />
        /// (c) Return user specific path, i.e. ...\Documents and Settings\user\ApplicationData\...<br />
        /// (d) Return application specific path, i.e. ...\Documents and Settings\All Users\ApplicationData\...
        /// </summary>
        /// <param name="fileName">(source) filename</param>
        /// <returns>The complete filename.</returns>
        protected virtual string GetCompleteFilename(string fileName)
        {
            var assembly = this.ApplicationAssembly ?? Assembly.GetEntryAssembly();
            var productAttribute =
              (AssemblyProductAttribute)Attribute.GetCustomAttribute(assembly,
              typeof(AssemblyProductAttribute));
            Debug.Assert(productAttribute != null, "productAttribute must not be empty!");

            string fullpath;
            string productName = productAttribute.Product;

            // is this already a fully qualified path
            var fileInfo = new FileInfo(fileName);
            if (fileInfo.FullName == fileName)
            {
                // we already have a complete path
                return fileName;
            } // if

            // generate complete filename
            if (this.Location == ConfigLocation.Executable)
            {
                string exePath = assembly.Location;
                var fi = new FileInfo(exePath);
                fullpath = fi.DirectoryName;
            }
            else if (this.Location == ConfigLocation.UserData)
            {
                fullpath = Environment.GetFolderPath(
                  Environment.SpecialFolder.ApplicationData);
                fullpath = Path.Combine(fullpath, AssemblyCompany);
                fullpath = Path.Combine(fullpath, productName);
            }
            else
            {
                fullpath = Environment.GetFolderPath(
                  Environment.SpecialFolder.CommonApplicationData);
                fullpath = Path.Combine(fullpath, AssemblyCompany);
                fullpath = Path.Combine(fullpath, productName);
            } // if

            if (string.IsNullOrEmpty(fullpath))
            {
                return null;
            } // if

            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            } // if
            fullpath = Path.Combine(fullpath, fileName);

            return fullpath;
        } // GetCompleteFilename()
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
            fileName = GetCompleteFilename(fileName);

            // Do NOT use UNICODE, because some of the target operating
            // system like Win 98, Win ME can't handle it
            // Do NOT use ASCII, since this does not support german umlaute.
            var xmlwriter = new TethysXmlTextWriter(fileName,
              this.Encoding);
            xmlwriter.XmlWriter.WriteStartDocument(false);
            xmlwriter.XmlWriter.Formatting = Formatting.Indented;
            xmlwriter.XmlWriter.Indentation = 2;

            WriteData(xmlwriter);

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
            fileName = GetCompleteFilename(fileName);

            var xmlreader = new TethysXmlTextReader(fileName);
            xmlreader.WhitespaceHandling = WhitespaceHandling.None;

            try
            {
                ReadData(xmlreader);
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
