using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _repo;
        public int PageSize = 4; // 4 products/page

        public HomeController(IStoreRepository repo)
        {
            _repo = repo;
        }

        //public IActionResult Index() => View(_repo.Products);

        public ViewResult Index(int productPage = 1) => 
            View(_repo.Products                                      // get products from repo
                .OrderBy(p => p.ProductID)                           // order by id
                .Skip((productPage - 1) * PageSize)                  // skip products occurring before the start of the current page
                .Take(PageSize)                                      // take 4 products
        );
    }
}
