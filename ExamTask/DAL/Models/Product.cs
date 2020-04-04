using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTask.DAL.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool Available { get; set; }
        public string Guarantee { get; set; }
        public string Color { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}