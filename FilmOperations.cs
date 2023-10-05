namespace LinqExercise;

public class FilmOperations
{

    private List<Film> movies; //  hold the list of movies

    public FilmOperations(List<Film> movieList)
    {
        movies = movieList;
    }


    /// <returns>eine Liste aller Filme zurück.</returns>
    public List<Film> GetAllMovies()
    {
        return movies;
        
    }


    /// <returns>ein Array von Filmen zurück, die von dem angegebenen Regisseur stammen.</returns>
    public Film[] GetMoviesByDirector(string directorName)
    {
        if (string.IsNullOrEmpty(directorName))
        {
            throw new ArgumentException("Director name cannot be null or empty.");
        }
        return movies.Where(movie => movie.director == directorName).ToArray();
        
    }



    /// <returns>ein Array von Filmen zurück, die im angegebenen Erscheinungsjahr veröffentlicht wurden.</returns>
    public Film[] GetMoviesByYear(int releaseYear)
    {
        if (releaseYear < 1900 || releaseYear > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException("Invalid release year.");
        }
        return movies.Where(movie => movie.releaseYear == releaseYear).ToArray();
        
    }


   
    /// <returns>ein Array von Filmen zurück, die zwischen der angegebenen Mindest- und Höchstbewertung liegen.</returns>
    public Film[] GetMoviesByRatingRange(double minRating, double maxRating)
    {
        if (minRating < 0 || maxRating > 10 || minRating > maxRating)
        {
            throw new ArgumentOutOfRangeException("Invalid rating range.");
        }
        return movies.Where(movie => movie.rating >= minRating && movie.rating <= maxRating).ToArray();
       
    }


    
    /// <returns>gibt ein Array mit den best bewerteten Filme zurück, sortiert nach Bewertung. numberOfFilms gibt die
    /// Anzahl der zurückgegeben Filme an.</returns>
    public Film[] GetMoviesByRatingSortedLimited(int numberOfFilms)
    {
        if (numberOfFilms <= 0 || numberOfFilms > movies.Count)
        {
            throw new ArgumentOutOfRangeException("Invalid number of films requested.");
        }
        return movies.OrderByDescending(movie => movie.rating).Take(numberOfFilms).ToArray();
        
    }
}