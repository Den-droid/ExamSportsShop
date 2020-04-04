using ExamTask.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ExamTask.DAL.Models;
using ExamTask.DAL.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTask.DAL.Repositories
{
    public class ProductRepository : IProducts
    {
        private readonly EFDbContext _context;
        public ProductRepository(EFDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProducts => _context.Products.Include(x => x.Category);
        public IEnumerable<Product> GetAvProducts => _context.Products
            .Where(x => x.Available)
            .Include(x => x.Category);

        public Product GetProduct(int id) => _context.Products.FirstOrDefault(x => x.Id == id.ToString());
    }
}