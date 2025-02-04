using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCRUD.DTOs;

namespace MovieCRUD.Extensions;

public static class MovieExtensions
{
    public static double ToHours(this int minutes)
    {
        return Math.Round(minutes / 60.0);
    }

    public static long TotalBoxOfficeEarnings(this List<MovieDto> movies)
    {
        var sum = 0l;
        foreach (var movie in movies)
        {
            sum += movie.BoxOfficeEarnings;
        }
        return sum;
    }
}

