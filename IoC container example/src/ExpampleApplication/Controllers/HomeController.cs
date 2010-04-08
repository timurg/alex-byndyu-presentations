using System.Web.Mvc;
using Domain.Entities;
using Services;

namespace ExpampleApplication.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            Product product = productService.FindLastCreatedProduct();

            return View(product);
        }
    }
}