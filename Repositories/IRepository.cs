using MoviesApp.Models;

namespace MoviesApp.Repositories
{
    public interface IRepository
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
        void Save();
    }
}