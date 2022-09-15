using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPeliculas
{
    class Catalogo
    {
        static string[] temporalData = new string[7];
        static List<IMovie> peliculas = new List<IMovie>();

        public void OverridePelicula( int QIndex )
        {

            Console.Clear();
            Console.Write("\n ¿Quiere sobrescribir Titulo ({0}): ", peliculas[QIndex].Titulo);
            Console.Write(peliculas[QIndex].Titulo.Length);
            peliculas[QIndex].Titulo = Console.ReadLine();

            Console.Clear();
            Console.Write(" ¿Quiere sobrescribir Duracion ({0}): ", peliculas[QIndex].Duracion);
            peliculas[QIndex].Duracion = Console.ReadLine();

            Console.Clear();
            Console.Write(" ¿Quiere sobrescribir Año ({0}): ", peliculas[QIndex].Age);
            peliculas[QIndex].Age = Console.ReadLine();

            Console.Clear();
            Console.Write(" ¿Quiere sobrescribir Idioma ({0}): ", peliculas[QIndex].Idioma);
            peliculas[QIndex].Idioma = Console.ReadLine();

            Console.Clear();
            Console.Write(" ¿Quiere sobrescribir CasaProductora ({0}): ", peliculas[QIndex].CasaProductora);
            peliculas[QIndex].CasaProductora = Console.ReadLine();

            Console.Clear();
            Console.Write(" ¿Quiere sobrescribir Director ({0}): ", peliculas[QIndex].Director);
            peliculas[QIndex].Director = Console.ReadLine();

            Console.Clear();
            Console.Write("¿Quiere sobrescribir Genero ({0}): ", peliculas[QIndex].Genero);
            peliculas[QIndex].Genero = Console.ReadLine();

        }

        public void Controller()
        {
            int option;
            bool trueOrFalse = true;

            while( trueOrFalse )
            {
                Console.Clear();
                Console.WriteLine(UI.Menu);
                Console.Write("\n Eliga una opción: ");

                try { option = int.Parse(Console.ReadLine()); }
                catch (Exception e) {
                    Console.Clear();
                    Console.WriteLine($"\n Se ha generado un error de tipo: {e.GetType()}, \n El mensaje de error es: {e.Message}");
                    Console.Write("\n Presiona cualquier letra para continuar... ");
                    Console.ReadKey();
                    continue; 
                }

                Console.Clear();

                switch (option)
                {
                    case 1:
                        AddMovie();
                        break;
                    case 2:
                        AllMovies();
                        break;
                    case 3:
                        ShowMoviesForParameter(SearchMovieForName());
                        break;
                    case 4:
                        ShowMoviesForParameter(SearchMovieForDirector());
                        break;
                    case 5:
                        ShowMoviesForParameter(SearchMovieForGener());
                        break;
                    case 0:
                        trueOrFalse = false;
                        break;
                    default:
                        break;
                }
            }

        }

        public void AddMovie()
        {
            string temporalTitle;
            IEnumerable<IMovie> query;
            int queryIndex = -1;

            for ( int i = 0; i <= 6; i++ )
            {
                Console.Clear();
                Console.Write(UI.ShowData[i]);

                if (peliculas.Count() >= 1)
                {
                    temporalTitle = Console.ReadLine();

                    query = QueryMovie(temporalTitle);

                    queryIndex = peliculas.FindIndex(pelicula => pelicula.Titulo.Trim().ToLower() == temporalTitle.ToLower());

                    if (query.Count() == 1)
                    {
                        Console.Write("\nHay coincidencias esta seguro que quiere sobreescribir la pelicula:\n");
                        OverridePelicula(queryIndex);
                    }

                    break;
                }

                temporalData[i] = Console.ReadLine();
            }

            if ( queryIndex == -1 ) 
                peliculas.Add(new IMovie {
                    Titulo = temporalData[0],
                    Duracion = temporalData[1],
                    Age = temporalData[2],
                    Idioma = temporalData[3],
                    CasaProductora = temporalData[4],
                    Director = temporalData[5],
                    Genero = temporalData[6]
                });

            Console.Write("\n Presiona cualquier letra para continuar... ");
            Console.ReadKey();
        }

        public void AllMovies()
        {
            foreach( IMovie pelicula in peliculas )
            {
                Console.WriteLine($"\n Titulo: {pelicula.Titulo}");
                Console.WriteLine($" Duración: {pelicula.Duracion}");
                Console.WriteLine($" Año salida: {pelicula.Age}");
                Console.WriteLine($" Idioma: {pelicula.Idioma}");
                Console.WriteLine($" Genero: {pelicula.Genero}");
                Console.WriteLine($" Casa Productora: {pelicula.CasaProductora}");
                Console.WriteLine($" Director: {pelicula.Director}");
            }

            Console.Write("\n Presiona cualquier letra para continuar... ");
            Console.ReadKey();
        }

        public void ShowMoviesForParameter( IEnumerable<IMovie> query )
        {
            if (query.Count() == 0) Console.WriteLine("\n====== no se ha logrado resolver la busqueda ======".ToUpper());

            foreach( IMovie pelicula in query )
            {
                Console.WriteLine($"\n Titulo: {pelicula.Titulo}");
                Console.WriteLine($" Duración: {pelicula.Duracion}");
                Console.WriteLine($" Año salida: {pelicula.Age}");
                Console.WriteLine($" Idioma: {pelicula.Idioma}");
                Console.WriteLine($" Genero: {pelicula.Genero}");
                Console.WriteLine($" Casa Productora: {pelicula.CasaProductora}");
                Console.WriteLine($" Director: {pelicula.Director}");
            }

            Console.Write("\n Presiona cualquier letra para continuar... ");
            Console.ReadKey();
        }

        public IEnumerable<IMovie> SearchMovieForName()
        {
            Console.Write("\n Escriba el nombre de la pelicula que desea buscar: ");
            string name = Console.ReadLine();

            return QueryMovie(name);
        }

        public IEnumerable<IMovie> SearchMovieForGener()
        {

            Console.Write("\n Escriba el genero de pelicula que desea buscar: ");
            string gener = Console.ReadLine();

            return QueryMovie(gener, "Genero");
        }

        public IEnumerable<IMovie> SearchMovieForDirector()
        {
            Console.Write("\n Escriba el director de la pelicula que desea buscar: ");
            string director = Console.ReadLine();

            return QueryMovie(director, "Director");
        }

        public IEnumerable<IMovie> QueryMovie( string q, string parameterQuery = "" )
        {

            var query = from pelicula in peliculas
                        where (
                            parameterQuery == "Director" 
                            ? pelicula.Director.Trim().ToLower() 
                            : parameterQuery == "Genero" 
                                ? pelicula.Genero.Trim().ToLower() 
                                : pelicula.Titulo.Trim().ToLower()) 
                            == q.ToLower()
                        select pelicula;

            return query;
        }
    }
}
