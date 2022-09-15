using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoPeliculas
{
    class Program
    {
        static void Main()
        {
            Catalogo catalogo = new Catalogo();
            catalogo.AddMovie();
            catalogo.AddMovie();

            catalogo.ShowMoviesForParameter( catalogo.SearchMovieForGener() );
            //IEnumerable<IMovie> query = catalogo.SearchMovieForName();
            //catalogo.ShowMoviesForParameter(query);

            //String n = "Emanuel Garces Zuluaga";
            //var search = n.Trim().ToLower().StartsWith("emanuel");
            //Console.WriteLine(search);
        }
    }
}
