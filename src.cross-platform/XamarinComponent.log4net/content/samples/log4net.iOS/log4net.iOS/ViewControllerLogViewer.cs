// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace XSample.log4net.XamariniOS.IKI
{
	public partial class ViewControllerLogViewer : UIViewController
	{
		public ViewControllerLogViewer (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//TODO: Mokee UI elements
			//editTextLoggedMessage
			string content = LogSamples.LogsRead();
			editTextLoggedMessage.Text = content;

			return;
		}
	}
}