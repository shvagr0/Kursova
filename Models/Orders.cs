using System;

namespace Kursova.Models
{
    public class Orders
    {
        public DateTime OrderDate;
        public Seller Seller;
        public List<Sale> Sales;

        public Orders(DateTime orderDate, Seller seller, List<Sale> sales)
        {
            OrderDate = orderDate;
            Seller = seller;
            Sales = sales;
        }

        public override string ToString()
        {
            string result = string.Empty;
            int num = 1;
            decimal total = 0;
            foreach (Sale s in Sales)
            {
                decimal sum = s.Count * s.Price;
                result += num.ToString() + ",\t" + s.Product.Name + ",\t"
                    + s.Count + ",\t" + s.Price + ",\t" + sum +
                    ",\t" + OrderDate.ToString() + ",\t" +
                    Seller.fName + " " + Seller.lName[0] + ". " +
                    Seller.fatherName[0] + ".\n";
                num++;
                total += sum;
                    
            }
            return result;
        }
    }
}
