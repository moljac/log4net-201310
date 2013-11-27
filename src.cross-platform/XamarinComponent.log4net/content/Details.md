# Details #

## Apache log4net™ Features ##

### Overview ###

log4net is a tool to help the programmer output log statements to a variety 
of  output targets. In case of problems with an application, it is helpful 
to enable  logging so that the problem can be located. With log4net it is 
possible  to enable logging at runtime without modifying the application 
binary. 
The log4net package is designed so that log statements can remain in 
shipped code without incurring a high performance cost. It follows that 
the speed of logging (or rather not logging) is crucial. 

At the same time, log output can be so voluminous that it quickly 
becomes overwhelming. One of the distinctive features of log4net is the 
notion of hierarchical loggers. Using these loggers it is possible to 
selectively control which log statements are output at arbitrary 
granularity. 

log4net is designed with two distinct goals in mind: speed and 
flexibility 


### Features ###

* 	Support for multiple frameworks
* 	Output to multiple logging targets
* 	Hierarchical logging architecture
* 	XML Configuration
* 	Dynamic Configuration
* 	Logging Context
* 	Proven architecture
* 	Modular and extensible design
* 	High performance with flexibility
* 	Support for multiple frameworks

log4net runs on all ECMA CLI 1.0 compatible runtimes. log4net has specific 
builds for the following frameworks:

* Microsoft® .NET Framework 1.0
* Microsoft .NET Framework 1.1
* Microsoft .NET Framework 2.0
* Microsoft .NET Framework 3.5
* Microsoft .NET Framework 4.0
* Microsoft .NET Framework 3.5 Client Profile
* Microsoft .NET Framework 4.0 Client Profile
* Microsoft .NET Compact Framework 1.0*
* Microsoft .NET Compact Framework 2.0*
* Mono 1.0
* Mono 2.0
* Microsoft Shared Source CLI 1.0*
* CLI 1.0 Compatible
* NEW 2013-09-20 Implementations HolisticWare: Mono Mobile Xamarin.iOS and Xamarin.Android
* NEW 2013-09-20 Tested by HolisticWare: Mono 3.0

The "Client Profile" builds are stripped down versions of the "normal" builds that 
don't contain any ASP.NET releated code - which for example means the %aspnet-* 
patterns and the AspNetTraceAppender are not available.

*Not supported by the binary release but can be built from the source release.

Plans HolisticWare -  add async support


### Output to multiple logging targets ###

log4net ships with the following appenders (not on all frameworks):

Types	and  Descriptions:

1. log4net.Appender.AdoNetAppender	 	
	Writes logging events to a database using either prepared statements or 	
	stored procedures.  	
1. log4net.Appender.AnsiColorTerminalAppender	 	
	Writes color highlighted logging events to a an ANSI terminal window.	
1. log4net.Appender.AspNetTraceAppender	 	
	Writes logging events to the ASP trace context. These can then be rendered at 		
	the end of the ASP page or on the ASP trace page.	
	Note: Not available in Mono Mobile profile (Xamarin.iOS and Xamarin.Android)	
1. log4net.Appender.ColoredConsoleAppender	 
	Writes color highlighted logging events to the application's Windows Console.
1. log4net.Appender.ConsoleAppender	 	
	Writes logging events to the application's Console. The events may go to 	
	either the standard our stream or the standard error stream.	
1. log4net.Appender.DebugAppender	 	
	Writes logging events to the .NET system.	
1. log4net.Appender.EventLogAppender	 
	Writes logging events to the Windows Event Log.	
1. log4net.Appender.FileAppender	 
	Writes logging events to a file in the file system.	
1. log4net.Appender.LocalSyslogAppender	 	
	Writes logging events to the local syslog service (UNIX only).	
1. log4net.Appender.MemoryAppender	 	
	Stores logging events in an in memory buffer.	
1. log4net.Appender.NetSendAppender	 	
	Writes logging events to the Windows Messenger service. These messages 		
	are displayed in a dialog on a users terminal.		
1. log4net.Appender.OutputDebugStringAppender	 	
	Writes logging events to the debugger. If the application has no debugger, 	
	the system debugger displays the string. If the application has no debugger 	
	and the system debugger is not active, the message is ignored.	
1. log4net.Appender.RemoteSyslogAppender	 	
	Writes logging events to a remote syslog service using UDP networking.		
1. log4net.Appender.RemotingAppender	 	
	Writes logging events to a remoting  sink using .NET remoting.		
1. log4net.Appender.RollingFileAppender	 	
	Writes logging events to a file in the file system. The RollingFileAppender 	
	can be configured to log to multiple files based upon date or file size constraints.	
1. log4net.Appender.SmtpAppender	 	
	Sends logging events to an email address.		
	Note: Not available in Mono Mobile profile (Xamarin.iOS and Xamarin.Android)	
	TODO: add it!	
1. log4net.Appender.SmtpPickupDirAppender	 	
	Sends logging events to an email address but writes the emails to a 	
	configurable directory rather than sending them directly via SMTP.	
1. log4net.Appender.TelnetAppender	 	
	Clients connect via Telnet to receive logging events.		
1. log4net.Appender.TraceAppender	 	
	Writes logging events to the .NET trace system.			
	Note: Not available in (Xamarin.iOS)		
1. log4net.Appender.UdpAppender	 	
	Sends logging events as connectionless UDP datagrams to a remote host or a 		
	multicast group using a UdpClient.		
1. A special log4net.Appender.ForwardingAppender 		
	can be used to wrap another appender, for example to attach additional filters.		

### Hierarchical logging architecture ###

Hierarchical logging is an ideal fit with component based development. 
Each component has its own of logger. When individually tested, the 
properties of these loggers may be set as the developer requires. When 
combined with other components, the loggers inherit the properties 
determined by the integrator of the components. One can selectively 
elevate logging priorities on one component without affecting the other 
components. This is useful when you need a detailed trace from just a 
single component without crowding the trace file with messages from 
other components. All this can be done through configuration files; no 
code changes are required. 


### XML Configuration ###

Note: Not available in Mono Mobile profile (Xamarin.iOS and Xamarin.Android)

log4net is configured using an XML configuration file. The configuration 
information can be embedded within other XML configuration files (such 
as the application's .config file) or in a separate file. The 
configuration is easily readable and updateable while retaining the 
flexibility to express all configurations. 


### Alternatively log4net can be configured programmatically. ###

```csharp
			root_folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			file = System.IO.Path.Combine(LogSamples.root_folder, "log4net-file.log");
			file_copy = file + ".txt";

			global::log4net.Layout.SimpleLayout layout = new global::log4net.Layout.SimpleLayout();
			layout.ActivateOptions();

			FileAppender = new global::log4net.Appender.FileAppender();
			FileAppender.File = System.IO.Path.Combine(root_folder, "log4net-file.log");
			FileAppender.Layout = layout;
			FileAppender.ActivateOptions();
			global::log4net.Config.BasicConfigurator.Configure(FileAppender);

			RollingFileAppender = new global::log4net.Appender.RollingFileAppender();
			RollingFileAppender.File = System.IO.Path.Combine(root_folder, "log4net-file-rolling.log");
			RollingFileAppender.Layout = layout;
			RollingFileAppender.ActivateOptions();
			global::log4net.Config.BasicConfigurator.Configure(RollingFileAppender);

			global::log4net.Appender.AppenderCollection appenders =
					new global::log4net.Appender.AppenderCollection();
			appenders.Add(FileAppender);
			appenders.Add(RollingFileAppender);

			hierarchy_file =
				(global::log4net.Repository.Hierarchy.Hierarchy)
					global::log4net.LogManager.GetRepository();
			hierarchy_file.Root.AddAppender(FileAppender);
			hierarchy_file.Root.AddAppender(RollingFileAppender);

			//configure the logging at the root.  
			hierarchy_file.Root.Level = global::log4net.Core.Level.All;


			//mark repository as configured and  
			//notify that is has changed.  
			hierarchy_file.Root.Repository.Configured = true;
			hierarchy_file.Configured = true;
			hierarchy_file.RaiseConfigurationChanged(EventArgs.Empty);

			LogForFiles = global::log4net.LogManager.GetLogger("LogForFiles");
			//LogForFiles.Logger.Repository.ResetConfiguration();

```


### Dynamic Configuration ###

log4net can monitor its configuration file for changes and dynamically apply 
changes made by the configurator. The logging levels, appenders, 
layouts, and just about everything else can be adjusted at runtime. In 
many cases it is possible to diagnose application issues without 
terminating the process in question. This can a very valuable tool in 
investigating issues with deployed applications. 

### Logging Context ###

log4net can be used to collect logging context data in a way that is 
transparent to the developer at the point of logging. The GlobalContext 
and the ThreadContext allow the application to store contextual data 
that is attached to logging messages. For instance, in a web service, 
once the caller is authenticated the username of the caller could be 
stored in a ThreadContext property. This property would then be 
automatically logged as part of each subsequent logging message made 
from the same thread. 

### Proven architecture ###

log4net is based on the highly successful Apache log4j™ logging library, 
in development since 1996. This popular and proven architecture has so 
far been ported to 12 languages. 



## References ##
*	[http://logging.apache.org/log4net/](http://logging.apache.org/log4net/)
* 	[https://github.com/apache/log4net](https://github.com/apache/log4net)
*	[https://github.com/moljac/log4net](https://github.com/moljac/log4net)
* 	[http://holisticware.net](http://holisticware.net)

## Cross-platform port by HolisticWare team: ##

* 	[http://holisticware.net](http://holisticware.net)



