using System;

namespace Kursova.Models
{
    public class Delivery
    {
        public DateTime DeliveryDate;
        public Product Product;
        public uint Count;
        public decimal Price;

        public Delivery(DateTime deliveryDate, Product product, uint count, decimal price)
        {
            DeliveryDate = deliveryDate;
            Product = product;
            Count = count;
            Price = price;
        }

        public override string ToString()
        {
            string result = Product.Name + ",\t" + Product.Manufacturer +
                ",\t" + DeliveryDate.ToString() +
                    ",\t" + Count + ",\t" + Price + ",\t" +
                    Count * Price + "\n";
            
            return result;
        }
    }
}
