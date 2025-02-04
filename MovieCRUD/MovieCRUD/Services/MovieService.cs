using MovieCRUD.DataAccess.Entities;
using MovieCRUD.DTOs;
using MovieCRUD.Repositories;

namespace MovieCRUD.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public void CreateMovie(MovieDto movieDto)
    {
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = movieDto.Title,
            Director = movieDto.Director,
            DurationMinutes = movieDto.DurationMinutes,
            Rating = movieDto.Rating,
            BoxOfficeEarnings = movieDto.BoxOfficeEarnings,
            ReleaseDate = movieDto.ReleaseDate
        };
        _movieRepository.Add(movie);
    }

    public void DeleteMovie(Guid id)
    {
        _movieRepository.Delete(id);
    }

    public List<MovieDto> GetAllMovies()
    {
        var allMovies = _movieRepository.GetAll();
        var movieDtos = new List<MovieDto>();

        foreach (var movie in allMovies)
        {
            movieDtos.Add(new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                DurationMinutes = movie.DurationMinutes,
                Rating = movie.Rating,
                BoxOfficeEarnings = movie.BoxOfficeEarnings,
                ReleaseDate = movie.ReleaseDate
            });
        }

        return movieDtos;
    }


    public MovieDto GetMovieById(Guid id)
    {
        var movie = _movieRepository.GetById(id);
        if (movie != null)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                DurationMinutes = movie.DurationMinutes,
                Rating = movie.Rating,
                BoxOfficeEarnings = movie.BoxOfficeEarnings,
                ReleaseDate = movie.ReleaseDate
            };
        }
        return null;
    }

    public void UpdateMovie(MovieDto movieDto)
    {
        throw new NotImplementedException();
    }
}
