using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieCRUD.DataAccess.Entities;

namespace MovieCRUD.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies;

    private readonly string _path = "../../../DataAccess/Data/Movies.json";

    public MovieRepository()
    {
        if (File.Exists(_path))
        {
            var json = File.ReadAllText(_path);
            _movies = JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }
        else
        {
            _movies = new List<Movie>();
        }
    }


    public void Add(Movie movie)
    {
        foreach (var film in _movies)
        {
            if (film.Id == movie.Id)
            {
                throw new Exception("This movie is already Added!");
            }
        }
        _movies.Add(movie);
        SaveData();
    }

    public void Delete(Guid id)
    {
        foreach(var film in _movies)
        {
            if (film.Id == id)
            {
                _movies.Remove(film);
            }
            else
            {
                throw new Exception("This Id is not found!");
            }
        }
        SaveData();
    }

    public List<Movie> GetAll()
    {
        return _movies;
    }

    public Movie GetById(Guid id)
    {
        foreach(var film in _movies)
        {
            if(film.Id == id)
            {
                return film;
            }
        }
       
        return null;
    }

    public void Update(Movie movie)
    {
        foreach(var film in _movies)
        {
            if(film.Id == movie.Id)
            {
                film.Director = movie.Director;
                film.DurationMinutes = movie.DurationMinutes;
                film.Rating = movie.Rating;
                film.Title = movie.Title;
                film.BoxOfficeEarnings = movie.BoxOfficeEarnings;
                film.ReleaseDate = movie.ReleaseDate;
            }
        }
        SaveData();
    }

    private void SaveData()
    {
        var json = JsonSerializer.Serialize(_movies);
        File.WriteAllText(_path, json);
    }
}
