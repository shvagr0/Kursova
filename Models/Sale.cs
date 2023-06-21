using System;

namespace Kursova.Models
{
    public class Sale
    {
        public Product Product;
        public uint Count;
        public decimal Price;

        public Sale(Product product, uint count, decimal price)
        {
            Product = product;
            Count = count;
            Price = price;
        }

    }
}
