
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

		public const int PickImageId = 1000;

		private string ImageURI = null;

		EditText nameEditText;
		EditText emailEditText;
		Button saveContactButton, pickImageButton;
		Contact contact;
		ImageView contactImageView;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//ActionBar.Hide();
			ActionBar.SetDisplayHomeAsUpEnabled(true);

			SetContentView(Resource.Layout.NewContact);

			nameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
			emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
			saveContactButton = FindViewById<Button>(Resource.Id.saveContactButton);
			pickImageButton = FindViewById<Button>(Resource.Id.pickImageButton);
			contactImageView = FindViewById<ImageView>(Resource.Id.contactImageView);

			saveContactButton.Click+= SaveContactButton_Click;
			pickImageButton.Click+= PickImageButton_Click;



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
					Email = emailEditText.Text,
					Image = this.ImageURI
				};
				Database.db.Insert(contact);
				ContactsAdapter.Add(contact);
				Intent intent = new Intent(this,typeof(MainActivity));
				SetResult(Result.Ok, intent);
				Finish();
			}

		}

		void PickImageButton_Click(object sender, EventArgs e)
		{

			Intent intent = new Intent();
			intent.SetType("image/*");
			intent.SetAction(Intent.ActionGetContent);
			StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), PickImageId);

		}


		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			if (resultCode != Result.Ok) {
				return;
			}

			switch (requestCode) {
				case PickImageId:
					Android.Net.Uri uri = data.Data;
					contactImageView.SetImageURI(uri);
					this.ImageURI = uri.ToString();
					break;
				default:
					break;
			}
		}

	}
}
