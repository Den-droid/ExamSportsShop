using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExamTask.DAL.Interfaces;
using ExamTask.DAL.Models;
using ExamTask.ViewModels;

namespace ExamTask.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;
        private readonly ICategory _categories;

        public ProductsController(IProducts products, ICategory categories)
        {
            _products = products;
            _categories = categories;
        }

        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name);
        }

        [Route("Products/ListProducts")]
        [Route("Products/ListProducts/{category}")]
        public ViewResult ListProducts(string category)
        {
            IEnumerable<Product> products = null;
            string productCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                products = _products.GetProducts.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("Benzin", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _products.GetProducts.Where(x => x.Category.CategoryName.Equals("Benzin"))
                        .OrderBy(i => i.Id);
                }
                else if (string.Equals("Dizel", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _products.GetProducts.Where(x => x.Category.CategoryName.Equals("Dizel"))
                        .OrderBy(i => i.Id);
                }
                else
                {
                    products = _products.GetProducts.Where(x => x.Category.CategoryName.Equals("Electro"))
                        .OrderBy(i => i.Id);
                }

                productCategory = category;
            }

            var productObj = new ProductsListViewModel
            {
                GetProducts = products,
                ProductCategory = productCategory
            };

            ViewBag.Title = "All Products";
            //CarsListViewModel obj = new CarsListViewModel();
            //obj.GetCars = _cars.GetCars;
            //obj.CarCategory = "auto";

            return View(productObj);
        }
    }
}