using ProjectMovieCatalog.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMovieCatalog.Data
{
    internal class MovieData
    {
        public List<Movie> GetAll()
        {
            var movieList = new List<Movie>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM movies", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = new Movie(
                            reader.GetInt32(0),
                            reader.GetInt32(7),
                            reader.GetString(1),
                            reader.GetInt32(3),
                            reader.GetString(2),
                            reader.GetString(6),
                            reader.GetString(5),
                            reader.GetString(4)
                            );
                        movieList.Add(movie);
                    }
                }
                connection.Close();
            }
            return movieList;
        }

        public List<Movie> SortByGenre()
        {
            var movieList = new List<Movie>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM movies ORDER BY Genre ASC", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = new Movie(
                            reader.GetInt32(0),
                            reader.GetInt32(7),
                            reader.GetString(1),
                            reader.GetInt32(3),
                            reader.GetString(2),
                            reader.GetString(6),
                            reader.GetString(5),
                            reader.GetString(4)
                            );
                        movieList.Add(movie);
                    }
                }
                connection.Close();
            }
            return movieList;
        }

        public Movie GetById(int id)
        {
            Movie movie = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM movies WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        movie = new Movie(
                           reader.GetInt32(0),
                           reader.GetInt32(7),
                           reader.GetString(1),
                           reader.GetInt32(3),
                           reader.GetString(2),
                           reader.GetString(6),
                           reader.GetString(5),
                           reader.GetString(4)
                           );
                    }
                }
                connection.Close();
            }
            return movie;
        }
        public List<Movie> GetMoviesWithMostWatchedMonth(string monthWithMostViews)
        {
            var movieList = new List<Movie>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM movies WHERE MonthWithMostViews=@monthWithMostViews", connection);
                command.Parameters.AddWithValue("monthWithMostViews", monthWithMostViews);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = new Movie(
                            reader.GetInt32(0),
                            reader.GetInt32(7),
                            reader.GetString(1),
                            reader.GetInt32(3),
                            reader.GetString(2),
                            reader.GetString(6),
                            reader.GetString(5),
                            reader.GetString(4)
                            );
                        movieList.Add(movie);
                    }
                }
                connection.Close();
            }
            return movieList;
        }

        public void Add(Movie movie)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO movies(Title, Genre, Year, Views, MonthWithMostViews, Director, Producer) VALUES(@title, @genre, @year, @views, @monthwithmostviews, @director, @producer)", connection);
                command.Parameters.AddWithValue("title", movie.Title);
                command.Parameters.AddWithValue("genre", movie.Genre);
                command.Parameters.AddWithValue("year", movie.Year);
                command.Parameters.AddWithValue("views", movie.Views);
                command.Parameters.AddWithValue("monthwithmostviews", movie.MonthWithMostViews);
                command.Parameters.AddWithValue("director", movie.Director);
                command.Parameters.AddWithValue("producer", movie.Producer);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Update(Movie movie)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("UPDATE movies SET Title = @title, Genre = @genre, Year = @year, Views = @views, MonthWithMostViews = @monthwithmostviews, Director = @director, Producer = @producer WHERE Id = @id", connection);
                command.Parameters.AddWithValue("id", movie.Id);
                command.Parameters.AddWithValue("title", movie.Title);
                command.Parameters.AddWithValue("genre", movie.Genre);
                command.Parameters.AddWithValue("year", movie.Year);
                command.Parameters.AddWithValue("views", movie.Views);
                command.Parameters.AddWithValue("monthwithmostviews", movie.MonthWithMostViews);
                command.Parameters.AddWithValue("director", movie.Director);
                command.Parameters.AddWithValue("producer", movie.Producer);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("DELETE movies WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
