using MovieCRUD.DTOs;

namespace MovieCRUD.Services;

public interface IMovieService
{
    void CreateMovie(MovieDto movieDto);
    void UpdateMovie(MovieDto movieDto);
    void DeleteMovie(Guid id);
    List<MovieDto> GetAllMovies();
    MovieDto GetMovieById(Guid id);
}