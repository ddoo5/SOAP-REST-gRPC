using System;
namespace LibService.View.Models
{
	public class BookCategoryViewModel
	{
		public IList<Book> Books { get; set; }

		public SearchType SearchType { get; set; }

		public string? SearchString { get; set; }
	}
}

