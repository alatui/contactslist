using Android.App;
using Android.Widget;
using Android.OS;

using SQLite;
using Android.Content;

namespace ContactsList
{
	[Activity(Label = "ContactsList", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			this.setupDatabase();

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

		}

		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.main_top, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
		{

			switch (item.ItemId) {
				case Resource.Id.main_top_new:
					var intent = new Intent(this, typeof(NewContactActivity));
					StartActivity(intent);
					break;
				default:
					break;
			}

			return true;
		}


		private void setupDatabase() {
			Database.connect();
			Database.CreateTables();
		}


	}
}

