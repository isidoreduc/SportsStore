using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
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

        public ViewResult Index(string category, int productPage = 1) => 
            View(new ProductsListViewModel
            {
                Products = _repo.Products                                // get products from repo
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)                           // order by id
                    .Skip((productPage - 1) * PageSize)                  // skip products occurring before the start of the current page
                    .Take(PageSize),                                     // take 4 products
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        _repo.Products.Count() : 
                        _repo.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category
            }
                
        );
    }
}
