// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace XSample.log4net.XamariniOS.IKI
{
	[Register ("ViewController1")]
	partial class ViewController1
	{
		[Outlet]
		MonoTouch.UIKit.UIButton buttonLogMessage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView editTextLogMessage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (editTextLogMessage != null) {
				editTextLogMessage.Dispose ();
				editTextLogMessage = null;
			}

			if (buttonLogMessage != null) {
				buttonLogMessage.Dispose ();
				buttonLogMessage = null;
			}
		}
	}
}
