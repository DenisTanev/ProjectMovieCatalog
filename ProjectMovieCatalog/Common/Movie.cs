using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMovieCatalog.Common
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Producer { get; set; }
        public string Director { get; set; }
        public int Views { get; set; }
        public string MonthWithMostViews { get; set; }

        public Movie()
        {

        }

        public Movie(int id, int year, string title, int views, string genre, string producer, string director, string monthWithMostViews)
        {
            this.Id = id;
            this.Title = title;
            this.Genre = genre;
            this.Views = views;
            this.MonthWithMostViews = monthWithMostViews;
            this.Director = director;
            this.Producer = producer;
            this.Year = year;
        }
    }
}
