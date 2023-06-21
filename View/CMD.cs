using System;
using Kursova.Controller;

namespace Kursova.View
{
    public static class CMD
    {
        static Controller.Controller controller = new Controller.Controller();

        public static int MainMenu()
        {
            Console.WriteLine("1. Переглянути дані");
            Console.WriteLine("2. Додати дані");
            Console.WriteLine("3. Управління кадрами");
            Console.WriteLine("4. Редагувати дані товару");

            int input;
            try
            {
                input = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                return MainMenu();
            }


            if (input < 0 || input > 4)
            {
                Console.Clear();
                return MainMenu();
            }
            else
            {
                Console.Clear();
                return input;
            }
           
        }

        public static int ViewData()
        {
            Console.WriteLine("1. Переглянути товари на складі;");
            Console.WriteLine("2. Переглянути покупки магазину;");
            Console.WriteLine("3. Переглянути продажі магазину;");
            Console.WriteLine("\n0. Назад;");

            int input;
            try
            {
                input = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                return ViewData();
            }


            if (input < 0 || input > 3)
            {
                Console.Clear();
                return ViewData();
            }
            else return input;
        }

        public static void PickSeller()
        {
            if (controller.Sellers.Count == 0)
            {
                Console.WriteLine("Зараз відсутні працюючі працівники");
                Console.WriteLine("Додайте нового працівника");

                CMD.AddNewSeller();
                controller.PickSeller(controller.Sellers[0]);
            }
            else
            {
                CMD.printAllSellers();
                
                while (true)
                {
                    int input;
                    Console.WriteLine("Виберіть працівника зі списку або додайте нового (Enter)");
                    Int32.TryParse(Console.ReadLine(), out input);
                    if (input == 0)
                    {
                        CMD.AddNewSeller();
                        controller.PickSeller(controller.Sellers.Last());
                        break;
                    }
                    if (input > 0 && input <= controller.Sellers.Count)
                    {
                        controller.PickSeller(controller.Sellers[input - 1]);
                        break;
                    }
                }
                controller.SaveData();
            }

            Console.Title = "Сесія працівника: " + controller._seller.fName + " " + controller._seller.lName + " " + controller._seller.fatherName;
        }

        public static int SellersMenu()
        {
            Console.WriteLine("1. Переглянути працівників");
            Console.WriteLine("2. Додати працівника");
            Console.WriteLine("3. Звільнити працівника");

            Console.WriteLine("\n0. Назад;");

            int input;
            try
            {
                input = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                return SellersMenu();
            }

            if (input < 0 || input > 3)
            {
                Console.Clear();
                return SellersMenu();
            }
            else return input;
        }

        public static int AddMenu()
        {
            Console.WriteLine("1. Додати товар;");
            Console.WriteLine("2. Додати продаж;");
            Console.WriteLine("3. Додати поставку товару;");
            Console.WriteLine("\n0. Назад;");

            int input;
            try
            {
                input = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                return ViewData();
            }


            if (input < 0 || input > 3)
            {
                Console.Clear();
                return ViewData();
            }
            else return input;
        }

        public static void AddNewProduct()
        {
            string productType = String.Empty;
            while(true)
            {
                Console.Write("1/7 Введіть тип продукту: ");
                productType = Console.ReadLine();
                if (productType.Length > 0 && productType != null)
                    break;
                else
                    Console.WriteLine("Заповніть це поле!");
            }

            string manufacturer = String.Empty;
            while (true)
            {
                Console.Write("2/7 Постачальник: ");
                manufacturer = Console.ReadLine();
                if (manufacturer.Length > 0 && manufacturer != null)
                    break;
                else
                    Console.WriteLine("Заповніть це поле!");
            }

            string productName = String.Empty;
            while (true)
            {
                Console.Write("3/7 Назва товару: ");
                productName = Console.ReadLine();
                if (productName.Length > 0 && productName != null)
                    break;
                else
                    Console.WriteLine("Заповніть це поле!");
            }

            uint count = 0;
            while(true)
            {
                Console.Write("4/7 Кількість: ");
                UInt32.TryParse(Console.ReadLine(), out count);
                if (count > 0)
                    break;
                Console.WriteLine("Введіть натуральне число!");
                
            }

            decimal price = 0;
            while(true)
            {

                Console.Write("5/7 Ціна: ");
                Decimal.TryParse(Console.ReadLine(), out price);
                if (price > 0)
                    break;
                Console.WriteLine("Невірний формат вхідних даних!");
               
            }

            float weight = 0;
            while(true)
            {
                try
                {
                    Console.Write("6/7 Вага: ");
                    weight = Single.Parse(Console.ReadLine());
                    if (weight < 0)
                        throw new Exception();
                    break;
                }
                catch
                {
                    Console.WriteLine("Невірний формат вхідних даних!");
                }

            }

            string desctiption = String.Empty;
            Console.Write("7/7 Короткий опис: ");
            desctiption = Console.ReadLine();

            var newProduct = new Kursova.Models.Product(
                productType, manufacturer, productName, count,
                price, weight, desctiption);
            controller.AddProduct(newProduct);
            controller.SaveData();
        }

        public static void AddNewSeller()
        {
            
            string fName = String.Empty;
            while (true)
            {
                Console.Write("1/4 Імя: ");
                fName = Console.ReadLine();
                if (fName.Length > 0 && fName != null)
                    break;
                else
                    Console.WriteLine("Заповніть це поле!");
            }

           
            string lName = String.Empty;
            while (true)
            {
                Console.Write("2/4 Прізвище: ");
                lName = Console.ReadLine();
                if (lName.Length > 0 && lName != null)
                    break;
                else
                    Console.WriteLine("Заповніть це поле!");
            }

            
            string fatherName = String.Empty;
            while (true)
            {
                Console.Write("3/4 По батькові: ");
                fatherName = Console.ReadLine();
                if (fatherName.Length > 0 && fatherName != null)
                    break;
                else
                    Console.WriteLine("Заповніть це поле!");
            }

            
            string phone = String.Empty;
            while (true)
            {
                Console.Write("4/4 Телефон: ");
                phone = Console.ReadLine();
                if (System.Text.RegularExpressions.Regex.IsMatch(phone, "^\\+?[1-9][0-9]{7,14}$"))
                    break;
                else
                    Console.WriteLine("Некоректний формат!");
            }

            controller.AddSeller(new Models.Seller(fName, lName, fatherName, phone));
            controller.SaveData();
            Console.WriteLine("Працівника додано!");
        }
        public static void AddNewDelivery()
        {
            if(controller.Products.Count == 0)
            {
                Console.WriteLine("Немає товарів! Спочатку додайте їх!");
                return;
            }

            Console.WriteLine("Виберіть товар зі списку");
            printAllProducts();
            Models.Product product;
            while(true)
            {
                int input;
                Int32.TryParse(Console.ReadLine(), out input);
                if(input > 0 && input <= controller.Products.Count)
                {
                    product = controller.Products[input - 1];
                    break;
                }

            }

            int count = -1;
            do
            {
                Console.Write("Введіть кількість товару: ");
                Int32.TryParse(Console.ReadLine(), out count);
            }
            while (count <= 0);

            decimal price = -1;
            do
            {
                Console.Write("Введіть ціну товару: ");
                Decimal.TryParse(Console.ReadLine(), out price);
            }
            while (price <= 0);

            controller.AddDelivery(new Models.Delivery(DateTime.Now, product, (uint)count, price));
            controller.SaveData();
        }

        public static void AddNewOrder()
        {
            
            var products = new List<Models.Sale>();

            while(true)
            {
                Console.WriteLine("Виберіть товар");
                printAllProducts();
                int input;
                while (true)
                {
                    Int32.TryParse(Console.ReadLine(), out input);
                    if (input > 0 && input <= controller.Products.Count)
                        break;
                }
                uint count;
                while(true)
                {
                    Console.Write("Введіть кількість товару: ");
                    UInt32.TryParse((Console.ReadLine()), out count);
                    if (!(count <= 0 || count > controller.Products[input - 1].Count))
                        break;
                    else
                        Console.WriteLine("Кількість товару неможе бути меншою ніж 0 і більшою ніж кількість товару в магазині");

                }
                controller.Products[input - 1].Count -= count;
                products.Add(new Models.Sale(controller.Products[input - 1], count, controller.Products[input - 1].Price));

                char c;
                while (true)
                {
                    Console.WriteLine("Хочете додати ще товар? (т/н)");
                    Char.TryParse(Console.ReadLine(), out c);
                    if (c == 'н' || c == 'Н' || c == 'т' || c == 'Т')
                        break;

                }
                if (c == 'Н' || c == 'н')
                    break;
            }
            controller.AddOrder(new Models.Orders(DateTime.Now, controller._seller, products));
            controller.SaveData();
        }

        public static void printAllProducts()
        {
            Console.WriteLine("№\tТип\t\t\tПостач.\t\tІмя\tК-cть\tЦіна\tВага\tОпис");
            int num = 1;
            foreach(var product in controller.Products)
            {
                Console.WriteLine(num++ + ".\t" + product.ToString() + ";");
            }
        }

        public static void printAllDelivery()
        {
            Console.WriteLine("№\tІмя\tПоcтач.\tДата\t\t\tК-сть\tЦіна\tЗаплаченно");
            int num = 1;
            foreach(var delivery in controller.Delivery)
            {
                Console.WriteLine(num++ + ",\t" + delivery.ToString());
            }
        }

        public static void printAllOrders()
        {
            Console.WriteLine("№\tІмя\tК-сть\tЦіна\tСума\tДата\t\tПІБ працівника");
            int num = 1;
            foreach(var order in controller.Orders)
            {
                Console.WriteLine(num++ + ":\n " + order.ToString());
            }
        }

        public static void printAllSellers()
        {
            Console.WriteLine("№\tІмя\tПрізвище\tПо-бат.\t\tТелефон");
            int num = 1;
            foreach(var seller in controller.Sellers)
            {
                Console.WriteLine(num++ + ",\t" + seller.ToString());
            }
        }

        public static void removeSeller()
        {
            printAllSellers();
            int input;

            if(controller.Sellers.Count == 1)
            {
                Console.WriteLine("Зараз працюєте лише ви!");
                Console.WriteLine("Ви не можете звільнити себе!");
                return;
            }    

            while(true)
            {
                input = -1;
                Console.WriteLine("Введіть порядковий номер працівника якого потрібно звільнити");
                Int32.TryParse(Console.ReadLine(), out input);

                
                if (input > 0 && input <= controller.Sellers.Count)
                {
                    if (controller.Sellers[input - 1] == controller._seller)
                        Console.WriteLine("Ви не можете звільнити себе!");
                    else
                        break;
                }
            }
            controller.Sellers.RemoveAt(input-1);
            Console.WriteLine("Працівник звільнений");
            controller.SaveData();
        }

        public static void ChangeProduct()
        {
            Models.Product product;
            if (controller.Products.Count == 0)
            {
                Console.WriteLine("Немає товарів! Спочатку додайте їх!");
                return;
            }
            int num = 0;
            printAllProducts();
            while(true)
            {
                int input = 0;
                Console.Write("Виберіть товар для редагування: ");
                Int32.TryParse(Console.ReadLine(), out num);

                if (num > 0 && num <= controller.Products.Count)
                {
                    product = controller.Products[num - 1];
                    break;
                }
            }
            int field = 0;
            

            while(true)
            {
                while (true)
                {
                    Console.WriteLine("Виберіть поле яке ви хоче змінити: ");
                    Console.WriteLine("1. Тип товару");
                    Console.WriteLine("2. Постачальник");
                    Console.WriteLine("3. Назва товару");
                    Console.WriteLine("4. Кількість");
                    Console.WriteLine("5. Ціна");
                    Console.WriteLine("6. Вага");
                    Console.WriteLine("7. Опис");
                    Int32.TryParse(Console.ReadLine(), out field);

                    if (field > 0 && field <= 7)
                        break;
                }

                switch (field)
                {
                    case 1:
                        {
                            string productType = String.Empty;
                            while (true)
                            {
                                Console.Write("1/7 Введіть тип товару: ");
                                productType = Console.ReadLine();
                                if (productType.Length > 0 && productType != null)
                                    break;
                                else
                                    Console.WriteLine("Заповніть це поле!");
                            }
                            product.ProductType = productType;
                            break;
                        }

                    case 2:
                        {
                            string manufacturer = String.Empty;
                            while (true)
                            {
                                Console.Write("2/7 Постачальник: ");
                                manufacturer = Console.ReadLine();
                                if (manufacturer.Length > 0 && manufacturer != null)
                                    break;
                                else
                                    Console.WriteLine("Заповніть це поле!");
                            }
                            product.Manufacturer = manufacturer;
                            break;
                        }
                    case 3:
                        {
                            string productName = String.Empty;
                            while (true)
                            {
                                Console.Write("3/7 Назва товару: ");
                                productName = Console.ReadLine();
                                if (productName.Length > 0 && productName != null)
                                    break;
                                else
                                    Console.WriteLine("Заповніть це поле!");
                            }
                            product.Name = productName;
                            break;
                        }
                    case 4:
                        {
                            uint count = 0;
                            while (true)
                            {
                                Console.Write("4/7 Кількість: ");
                                UInt32.TryParse(Console.ReadLine(), out count);
                                if (count > 0)
                                    break;
                                Console.WriteLine("Введіть натуральне число!");

                            }
                            product.Count = count;
                            break;
                        }
                    case 5:
                        {
                            decimal price = 0;
                            while (true)
                            {

                                Console.Write("5/7 Ціна: ");
                                Decimal.TryParse(Console.ReadLine(), out price);
                                if (price > 0)
                                    break;
                                Console.WriteLine("Невірний формат вхідних даних!");

                            }
                            product.Price = price;
                            break;
                        }
                    case 6:
                        {
                            float weight = 0;
                            while (true)
                            {
                                Console.Write("6/7 Вага: ");
                                Single.TryParse(Console.ReadLine(), out weight);
                                if (weight > 0)
                                    break;
                                Console.WriteLine("Невірний формат вхідних даних!");
                            }
                            product.Weight = weight;
                            break;
                        }
                    case 7:
                        {
                            string desctiption = String.Empty;
                            Console.Write("7/7 Короткий опис: ");
                            desctiption = Console.ReadLine();
                            product.Description = desctiption;
                            break;
                        }
                }
                while(true)
                {
                    char c;
                    Console.Write("Хочете змінити ще щось? (т/н) ");
                    Char.TryParse(Console.ReadLine(), out c);
                    if (c == 'Т' || c == 'т')
                        break;
                    if (c == 'Н' || c == 'н')
                        return;
                }
                controller.SaveData();
            }
        }
    }
}
