#region Apache License
//
// Licensed to the Apache Software Foundation (ASF) under one or more 
// contributor license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright ownership. 
// The ASF licenses this file to you under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with 
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using System.Xml;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Net;

using log4net.Appender;
using log4net.Util;
using log4net.Repository;

namespace log4net.Config
{
	public sealed partial class XmlConfigurator
	{
		private sealed partial class ConfigureAndWatchHandler : IDisposable
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="ConfigureAndWatchHandler" /> class to
			/// watch a specified config file used to configure a repository.
			/// </summary>
			/// <param name="repository">The repository to configure.</param>
			/// <param name="configFile">The configuration file to watch.</param>
			/// <remarks>
			/// <para>
			/// Initializes a new instance of the <see cref="ConfigureAndWatchHandler" /> class.
			/// </para>
			/// </remarks>
#if NET_4_0
			[System.Security.SecuritySafeCritical]
#endif
			public ConfigureAndWatchHandler(ILoggerRepository repository, FileInfo configFile)
			{
				m_repository = repository;
				m_configFile = configFile;

				// Create a new FileSystemWatcher and set its properties.
				m_watcher = new FileSystemWatcher();

				m_watcher.Path = m_configFile.DirectoryName;
				m_watcher.Filter = m_configFile.Name;

				// Set the notification filters
				m_watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite | NotifyFilters.FileName;

				// Add event handlers. OnChanged will do for all event handlers that fire a FileSystemEventArgs
				m_watcher.Changed += new FileSystemEventHandler(ConfigureAndWatchHandler_OnChanged);
				m_watcher.Created += new FileSystemEventHandler(ConfigureAndWatchHandler_OnChanged);
				m_watcher.Deleted += new FileSystemEventHandler(ConfigureAndWatchHandler_OnChanged);
				m_watcher.Renamed += new RenamedEventHandler(ConfigureAndWatchHandler_OnRenamed);

				// Begin watching.
				m_watcher.EnableRaisingEvents = true;

				// Create the timer that will be used to deliver events. Set as disabled
				m_timer = new Timer(new TimerCallback(OnWatchedFileChange), null, Timeout.Infinite, Timeout.Infinite);
			}

			/// <summary>
			/// Event handler used by <see cref="ConfigureAndWatchHandler"/>.
			/// </summary>
			/// <param name="source">The <see cref="FileSystemWatcher"/> firing the event.</param>
			/// <param name="e">The argument indicates the file that caused the event to be fired.</param>
			/// <remarks>
			/// <para>
			/// This handler reloads the configuration from the file when the event is fired.
			/// </para>
			/// </remarks>
			private void ConfigureAndWatchHandler_OnRenamed(object source, RenamedEventArgs e)
			{
				LogLog.Debug(declaringType, "ConfigureAndWatchHandler: " + e.ChangeType + " [" + m_configFile.FullName + "]");

				// Deliver the event in TimeoutMillis time
				// timer will fire only once
				m_timer.Change(TimeoutMillis, Timeout.Infinite);
			}
		}
	}
}