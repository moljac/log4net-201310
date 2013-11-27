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
		#region ConfigureAndWatchHandler

#if (!NETCF && !SSCLI)
		/// <summary>
		/// Class used to watch config files.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Uses the <see cref="FileSystemWatcher"/> to monitor
		/// changes to a specified file. Because multiple change notifications
		/// may be raised when the file is modified, a timer is used to
		/// compress the notifications into a single event. The timer
		/// waits for <see cref="TimeoutMillis"/> time before delivering
		/// the event notification. If any further <see cref="FileSystemWatcher"/>
		/// change notifications arrive while the timer is waiting it
		/// is reset and waits again for <see cref="TimeoutMillis"/> to
		/// elapse.
		/// </para>
		/// </remarks>
		private sealed partial class ConfigureAndWatchHandler : IDisposable
		{
			/// <summary>
			/// Holds the FileInfo used to configure the XmlConfigurator
			/// </summary>
			private FileInfo m_configFile;

			/// <summary>
			/// Holds the repository being configured.
			/// </summary>
			private ILoggerRepository m_repository;

			/// <summary>
			/// The timer used to compress the notification events.
			/// </summary>
			private Timer m_timer;

			/// <summary>
			/// The default amount of time to wait after receiving notification
			/// before reloading the config file.
			/// </summary>
			private const int TimeoutMillis = 500;

			/// <summary>
			/// Watches file for changes. This object should be disposed when no longer
			/// needed to free system handles on the watched resources.
			/// </summary>
			private FileSystemWatcher m_watcher;


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
			private void ConfigureAndWatchHandler_OnChanged(object source, FileSystemEventArgs e)
			{
				LogLog.Debug(declaringType, "ConfigureAndWatchHandler: " + e.ChangeType + " [" + m_configFile.FullName + "]");

				// Deliver the event in TimeoutMillis time
				// timer will fire only once
				m_timer.Change(TimeoutMillis, Timeout.Infinite);
			}


			/// <summary>
			/// Called by the timer when the configuration has been updated.
			/// </summary>
			/// <param name="state">null</param>
			private void OnWatchedFileChange(object state)
			{
				XmlConfigurator.InternalConfigure(m_repository, m_configFile);
			}

			/// <summary>
			/// Release the handles held by the watcher and timer.
			/// </summary>
#if NET_4_0
			[System.Security.SecuritySafeCritical]
#endif
			public void Dispose()
			{
				m_watcher.EnableRaisingEvents = false;
				m_watcher.Dispose();
				m_timer.Dispose();
			}
		}
#endif

		#endregion ConfigureAndWatchHandler
	}
}