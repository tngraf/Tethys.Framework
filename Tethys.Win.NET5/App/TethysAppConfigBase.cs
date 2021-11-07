// ---------------------------------------------------------------------------
// <copyright file="TethysAppConfigBase.cs" company="Tethys">
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
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Text;

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
        Executable,
    } // ConfigLocation

    /// <summary>
    /// This class stores the application configuration. At the beginning
    /// of the application all the properties are read from either the
    /// registry or an XML fileName. At the end of the application the data
    /// is stored again.
    /// </summary>
    public class TethysAppConfigBase
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
        /// Initializes a new instance of the <see cref="TethysAppConfigBase"/> class.
        /// </summary>
        /// <param name="applicationAssembly">The application assembly.</param>
        public TethysAppConfigBase(Assembly applicationAssembly)
        {
            this.ApplicationAssembly = applicationAssembly;
            this.Encoding = Encoding.UTF8;
            this.Location = ConfigLocation.UserData;
        } // TethysAppConfigBase()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region PROTECTED METHODS
        /// <summary>
        /// Returns the complete path for the fileName to be stored.
        /// The following possibilities exist:<br />
        /// (a) The fileName is already a fully qualified path -&gt; no change<br />
        /// (b) Return executable dependent path (same folder as executable)<br />
        /// (c) Return user specific path, i.e. ...\Documents and Settings\user\ApplicationData\...<br />
        /// (d) Return application specific path, i.e. ...\Documents and Settings\All Users\ApplicationData\...
        /// </summary>
        /// <param name="fileName">(source) filename.</param>
        /// <returns>The complete filename.</returns>
        protected virtual string GetCompleteFilename(string fileName)
        {
            var assembly = this.ApplicationAssembly ?? Assembly.GetEntryAssembly();
            var productAttribute = (AssemblyProductAttribute)Attribute.GetCustomAttribute(
                assembly,
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
                fullpath = Path.Combine(fullpath, this.AssemblyCompany);
                fullpath = Path.Combine(fullpath, productName);
            }
            else
            {
                fullpath = Environment.GetFolderPath(
                  Environment.SpecialFolder.CommonApplicationData);
                fullpath = Path.Combine(fullpath, this.AssemblyCompany);
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
    } // TethysAppConfigBase
} // Tethys.App
