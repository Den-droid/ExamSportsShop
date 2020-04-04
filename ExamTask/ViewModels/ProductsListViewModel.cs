using ExamTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTask.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> GetProducts { get; set; }
        public string ProductCategory { get; set; }
    }
}