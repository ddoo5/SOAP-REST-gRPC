using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibService.DB;
using LibService.Service;
using LibService.View.Models;
using Microsoft.AspNetCore.Mvc;



namespace LibService.View.Controllers
{
    public class LibController : Controller
    {
        private LibRepository client;


        public LibController()
        {
            client = new(new LibDatabaseContext());
        }


        public IActionResult Index(SearchType searchType, string searchStr)
        {
            if(!string.IsNullOrEmpty(searchStr) && searchStr.Length >=4)
                switch (searchType)
                {
                    case SearchType.Title:
                        return View(new BookCategoryViewModel()
                        {
                            Books = client.GetByTitle(searchStr)
                        });
                    case SearchType.Category:
                        return View(new BookCategoryViewModel()
                        {
                            Books = client.GetByCategory(searchStr)
                        });
                    case SearchType.Author:
                        return View(new BookCategoryViewModel()
                        {
                            Books = client.GetByAuthor(searchStr)
                        });
                }




            return View(new BookCategoryViewModel() { Books = new Book[] {} });
        }
    }
}

