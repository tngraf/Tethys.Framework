# Tethys.Framework

Basic Services and Resources Development Library for .Net

## Project Build Status

[![Build status](https://ci.appveyor.com/api/projects/status/lxh0s8qexq6bi2tg?svg=true)](https://ci.appveyor.com/project/tngraf/tethys-framework)
[![License](https://img.shields.io/badge/license-Apache--2.0-blue.svg)](http://www.apache.org/licenses/LICENSE-2.0)
[![NuGet](https://img.shields.io/badge/nuget%20package-v4.6.0-blue.svg)](https://www.nuget.org/packages/Tethys.Framework/)

## Libraries

* **Tethys.Framework** - netstandard2.0 library with common code for WPF, Silverlight, Windows Phone and Windows 8 projects.
* **Tethys.Forms** - library with common code for Windows Forms applications (.NET Framework 4.7.2).
* **Tethys.Forms.NET5** - library with common code for Windows Forms applications (.NET Core 3 / .NET 5).
* **Tethys.Win** - library with common for .Net Windows applications (.NET Framework 4.7.2).
* **Tethys.Win.NET5** - library with common for .Net Windows applications (.NET Core 3 / .NET 5).

## Get Packages

Nuget packages are available, see the following links

* **Tethys.Framework** - package [Tethys.Framework](https://www.nuget.org/packages/Tethys.Framework/)
* **Tethys.Forms** - package [Tethys.Forms](https://www.nuget.org/packages/Tethys.Forms/)
* **Tethys.Forms.NET5** - package [Tethys.Forms](https://www.nuget.org/packages/Tethys.Forms/)
* **Tethys.Win** - package [Tethys.Win](https://www.nuget.org/packages/Tethys.Win/)
* **Tethys.Win.NET5** - package [Tethys.Win](https://www.nuget.org/packages/Tethys.Win/)

## Main Features

### Tethys

* `AssemblyXxxAttribute` - attributes to add release date and release type information to AssemblyInfo.cs.
* `Ringbuffer` - a circular buffer.
* `TextParse` - an elaborate text parsing class.
* `SimpleDiff` - a simple (but for most cases sufficient) file/text line comparer.
* `ByteArrayConversion` - byte array conversion methods.

### Tethys.Forms

Tethys.Forms contains a lot of WinForms custom controls:

* `ApplicationErrorReporter[Form]` - a window to display (unhandled) application exceptions in a proper way.
* `CenteredMessageBox` - a WinForms message box that is centered over the parent and not center on the screen.
* `ComboBoxItem` - a helper class for handling combo boxes.
* `FilterTextBox` - a textbox where you can limit what is displayed.
* `RecentFileList` - a 'most recent file' addon for WinForms menus.
* `SplashScreen` - a simple splash screen control.
* `LedControl` - a control that looks like an LED.
* `TableLayoutPanelSizable` - an enhanced TableLayoutPanel. The cells sizes of this table can be resized dynamically during runtime.
* `TimeoutMessageBox` - a message box that automatically disappears after a given time.
* `VerticalProgressBar` - a vertical progress bar.
* `VerticalText` - a simple control to display text vertically.

### Tethys.Win

* `TethysAppConfig` - a helper class to read/write application configuration in an XML file.
* Checksum implementations: `CRC16`, `CRC32`, `XCRC`.
* Encoding helper classes: `CodePageEncoding`, `GermanEncoding`, `SerialPortEncoding`.
* `Win32Api` - support for many many Win32 methods.

## Build

### Requisites

* Visual Studio 2019

### Symbols for conditional compilation

* WINDOWS       ==> Windows platform
* NETFX_CORE    ==> Windows 8 / WinRT / Metro applications
* WINDOWS_PHONE ==> Windows Phone platform
* SILVERLIGHT   ==> Silverlight platform
* NET45         ==> .Net version 4.5 and later

## Thanks

Not all code is from me. Code parts are from:

* Nish Sivakumar (SimpleDiff), licensed by the Code Project Open
  License (CPOL), see [http://www.codeproject.com/Articles/39184/An-LCS-based-diff-ing-library-in-C](http://www.codeproject.com/Articles/39184/An-LCS-based-diff-ing-library-in-C) for details.

## Copyright & License

Copyright 1998-2024 T. Graf

Licensed under the **Apache License, Version 2.0** (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and limitations under the License.

## SBOM

For an up-to-date CycloneDX SBOM, please have a look at the [SBOM](https://github.com/tngraf/Tethys.Framework/tree/master/SBOM) folder.
