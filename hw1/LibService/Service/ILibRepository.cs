using System;
namespace LibService.Service
{
	public interface ILibRepository : IRepository<Book, string>
	{
		IList<Book> GetByTitle(string title);

		IList<Book> GetByAuthor(string author);

		IList<Book> GetByCategory(string category);
	}
}

