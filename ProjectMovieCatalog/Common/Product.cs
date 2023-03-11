using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMovieCatalog.Common
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public string Director { get; set; }
        public int Views { get; set; }
        public string MainActor { get; set; }
        public string MostViewsInOneMonth { get; set; }

        public Product()
        {

        }

        public Product(int id, string title, int views, string genre, string description, string producer, string director, string mainActor, string mostViewsInOneMonth)
        {
            this.Id = id;
            this.Title = title;
            this.Views = views;
            this.Genre = genre;
            this.Description = description;
            this.Producer = producer;
            this.Director = director;
            this.MainActor = mainActor;
            this.MostViewsInOneMonth = mostViewsInOneMonth;
        }
    }
}
