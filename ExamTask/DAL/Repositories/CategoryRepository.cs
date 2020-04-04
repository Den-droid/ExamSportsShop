using ExamTask.DAL.EFContext;
using ExamTask.DAL.Interfaces;
using ExamTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTask.DAL.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly EFDbContext _context;

        public CategoryRepository(EFDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;
    }
}