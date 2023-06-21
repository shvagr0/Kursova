using System;
using Kursova.Models;
using Newtonsoft.Json;

namespace Kursova.Controller
{
    public partial class Controller
    {
        public List<Delivery> Delivery;
        public List<Product> Products;
        public List<Orders> Orders;
        public List<Seller> Sellers;

        public Seller ?_seller;

        public Controller()
        {
            LoadData();
            _seller = null;
        }

        public void SaveData()
        {
            try
            {
                string productListjson = JsonConvert.SerializeObject(Products, Formatting.Indented);
                File.WriteAllText("productList.json", productListjson);

                string sellersListjson = JsonConvert.SerializeObject(Sellers, Formatting.Indented);
                File.WriteAllText("sellersList.json", sellersListjson);

                string deliveryListjson = JsonConvert.SerializeObject(Delivery, Formatting.Indented);
                File.WriteAllText("deliveryList.json", deliveryListjson);

                string orderListjson = JsonConvert.SerializeObject(Orders, Formatting.Indented);
                File.WriteAllText("orderList.json", orderListjson);
            }
            catch
            {
                //TODO
            }
        }

        public void LoadData()
        {
            try
            {
                string productListjson = File.ReadAllText("productList.json");
                Products = JsonConvert.DeserializeObject<List<Product>>(productListjson);
            }
            catch
            {
                Products = new List<Product>();
            }

            try
            {
                string sellersListjson = File.ReadAllText("sellersList.json");
                Sellers = JsonConvert.DeserializeObject<List<Seller>>(sellersListjson);
            }
            catch
            {
                Sellers = new List<Seller>();
            }

            try
            {
                string deliveryListjson = File.ReadAllText("deliveryList.json");
                Delivery = JsonConvert.DeserializeObject<List<Delivery>>(deliveryListjson);
            }
            catch
            {
                Delivery = new List<Delivery>();
            }

            try
            {
                string orderListjson = File.ReadAllText("orderList.json");
                Orders = JsonConvert.DeserializeObject<List<Orders>>(orderListjson);
            }
            catch
            {
                Orders = new List<Orders>();
            }

        }

        public void PickSeller(Seller seller)
        {
            if (Sellers.Contains(seller))
                _seller = seller;
            else
                throw new ArgumentException();
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public void AddDelivery(Delivery delivery)
        {
            Delivery.Add(delivery);
            foreach(var product in Products)
            {
                if(product == delivery.Product)
                {
                    product.Count += delivery.Count;
                }
            }
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void AddOrder(Orders sale)
        {
            Orders.Add(sale);
        }

    }
}
