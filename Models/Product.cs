using System;

namespace Kursova.Models
{
    [Serializable]
    public class Product
    {
        public string ProductType;
        public string Manufacturer;
        public string Name;
        public uint Count;
        public decimal Price;
        public float Weight;
        public string Description;

        public Product(string productType, string manufacturer,
            string name, uint count, decimal price, float weight, string description)
        {

            ProductType = productType;
            Manufacturer = manufacturer;
            Name = name;
            Count = count;
            Price = price;
            Weight = weight;
            Description = description;
        }

        public override string ToString()
        {
            return $"{ProductType},\t{Manufacturer}," +
                $"\t{Name},\t{Count},\t{Price},\t{Weight},\t{Description}";
        }
    }
}
