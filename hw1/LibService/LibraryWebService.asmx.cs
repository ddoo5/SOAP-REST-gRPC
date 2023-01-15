using LibService;
using LibService.DB;
using LibService.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
//using System.Web.Services;

//namespace LibraryService
//{
//    [WebService(Namespace = "http://tempuri.org/")]
//    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//    [ToolboxItem(false)]
//    public class LibraryWebService : System.Web.Services.WebService
//    {
//        private readonly ILibRepository _libraryRepositoryService;



//        public LibraryWebService()
//        {
//            _libraryRepositoryService = new LibRepository(new LibDatabaseContext());
//        }



//        [WebMethod]
//        public Book[] GetBooksByTitle(string title)
//        {
//            return _libraryRepositoryService.GetByTitle(title).ToArray();
//        }


//        [WebMethod]
//        public Book[] GetBooksByAuthor(string authorName)
//        {
//            return _libraryRepositoryService.GetByAuthor(authorName).ToArray();
//        }


//        [WebMethod]
//        public Book[] GetBooksByCategory(string category)
//        {
//            return _libraryRepositoryService.GetByCategory(category).ToArray();
//        }
//    }
//}
