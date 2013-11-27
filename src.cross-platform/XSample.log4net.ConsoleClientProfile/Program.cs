using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSample.log4net
{
	class Program
	{
		static void Main(string[] args)
		{
			LogSamples.LogToFiles();
			LogSamples.Log01();
			LogSamples.Log02();
			LogSamples.Log03();
			LogSamples.Log04();

			LogSamples.AddingMultipleAppenders();
			LogSamples.AddingMultipleAppenders2();
			LogSamples.DefaultCategoryTest();


			Console.WriteLine
					(
					  "global::log4net.GlobalContext.Properties[\"LogFileName\"] = {0}"
					, global::log4net.GlobalContext.Properties["LogFileName"]
					);


			string app = "";
			app = System.IO.Path.Combine(LogSamples.root_folder, "log4net-file.log");
			System.Diagnostics.Process.Start(app);
			app = System.IO.Path.Combine(LogSamples.root_folder, "log4net-file-rolling.log");
			System.Diagnostics.Process.Start(app);
			Console.ReadLine();
		}
	}
}
