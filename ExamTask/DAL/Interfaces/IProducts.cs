using ExamTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTask.DAL.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> GetProducts { get; }
        IEnumerable<Product> GetAvProducts { get; }
        Product GetProduct(int Id);
    }
}