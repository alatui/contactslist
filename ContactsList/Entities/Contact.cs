using System;
using SQLite;

namespace ContactsList
{
	public class Contact
	{

		[PrimaryKey, AutoIncrement]
		public long Id { get; set; }
		[MaxLength(250)]
		public string Name { get; set; }
		[MaxLength(250)]
		public string Email { get; set; }
		[MaxLength(250)]
		public string Image { get; set; }
		
	}
}
