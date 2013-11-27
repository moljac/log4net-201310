using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSample.log4net 
{
	/// <summary>
	/// log4net Samples - programmatically configured
	/// Deleting logs
	///		Android:
	///			Delete log manually with 
	///				ddms Dalvik Debug Monitor
	///				Device +/ File Explorer
	///		iOS:
	/// </summary>
	public partial class LogSamples
	{
		public static global::log4net.Repository.Hierarchy.Hierarchy hierarchy_string_appender = null;
		public static global::log4net.ILog LogForStringAppender = null;
		public static global::log4net.Tests.Appender.StringAppender StringAppender = null;

		public static global::log4net.Repository.Hierarchy.Hierarchy hierarchy_file = null;
		public static global::log4net.ILog LogForFiles = null;

		public static global::log4net.Appender.FileAppender FileAppender = null;
		public static global::log4net.Appender.RollingFileAppender RollingFileAppender = null;

		public static string root_folder = "";
		static string file = "";
		static string file_copy = "";

		static LogSamples()
		{

			StringAppender = new global::log4net.Tests.Appender.StringAppender();
			hierarchy_string_appender =
				(global::log4net.Repository.Hierarchy.Hierarchy)
					global::log4net.LogManager.GetRepository();
			hierarchy_string_appender.Root.AddAppender(StringAppender);
			LogForStringAppender = global::log4net.LogManager.GetLogger("LogForStringAppender");

			InitFileLogs();

			return;
		}

		public static void InitFileLogs()
		{
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


			int a = hierarchy_file.Root.Appenders.Count;
		}

		public static string Message = "HolisticWare";

		public static void LogTestAll()
		{

			// LogSamples.LogToFiles();
			
			// Try those - removed (too much output)
			LogSamples.Log01();
			LogSamples.Log02();
			LogSamples.Log03();
			LogSamples.Log04();
			
			LogSamples.AddingMultipleAppenders();
			LogSamples.AddingMultipleAppenders2();
			LogSamples.DefaultCategoryTest();
		
			return;
		}


		public static void LogToFiles()
		{
			LogForFiles.Debug("Debug message LogToFiles()" + System.Environment.NewLine + @"  " + Message);
			LogForFiles.Info("Info message LogToFiles()" + System.Environment.NewLine + @"  " + Message);
			LogForFiles.Warn("Warning message LogToFiles()" + System.Environment.NewLine + @"  " + Message);
			LogForFiles.Error("Error message LogToFiles()" + System.Environment.NewLine + @"  " + Message);
			LogForFiles.Fatal("Fatal message LogToFiles()" + System.Environment.NewLine + @"  " + Message);

			return;
		}


		public static void LogsDelete()
		{
			// Delete log manually with ddms Dalvik Debug Monitor
			// Device +/ File Explorer

			return;
		}

		public static string LogsRead()
		{
			string content = "log empty...";
			try
			{
				// Sharing violations
				// FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);

				// Workaround: copy
				// TODO: check log4net file access and sharing options
				LogsCopy();

				using (System.IO.TextReader reader = System.IO.File.OpenText(file_copy))
				{
					content = reader.ReadToEnd();
				}
			}
			catch (Exception e)
			{
				content = e.Message;
			}
			return content;
		}

		private static void LogsCopy()
		{
			bool file_exists = System.IO.File.Exists(file);
			bool file_copy_exists = System.IO.File.Exists(file_copy);

			try
			{
				System.IO.File.Copy(file, file_copy, true);
			}
			catch (Exception e)
			{
				LogForFiles.Fatal(e.Message);
			}

			return;
		}

		public static void Log01()
		{
			global::log4net.Config.BasicConfigurator.Configure();
			global::log4net.ILog log = null;
			log =  global::log4net.LogManager
					.GetLogger(typeof(Console));

			log.Debug("Debug message HolisticWare Log01()");
			log.Info("Info message HolisticWare Log01()");
			log.Warn("Warning message HolisticWare Log01()");
			log.Error("Error message HolisticWare Log01()");
			log.Fatal("Fatal message HolisticWare Log01()");

			return;
		}

		public static void Log02()
		{
			global::log4net.Config.BasicConfigurator.Configure();
			global::log4net.ILog log = null;
			log = global::log4net.LogManager
					.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

			log.Debug("Debug message HolisticWare Log02()");
			log.Info("Info message HolisticWare Log02()");
			log.Warn("Warning message HolisticWare Log02()");
			log.Error("Error message HolisticWare Log02()");
			log.Fatal("Fatal message HolisticWare Log02()");

			return;
		}

		public static void Log03()
		{
			global::log4net.Config.BasicConfigurator.Configure();
			global::log4net.ILog log = null;
			log = global::log4net.LogManager
					.GetLogger("AndroidLogger");

			log.Debug("Debug message HolisticWare Log03()");
			log.Info("Info message HolisticWare Log03()");
			log.Warn("Warning message HolisticWare Log03()");
			log.Error("Error message HolisticWare Log03()");
			log.Fatal("Fatal message HolisticWare Log03()");

			return;
		}

		public static void Log04()
		{
			global::log4net.Appender.ConsoleAppender	appender_console = null;
			global::log4net.Appender.DebugAppender		appender_debug = null;
			global::log4net.Appender.TraceAppender		appender_trace = null;
			//global::log4net.Appender.AndroidLogAppender appender_android = null;

			appender_console	= new global::log4net.Appender.ConsoleAppender();
			appender_debug		= new global::log4net.Appender.DebugAppender();
			//appender_trace		= new global::log4net.Appender.TraceAppender();
			//appender_android	= new global::log4net.Appender.AndroidLogAppender();

			global::log4net.Appender.AppenderSkeleton[] appenders = null;
			appenders = new global::log4net.Appender.AppenderSkeleton[] 
														{
														  appender_console
														, appender_debug
														//, appender_trace
														//, appender_android
														};

			global::log4net.Repository.Hierarchy.Hierarchy hierarchy = null;
			hierarchy =		
				(global::log4net.Repository.Hierarchy.Hierarchy)
					global::log4net.LogManager.GetRepository();

			hierarchy.Root.AddAppender(appender_console);
			hierarchy.Root.AddAppender(appender_debug);
			//hierarchy.Root.AddAppender(appender_trace);
			//hierarchy.Root.AddAppender(appender_android);

			hierarchy.Configured = true;

			appender_console.ActivateOptions();
			appender_debug.ActivateOptions();
			//appender_trace.ActivateOptions();
			//appender_android.ActivateOptions();

			//global::log4net.Config.BasicConfigurator.Configure(appenders);

			global::log4net.ILog log = null;
			log = global::log4net.LogManager.GetLogger("HolisticWare Logger");

			log.Debug("Debug message HolisticWare Log04()");
			log.Info("Info message HolisticWare Log04()");
			log.Warn("Warning message HolisticWare Log04()");
			log.Error("Error message HolisticWare Log04()");
			log.Fatal("Fatal message HolisticWare Log04()");

			return;
		}

		public static void LogInStringAppender()
		{
			LogForStringAppender.Debug("Debug message HolisticWare LogInStringAppender()");
			LogForStringAppender.Info("Info message HolisticWare LogInStringAppender()");
			LogForStringAppender.Warn("Warning message HolisticWare LogInStringAppender()");
			LogForStringAppender.Error("Error message HolisticWare LogInStringAppender()");
			LogForStringAppender.Fatal("Fatal message HolisticWare LogInStringAppender()");

			return;
		}

		public static void AddingMultipleAppenders()
		{
			global::log4net.Tests.Appender.CountingAppender counting =
							new global::log4net.Tests.Appender.CountingAppender();
			global::log4net.Appender.ConsoleAppender console =
							new global::log4net.Appender.ConsoleAppender();


			global::log4net.Repository.Hierarchy.Hierarchy hierarchy =
				(global::log4net.Repository.Hierarchy.Hierarchy)
					global::log4net.LogManager.GetRepository();
			hierarchy.Root.AddAppender(counting);
			hierarchy.Root.AddAppender(console);
			hierarchy.Configured = true;

			global::log4net.ILog log = global::log4net.LogManager.GetLogger(new LogSamples().GetType());

			log.Debug("Debug message HolisticWare AddingMultipleAppenders()");
			log.Info("Info message HolisticWare AddingMultipleAppenders()");
			log.Warn("Warning message HolisticWare AddingMultipleAppenders()");
			log.Error("Error message HolisticWare AddingMultipleAppenders()");
			log.Fatal("Fatal message HolisticWare AddingMultipleAppenders()");

			return;
		}

		public static void AddingMultipleAppenders2()
		{
			global::log4net.Tests.Appender.CountingAppender counting =
						new global::log4net.Tests.Appender.CountingAppender();
			global::log4net.Appender.ConsoleAppender console =
							new global::log4net.Appender.ConsoleAppender();

			global::log4net.Config.BasicConfigurator.Configure(counting, console);

			global::log4net.ILog log = global::log4net.LogManager.GetLogger(new LogSamples().GetType());

			log.Debug("Debug message HolisticWare AddingMultipleAppenders2()");
			log.Info("Info message HolisticWare AddingMultipleAppenders2()");
			log.Warn("Warning message HolisticWare AddingMultipleAppenders2()");
			log.Error("Error message HolisticWare AddingMultipleAppenders2()");
			log.Fatal("Fatal message HolisticWare AddingMultipleAppenders2()");

			return;
		}

		public static void DefaultCategoryTest()
		{
			global::log4net.Tests.Appender.CategoryTraceListener categoryTraceListener =
						new global::log4net.Tests.Appender.CategoryTraceListener();

			// Trace not in Xamarin.iOS????????????????????????
			// http://forums.xamarin.com/discussion/comment/20763
			// TODO: raise issue on forum!!!
			//
			// System.Diagnostics.Trace.Listeners.Clear();
			// System.Diagnostics.Trace.Listeners.Add(categoryTraceListener);

			global::log4net.Repository.ILoggerRepository rep =
						global::log4net.LogManager.CreateRepository(Guid.NewGuid().ToString());

			global::log4net.Appender.TraceAppender traceAppender =
						new global::log4net.Appender.TraceAppender();

			traceAppender.Layout = new global::log4net.Layout.SimpleLayout();
			traceAppender.ActivateOptions();

			global::log4net.Config.BasicConfigurator.Configure(rep, traceAppender);

			global::log4net.ILog log = global::log4net.LogManager.GetLogger(rep.Name, new LogSamples().GetType());

			log.Debug("Debug message HolisticWare DefaultCategoryTest()");
			log.Info("Info message HolisticWare DefaultCategoryTest()");
			log.Warn("Warning message HolisticWare DefaultCategoryTest()");
			log.Error("Error message HolisticWare DefaultCategoryTest()");
			log.Fatal("Fatal message HolisticWare DefaultCategoryTest()");

			return;
		}

	}
}
