using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace XSample.log4net
{
	[Activity()]
	public class ActivityLogViewer : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.LogViewer);

			EditText editTextLoggedMessage = FindViewById<EditText>(Resource.Id.editTextLoggedMessage);
			string content = LogSamples.LogsRead();
			editTextLoggedMessage.Text = 
				content
				//DateTime.Now 
				//+ System.Environment.NewLine + 
				//Intent.GetStringExtra("Message") ?? "No message??"
				//+ System.Environment.NewLine +
				//editTextLoggedMessage.Text
				;


			return;
		}



	}
}

