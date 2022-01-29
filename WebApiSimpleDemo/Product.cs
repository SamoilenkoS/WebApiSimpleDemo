using System;

namespace WebApiSimpleDemo
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
