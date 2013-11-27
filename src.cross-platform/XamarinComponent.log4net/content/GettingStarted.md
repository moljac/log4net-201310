# Getting Started #

# log4net #

## What is Apache log4net ##

The Apache log4net library is a tool to help the programmer output log statements to a 
variety of output targets. log4net is a port of the excellent Apache log4j™ framework to 
the Microsoft® .NET runtime. We have kept the framework similar in spirit to the original 
log4j while taking advantage of new features in the .NET runtime. For more information on 
log4net see the features document.

## The Apache log4net project ##

log4net is part of the Apache Logging Services project at the Apache Software Foundation. 
The Logging Services project is intended to provide cross-language logging services for 
purposes of application debugging and auditing.

## Xamarin Component log4net

Cross-platform port of log4net library by HolisticWare for Mono Mobile profile:

* 	Xamarin.iOS
* 	Xamarin.Android

Note: Some features had to be removed:

*	Xml Configuration - 
*	some Appenders which cannot be implemented on the Mobile platforms   
	(AspNetTraceAppender, SmtpAppender.cs)


## Notes ##

## Samples ##


Programmatically initialize log4net

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

Usage
```csharp

			LogForFiles.Debug("Debug message LogToFiles()" + System.Environment.NewLine + @"  " + Message);
			LogForFiles.Info("Info message LogToFiles()" + System.Environment.NewLine + @"  " + Message);
			LogForFiles.Warn("Warning message LogToFiles()" + System.Environment.NewLine + @"  " + Message);
			LogForFiles.Error("Error message LogToFiles()" + System.Environment.NewLine + @"  " + Message);
			LogForFiles.Fatal("Fatal message LogToFiles()" + System.Environment.NewLine + @"  " + Message);

```



## Other Resources

*	[http://logging.apache.org/log4net/](http://logging.apache.org/log4net/)
* 	[https://github.com/apache/log4net](https://github.com/apache/log4net)
*	[https://github.com/moljac/log4net](https://github.com/moljac/log4net)
* 	[http://holisticware.net](http://holisticware.net)
