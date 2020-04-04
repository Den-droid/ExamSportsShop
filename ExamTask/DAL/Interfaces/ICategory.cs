using ExamTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTask.DAL.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> Categories { get; }
    }
}