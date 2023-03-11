using ProjectMovieCatalog.Business;
using ProjectMovieCatalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMovieCatalog.Presentation
{
    internal class Display
    {
        private ProductBusiness productBusiness = new ProductBusiness();
        private void ShowMenu()
        {
            Console.WriteLine(new String('-', 40));
            Console.WriteLine(new String(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine("1.List all entries");
            Console.WriteLine("2.Add new entry");
            Console.WriteLine("3.Update new entry");
            Console.WriteLine("4.Fetch entry by ID");
            Console.WriteLine("5.Delete entry by ID");
            Console.WriteLine("6.Exit");
        }
        public Display()
        {
            Input();
        }

        private void Input()
        {
            var operation = -1;
            var closeOperationId = 6;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        private void Add()
        {
            Product product = new Product();
            Console.WriteLine("Enter title");
            product.Title = Console.ReadLine();
            Console.WriteLine("Enter price");
            product.Genre = Console.ReadLine();
            Console.WriteLine("Enter the name of the producer");
            product.Producer = Console.ReadLine();
            Console.WriteLine("Enter the name of the director");
            product.Director = Console.ReadLine();
            Console.WriteLine("Enter the name of the main actor");
            product.MainActor = Console.ReadLine();
            Console.WriteLine("Enter the amount of views");
            product.Views = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name of the month with most views");
            product.MostViewsInOneMonth = Console.ReadLine();
            productBusiness.Add(product);
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete:");
            int id = int.Parse(Console.ReadLine());
            productBusiness.Delete(id);
            Console.WriteLine("Done");
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update:");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine("Enter title");
                product.Title = Console.ReadLine();
                Console.WriteLine("Enter price");
                product.Genre = Console.ReadLine();
                Console.WriteLine("Enter the name of the producer");
                product.Producer = Console.ReadLine();
                Console.WriteLine("Enter the name of the director");
                product.Director = Console.ReadLine();
                Console.WriteLine("Enter the name of the main actor");
                product.MainActor = Console.ReadLine();
                Console.WriteLine("Enter the amount of views");
                product.Views = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the name of the month with most views");
                product.MostViewsInOneMonth = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void ListAll()
        {
            Console.WriteLine(new String('-', 40));
            Console.WriteLine(new String(' ', 18) + "Products" + new string(' ', 18));
            var products = productBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.Title} {item.} {item.Stock}");
            }
        }
    }
}
