using System;
using SQLite;
using System.IO;

namespace ContactsList
{
	public static class Database
	{

		public static SQLiteConnection db {
			get;
			private set;
		}

		public static void connect() {
			string dbPath = Path.Combine(
				System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
				"contacts_list.db3"
			);

			db = new SQLiteConnection(dbPath);
		}

		public static void CreateTables() {
			db.CreateTable<Contact>();//create Contact table
		}
	}
}
