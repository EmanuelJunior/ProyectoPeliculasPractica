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
            IEnumerable<IMovie> a = catalogo.SearchMovieForName();
            catalogo.ShowMoviesForParameter(a);
        }
    }
}
