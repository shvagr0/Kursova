using System;
using System.Text;
using Kursova.View;

namespace Kursova
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Вибір працівника";
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            CMD.PickSeller();

            Console.Clear();

            while (true)
            {
                switch (CMD.MainMenu())
                {
                    case 1:
                        {
                            Console.Clear();
                            switch (CMD.ViewData())
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        CMD.printAllProducts();
                                        Console.WriteLine("\nНатисніть будь яку клавішу для повернення...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        CMD.printAllDelivery();
                                        Console.WriteLine("\nНатисніть будь яку клавішу для повернення...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Clear();
                                        CMD.printAllOrders();
                                        Console.WriteLine("\nНатисніть будь яку клавішу для повернення...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                default:
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                
                            }
                            break;
                        }
                    case 2:
                        {
                            switch(CMD.AddMenu())
                            {
                                case 1:
                                    {
                                        CMD.AddNewProduct();
                                        Console.Clear();
                                        break;
                                    }
                                case 2:
                                    {
                                        CMD.AddNewOrder();
                                        Console.Clear();
                                        break;
                                    }
                                case 3:
                                    {
                                        CMD.AddNewDelivery();
                                        Console.Clear();
                                        break;
                                    }
                                default :
                                    {
                                        Console.Clear();
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {

                            switch (CMD.SellersMenu())
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        CMD.printAllSellers();
                                        Console.WriteLine("\nНатисніть будь яку клавішу для повернення...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        CMD.AddNewSeller();
                                        Console.WriteLine("\nНатисніть будь яку клавішу для повернення...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Clear();
                                        CMD.removeSeller();
                                        Console.WriteLine("\nНатисніть будь яку клавішу для повернення...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                            }
                            break;
                        }
                    case 4:
                        {
                            CMD.ChangeProduct();
                            Console.WriteLine("\nДані змінено!");
                            Console.WriteLine("Натисніть будь яку клавішу для повернення...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                }
            }

        }
    }
}
