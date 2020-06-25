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

        public HomeController(IStoreRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index() => View(_repo.Products);
    }
}
