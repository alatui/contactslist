
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

namespace ContactsList
{
	[Activity(Label = "Details")]
	public class DetailsActivity : Activity
	{

		TextView detailsNameTextView;
		TextView detailsEmailTextView;
		ImageView detailsImageView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			ActionBar.SetDisplayHomeAsUpEnabled(true);

			// Create your application here
			SetContentView(Resource.Layout.ContactDetails);


			detailsNameTextView = FindViewById<TextView>(Resource.Id.detailsNameTextView);
			detailsEmailTextView = FindViewById<TextView>(Resource.Id.detailsEmailTextView);
			detailsImageView = FindViewById<ImageView>(Resource.Id.detailsImageView);

			Contact selectedContact = Database.db.Get<Contact>(Intent.Extras.GetLong("contact_id"));

			detailsNameTextView.Text = selectedContact.Name;
			detailsEmailTextView.Text = selectedContact.Email;
			if (selectedContact.Image != null) {
				detailsImageView.SetImageURI(Android.Net.Uri.Parse(selectedContact.Image));
			}

		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					Finish();
					break;
				default:
					break;
			}
			return true;
		}
	}
}
