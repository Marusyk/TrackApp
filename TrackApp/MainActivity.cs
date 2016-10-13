using Android.App;
using Android.OS;
using Android.Widget;
using TrackApp.Model;

namespace TrackApp
{
	[Activity(Label = "TrackApp", MainLauncher = true, Icon = "@drawable/mainIcon")]
	public class MainActivity : Activity
	{
		public const string FirstName = "Roman";
		public const string LastName = "Marusyk";

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);
			var employeeStatus = InOutClient.GetEmployeeStatus(FirstName, LastName);
			SetState(employeeStatus);

			var btnClose = FindViewById<Button>(Resource.Id.btnClose);
			btnClose.Click += delegate { System.Environment.Exit(0); };
		}

		private void SetState(EmployeeStatus employeeStatus)
		{
			var lblStatus = FindViewById<TextView>(Resource.Id.lblStatus);
			var lblStart = FindViewById<TextView>(Resource.Id.lblStart);
			var lblEnd = FindViewById<TextView>(Resource.Id.lblEnd);
			var imageView = FindViewById<ImageView>(Resource.Id.imageView);

			if (employeeStatus == null)
			{
				lblStatus.Text = "Статус: Не на роботі!";
				imageView.SetImageResource(Resource.Drawable.missing);
				return;
			}

			if (employeeStatus.End.Contains("0000"))
			{
				lblStart.Text = $"Прийшов в: {employeeStatus.Start}";
				lblStatus.Text = "Статус: Працює!";
				imageView.SetImageResource(Resource.Drawable.working);
				return;
			}

			lblStart.Text = $"Прийшов в: {employeeStatus.Start}";
			lblEnd.Text += $"Пішов в: {employeeStatus.End}";
			lblStatus.Text = "Статус: Пішов до дому!";
			imageView.SetImageResource(Resource.Drawable.@out);
		}
	}
}