
using LinqExercise;
using Newtonsoft.Json;

namespace HelloLinq
{


    class Program
    {

        public static void Main()
        {
            //1. Read file

            StreamReader reader = new StreamReader(@"C:\Users\Codersbay\IdeaProjects\aufgabe-7-linq-natalyakirs\films.json");
            string json = reader.ReadToEnd();
            Console.WriteLine("\n1. Read file:  " + json);



            //2. Data deserialization

            // Deserializition JSON into a list of Film objects
            List<Film> movies = JsonConvert.DeserializeObject<List<Film>>(json);

            // Iteration through the list and output the names of the movies
            Console.WriteLine("2.Data deserialization: ");
            foreach (Film movie in movies)
            {
                
                Console.WriteLine("\nMovie Name: " + movie.title);
            }




            //3. Linq
            //Implement the FilmOperations.cs methods and test them in Program.cs
            // Create an instance of FilmOperations
            Console.WriteLine("\n3. Linq: ");
            FilmOperations filmOperations = new FilmOperations(movies);

            // Test the FilmOperations methods
            TestFilmOperations(filmOperations);

        }

        static void TestFilmOperations(FilmOperations filmOperations)
        {
            Console.WriteLine("\n3a.All Movies:");
            List<Film> allMovies = filmOperations.GetAllMovies();
            PrintMovieList(allMovies);


            string directorName = "Francis Ford Coppola";
            Console.WriteLine("\n3b.Movies Directed by " + directorName +":");
            Film[] byDirectorMovies = filmOperations.GetMoviesByDirector(directorName);
            PrintMovieArray(byDirectorMovies);


            int releaseYear = 1994;
            Console.WriteLine("\n3c.Movies Released in " + releaseYear + ":");
            Film[] byYearMovies = filmOperations.GetMoviesByYear(releaseYear);
            PrintMovieArray(byYearMovies);


            double minRating = 9.0;
            double maxRating = 9.3;
            Console.WriteLine("\n3d.Movies with ratings between " + minRating + " and " + maxRating + ":");
            Film[] ratedMovies = filmOperations.GetMoviesByRatingRange(minRating, maxRating);
            PrintMovieArray(ratedMovies);

            int numberOfFilms = 3;
            Console.WriteLine("\n3e.Top " + numberOfFilms + " Rated Movies:");
            Film[] topRatedMovies = filmOperations.GetMoviesByRatingSortedLimited(numberOfFilms);
            PrintMovieArray(topRatedMovies);
        }


        static void PrintMovieList(List<Film> movies)
        {
            foreach (Film movie in movies)
            {
                Console.WriteLine($"Title: {movie.title}, Director: {movie.director}, Rating: {movie.rating}");
            }
        }

        static void PrintMovieArray(Film[] movies)
        {
            foreach (Film movie in movies)
            {
                Console.WriteLine($"Title: {movie.title}, Director: {movie.director}, Rating: {movie.rating}");
            }

        }
    }


 }