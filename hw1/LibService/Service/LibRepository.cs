using System;
using LibService.DB;

namespace LibService.Service
{
	public class LibRepository : ILibRepository
	{
        private readonly ILibDatabaseContext _dbContext;



        public LibRepository(ILibDatabaseContext dbContext)
		{
            _dbContext = dbContext;
		}



        public int? Add(Book item)
        {
            throw new NotImplementedException();
        }


        public int Delete(Book item)
        {
            throw new NotImplementedException();
        }


        public IList<Book> GetAll()
        {
            throw new NotImplementedException();
        }


        public IList<Book> GetByAuthor(string author)
        {
            try
            {
                return _dbContext.Books.Where(x => x.Authors
                .Where(y => y.Name.ToLower().Contains(author.ToLower())).Count() > 0).ToList();
            }
            catch
            {
                return null;
            }
        }


        public IList<Book> GetByCategory(string category)
        {
            try
            {
                return _dbContext.Books.Where(x => x.Category.ToLower().Contains(category.ToLower())).ToList();
            }
            catch
            {
                return null;
            }
        }


        public Book GetById<TId>(TId id)
        {
            throw new NotImplementedException();
        }


        public IList<Book> GetByTitle(string title)
        {
            try
            {
                return _dbContext.Books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
            }
            catch
            {
                return null;
            }
        }


        public int Update(Book item)
        {
            throw new NotImplementedException();
        }
    }
}

