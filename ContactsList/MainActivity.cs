using Android.App;
using Android.Widget;
using Android.OS;

using SQLite;
using Android.Content;

namespace ContactsList
{
	[Activity(Label = "Contacts List", Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		ListView contactsListView;
		ContactsAdapter contactsAdapter;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			contactsListView = FindViewById<ListView>(Resource.Id.contactsListView);

			contactsAdapter = new ContactsAdapter(this);
			contactsListView.Adapter = contactsAdapter;
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
					StartActivityForResult(intent,0);
					break;
				default:
					break;
			}

			return true;
		}


		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (resultCode == Result.Ok) {
				contactsAdapter.NotifyDataSetChanged();
			}
		}


	}
}

