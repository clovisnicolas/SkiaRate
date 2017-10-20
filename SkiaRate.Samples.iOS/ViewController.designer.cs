// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SkiaRate.Samples.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIStackView stackView { get; set; }

		[Outlet]
		UIKit.UIView view1 { get; set; }

		[Outlet]
		UIKit.UIView view2 { get; set; }

		[Outlet]
		UIKit.UIView view3 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (stackView != null) {
				stackView.Dispose ();
				stackView = null;
			}

			if (view1 != null) {
				view1.Dispose ();
				view1 = null;
			}

			if (view2 != null) {
				view2.Dispose ();
				view2 = null;
			}

			if (view3 != null) {
				view3.Dispose ();
				view3 = null;
			}
		}
	}
}
