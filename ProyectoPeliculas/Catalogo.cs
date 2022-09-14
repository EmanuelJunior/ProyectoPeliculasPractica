using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPeliculas
{
    class Catalogo
    {
        static string[] showData = new string[7]
        {
            "\n Escriba el titulo de la peli: ",
            "\n ¿Cuánto dura la pelicula en minutos?: ",
            "\n ¿En qué momento salio?: ",
            "\n ¿Cuál es el lenguaje nativo en que se grabo?: ",
            "\n Escriba la casa productora: ",
            "\n ¿Quién es el director?: ",
            "\n ¿Cuál es el genero de la pelicula?: "
        };

        static string[] temporalData = new string[7];
        static List<IMovie> peliculas = new List<IMovie>();

        public void AddMovie()
        {
            for ( int i = 0; i <= 6; i++ )
            {
                Console.Write(showData[i]);
                temporalData[i] = Console.ReadLine();

                Console.Clear();
            }

            peliculas.Add(new IMovie {
                Titulo = temporalData[0],
                Duracion = temporalData[1],
                Age = temporalData[2],
                Idioma = temporalData[3],
                CasaProductora = temporalData[4],
                Director = temporalData[5],
                Genero = temporalData[6]
            });
        }

        public void AllMovies()
        {
            for (int i = 0; i <= peliculas.Count - 1; i++)
            {
                Console.WriteLine($"\nTitulo: {peliculas[i].Titulo}");
                Console.WriteLine($"Duración: {peliculas[i].Duracion}");
                Console.WriteLine($"Año salida: {peliculas[i].Age}");
                Console.WriteLine($"Idioma: {peliculas[i].Idioma}");
                Console.WriteLine($"Genero: {peliculas[i].Genero}");
                Console.WriteLine($"Casa Productora: {peliculas[i].CasaProductora}");
                Console.WriteLine($"Director: {peliculas[i].Director}");
            }
        }

        public void ShowMoviesForParameter( IEnumerable<IMovie> query )
        {
            foreach( IMovie pelicula in query )
            {
                Console.WriteLine($"\nTitulo: {pelicula.Titulo}");
                Console.WriteLine($"Duración: {pelicula.Duracion}");
                Console.WriteLine($"Año salida: {pelicula.Age}");
                Console.WriteLine($"Idioma: {pelicula.Idioma}");
                Console.WriteLine($"Genero: {pelicula.Genero}");
                Console.WriteLine($"Casa Productora: {pelicula.CasaProductora}");
                Console.WriteLine($"Director: {pelicula.Director}");
            }
        }

        public IEnumerable<IMovie> SearchMovieForName()
        {

            Console.Write("\n Escriba el nombre de la pelicula que desea buscar: ");
            string name = Console.ReadLine();

            var query = from pelicula in peliculas
                    where pelicula.Titulo.Trim().ToLower() == name.ToLower()
                    select pelicula;

            return query;
        }
    }
}
