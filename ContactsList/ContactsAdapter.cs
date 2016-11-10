using System;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System.Collections.Generic;
using Android.App;

namespace ContactsList
{
	public class ContactsAdapter : BaseAdapter
	{

		public static List<Contact> _contacts;
		private Activity _activity; 

		public ContactsAdapter(Activity activity) {
			this._activity = activity;
			//_contacts = Database.db.Query<Contact>("select * from Contact");
		}

		public override int Count
		{
			get
			{
				//var total = Database.db.ExecuteScalar<int>("select count(*) from Contact");
				//return total;
				return _contacts.Count;
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			throw new NotImplementedException();
		}

		public override long GetItemId(int position)
		{
			return _contacts[position].Id;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? this._activity.LayoutInflater.Inflate(Resource.Layout.ContactRow, parent, false);

			TextView nameTextView = view.FindViewById<TextView>(Resource.Id.nameTextView);
			TextView emailEditText = view.FindViewById<TextView>(Resource.Id.emailTextView);
			ImageView contactImage = view.FindViewById<ImageView>(Resource.Id.contactImage);

			nameTextView.Text = _contacts[position].Name;
			emailEditText.Text = _contacts[position].Email;
			if (_contacts[position].Image != null) {
				contactImage.SetImageURI(Android.Net.Uri.Parse(_contacts[position].Image));
			}

			return view;
		}

		public static void Add(Contact contact) {
			_contacts.Add(contact);
			sortByName();
		}

		public static void sortByName() {
			_contacts.Sort((Contact x, Contact y) => x.Name.CompareTo(y.Name));
		}
	}
}
