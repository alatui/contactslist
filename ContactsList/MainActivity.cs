using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

namespace ContactsList
{
	[Activity(Label = "ContactsList", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			this.CreateDatabase();

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

		}


		private void CreateDatabase() {
			string dbPath = Path.Combine(
				System.Environment.GetFolderPath( System.Environment.SpecialFolder.Personal ),
				"contacts_list.db3"
			);
			System.Diagnostics.Debug.WriteLine(dbPath);

			var db = new SQLiteConnection(dbPath);
			db.CreateTable<Contact>();//create Contact table


		}


	}
}

