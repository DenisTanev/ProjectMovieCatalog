using ProjectMovieCatalog.Common;
using ProjectMovieCatalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMovieCatalog.Business
{
    internal class MovieBusiness
    {
        private MovieData manager = new MovieData();

        public List<Movie> GetAll()
        {
            return manager.GetAll();
        }
        public Movie GetById(int id)
        {
            return manager.GetById(id);
        }
        public void Add(Movie product)
        {
            manager.Add(product);
        }
        public void Update(Movie product)
        {
            manager.Update(product);
        }
        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}
