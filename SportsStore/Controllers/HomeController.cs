using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int pageSize = 4;
        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }
        //public IActionResult Index() => View(repository.Products);
        /*
         public ViewResult Index(int productPage = 1)
             => View(repository.Products
                 .OrderBy(p => p.Id)
                 .Skip((productPage - 1 )* pageSize)
                 .Take(pageSize));*/

        public ViewResult Index(string? category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.Id)
                    .Skip((productPage - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPages = productPage,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null
                    ? repository.Products.Count()
                    : repository.Products.Where(e =>
                    e.Category == category).Count()
                },
                CurrentCategory = category
            });


             
    }
}
