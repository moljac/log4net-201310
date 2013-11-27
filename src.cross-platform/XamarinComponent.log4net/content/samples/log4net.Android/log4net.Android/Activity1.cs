using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XSample.log4net
{
	[Activity(Label = "XSample.log4net.XamarinAndroid", MainLauncher = true, Icon = "@drawable/icon")]
	public class Activity1 : Activity
	{

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			LogSamples.InitFileLogs();


			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			EditText editTextLogMessage = FindViewById<EditText>(Resource.Id.editTextLogMEssage);
			Button buttonLogMessage = FindViewById<Button>(Resource.Id.buttonLogMessage);

			buttonLogMessage.Click += delegate
			{
				LogSamples.Message = editTextLogMessage.Text;

				LogSamples.LogTestAll();
				LogSamples.LogToFiles();

				Intent logViewer = new Intent(this, typeof(ActivityLogViewer));
				StartActivity(logViewer);

				return;
			};

			//Button buttonLogsDelete = FindViewById<Button>(Resource.Id.buttonLogsDelete);
			//buttonLogMessage.Click += delegate
			//{
			//	LogSamples.LogsDelete();
			//};

			return;
		}
	}
}

