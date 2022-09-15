using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPeliculas
{
    class UI
    {
        string[] yesNo = new string[4] { "yes", "no", "y", "n" };

        public static string Menu =
            "\n **********************************\n" +
            " ***** Catálogo de Películas ******\n" +
            " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
            " Lista de Opciones\n" +
            " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
            " 1. Agregar  nueva película\n" +
            " 2. Listar todas las películas\n" +
            " 3. Buscar película por nombre\n" +
            " 4. Listar películas por director\n" +
            " 5. Listar películas por género\n" +
            " 0. Salir del Programa\n";

        public static string[] ShowData = new string[7]
{
            "\n Escriba el titulo de la peli: ",
            "\n ¿Cuánto dura la pelicula en minutos?: ",
            "\n ¿En qué momento salio?: ",
            "\n ¿Cuál es el lenguaje nativo en que se grabo?: ",
            "\n Escriba la casa productora: ",
            "\n ¿Quién es el director?: ",
            "\n ¿Cuál es el genero de la pelicula?: "
        };

        public static string[] OverrideData = new string[7]
        {
            "\n el Titulo ({1}): ",
            "\n la Duración ({1}): ",
            "\n el Año salida ({1}): ",
            "\n el Idioma ({1}): ",
            "\n la Casa Productora ({1}): ",
            "\n el Director ({1}): ",
            "\n el Genero ({1}): ",
        };
    }
}
