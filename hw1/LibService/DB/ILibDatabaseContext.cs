using System;
namespace LibService.DB
{
	public interface ILibDatabaseContext
	{
        IList<Book> Books { get; }
    }
}

