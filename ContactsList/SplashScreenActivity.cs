
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ContactsList
{
	[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashScreenActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
		}

		protected override void OnResume()
		{
			base.OnResume();

			var context = TaskScheduler.FromCurrentSynchronizationContext();

			Task startupWork = new Task(() => {
				Database.connect();
				Database.CreateTables();
			});


			startupWork.ContinueWith(t =>
			{
				Task.Delay(3000);

			}, context);


			startupWork.ContinueWith(t => {
				
				StartActivity(new Intent(Application.Context, typeof(MainActivity)));

			}, context);

			startupWork.Start();

		}
	}
}
