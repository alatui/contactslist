
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
	[Activity(Label = "NewContactActivity")]
	public class NewContactActivity : Activity
	{

		EditText nameEditText;
		EditText emailEditText;
		Button saveContactButton;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.NewContact);

			nameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
			emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
			saveContactButton = FindViewById<Button>(Resource.Id.saveContactButton);




			// Create your application here
		}
	}
}
