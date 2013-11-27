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
	[Register ("ViewControllerLogViewer")]
	partial class ViewControllerLogViewer
	{
		[Outlet]
		MonoTouch.UIKit.UITextView editTextLoggedMessage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (editTextLoggedMessage != null) {
				editTextLoggedMessage.Dispose ();
				editTextLoggedMessage = null;
			}
		}
	}
}
