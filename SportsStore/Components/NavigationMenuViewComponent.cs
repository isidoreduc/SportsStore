using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IStoreRepository _repo;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            _repo = repo;
        }
        public IViewComponentResult Invoke() => View(_repo.Products
            .Select(p => p.Category)
            .Distinct()
            .OrderBy(x => x));
    }
}
