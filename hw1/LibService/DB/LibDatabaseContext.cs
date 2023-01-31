using System;
using System.Text;
using Newtonsoft.Json;

namespace LibService.DB
{
	public class LibDatabaseContext : ILibDatabaseContext
	{
		private IList<Book> _bookDatabase;
		public IList<Book> Books
		{
			get
			{
				return _bookDatabase;
			}
		}



		public LibDatabaseContext()
		{
			Initialize();
		}



		private void Initialize()
		{
			string data = "";
			using(StreamReader sr = new StreamReader(@"../LibService/Data/Books.json"))
			{
				data = sr.ReadToEnd();
			}

			_bookDatabase = JsonConvert
				.DeserializeObject<List<Book>>(data);
		}
	}
}

