using MovieCRUD.DataAccess.Entities;

namespace MovieCRUD.Repositories;

public interface IMovieRepository
{
    void Add(Movie movie);
    void Update(Movie movie);
    void Delete(Guid id);
    Movie GetById(Guid id);
    List<Movie> GetAll();
}