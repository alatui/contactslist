
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace ContactsList
{
	[Activity(Label = "NewContactActivity")]
	public class NewContactActivity : Activity
	{

		EditText nameEditText;
		EditText emailEditText;
		Button saveContactButton;
		Contact contact;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//ActionBar.Hide();
			ActionBar.SetDisplayHomeAsUpEnabled(true);

			SetContentView(Resource.Layout.NewContact);

			nameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
			emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
			saveContactButton = FindViewById<Button>(Resource.Id.saveContactButton);

			saveContactButton.Click+= SaveContactButton_Click;




			// Create your application here
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId) {
				case Android.Resource.Id.Home:
					Finish();
					break;
				default:
					break;
			}
			return true;
		}

		void SaveContactButton_Click(object sender, EventArgs e)
		{

			if (nameEditText.Text == "" || emailEditText.Text == "")
			{
				Toast.MakeText(this, "Name and Email are required", ToastLength.Short).Show();
			}
			else {
				contact = new Contact { 
					Name = nameEditText.Text,
					Email = emailEditText.Text
				};
				Database.db.Insert(contact);
				ContactsAdapter.Add(contact);
				Intent intent = new Intent(this,typeof(MainActivity));
				SetResult(Result.Ok, intent);
				Finish();
			}

		}
	}
}
