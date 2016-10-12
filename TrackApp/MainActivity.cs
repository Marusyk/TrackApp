using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace TrackApp
{
	[Activity(Label = "TrackApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		public const string FirstName = "Roman";
		public const string LastName = "Marusyk";

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			var employeeStatus = InOutClient.GetEmployeeStatus(FirstName, LastName);
			if (employeeStatus != null)
			{

				var lblStart = FindViewById<TextView>(Resource.Id.lblStart);
				lblStart.Text += $" {employeeStatus.Start}";

				var lblEnd = FindViewById<TextView>(Resource.Id.lblEnd);
				lblEnd.Text += $" {employeeStatus.End}";
			}
			var btnClose = FindViewById<Button>(Resource.Id.btnClose);
			btnClose.Click += delegate { System.Environment.Exit(0); };
		}
	}
}