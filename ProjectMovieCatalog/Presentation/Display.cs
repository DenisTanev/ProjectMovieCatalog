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
        private MovieBusiness movieBusiness = new MovieBusiness();
        private void ShowMenu()
        {
            Console.WriteLine(new String('-', 40));
            Console.WriteLine(new String(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine("1.List all movies");
            Console.WriteLine("2.Add new movie");
            Console.WriteLine("3.Update movie by ID");
            Console.WriteLine("4.Fetch movie by ID");
            Console.WriteLine("5.Delete movie by ID");
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
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        private void Add()
        {
            Movie movie = new Movie();
            Console.WriteLine("Enter title");
            movie.Title = Console.ReadLine();
            Console.WriteLine("Enter genre");
            movie.Genre = Console.ReadLine();
            Console.WriteLine("Enter the name of the producer");
            movie.Producer = Console.ReadLine();
            Console.WriteLine("Enter the name of the director");
            movie.Director = Console.ReadLine();
            Console.WriteLine("Enter the amount of views");
            movie.Views = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the month in which the movie was viewed the most");
            movie.MonthWithMostViews = Console.ReadLine();
            movieBusiness.Add(movie);
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete:");
            int id = int.Parse(Console.ReadLine());
            movieBusiness.Delete(id);
            Console.WriteLine("Done");
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update:");
            int id = int.Parse(Console.ReadLine());
            Movie movie = movieBusiness.GetById(id);
            if (movie != null)
            {
                Console.WriteLine("Enter title");
                movie.Title = Console.ReadLine();
                Console.WriteLine("Enter genre");
                movie.Genre = Console.ReadLine();
                Console.WriteLine("Enter the name of the producer");
                movie.Producer = Console.ReadLine();
                Console.WriteLine("Enter the name of the director");
                movie.Director = Console.ReadLine();
                Console.WriteLine("Enter the amount of views");
                movie.Views = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the month in which the movie was viewed the most");
                movie.MonthWithMostViews = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Movie movie = movieBusiness.GetById(id);
            if (movie != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + movie.Id);
                Console.WriteLine("Title: " + movie.Title);
                Console.WriteLine("Genre: " + movie.Genre);
                Console.WriteLine("Views: " + movie.Views);
                Console.WriteLine("Month with most views: " + movie.MonthWithMostViews);
                Console.WriteLine("Director: " + movie.Director);
                Console.WriteLine("Producer: " + movie.Producer);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
        }

        private void ListAll()
        {
            Console.WriteLine(new String('-', 40));
            Console.WriteLine(new String(' ', 18) + "Movies" + new string(' ', 18));
            var movies = movieBusiness.GetAll();
            foreach (var item in movies)
            {
                Console.WriteLine($"{item.Id} {item.Title} {item.Genre} {item.Views} {item.MonthWithMostViews} {item.Producer} {item.Director}");
            }
        }
    }
}
