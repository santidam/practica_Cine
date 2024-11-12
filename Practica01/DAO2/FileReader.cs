using Practica01.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practica01.DAO2
{
    public class FileReader
    {
        public FileReader() {
        }
        public ObservableCollection<Pelicula> FileRead(string filePath) 
        {
            ObservableCollection<Pelicula> movies = new ObservableCollection<Pelicula>();
            foreach (var line in File.ReadLines(filePath))
            {
                // Partiu la línia llegida pel delimitador ";"
                string[] parts = line.Split(';');
                // Jo no posaré espais. So els poseu treieu els espais a cada part
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Trim();
                }
                // Agafeu les dades en variables convertint format si cal.
                string titol = parts[0];
                int sala = int.Parse(parts[1]);
                string idioma = parts[2];
                DateTime startDate = DateTime.ParseExact(parts[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(parts[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan startTime = TimeSpan.ParseExact(parts[5], "hh\\:mm", CultureInfo.InvariantCulture);
                int duration = int.Parse(parts[6]);
                // Pot haver-hi diversos gèneres, jo els deso en una llista.
                List<string> genres = new List<string>();
                for (int i = 7; i < parts.Length; i++)
                {
                    if (!string.IsNullOrEmpty(parts[i])) // Si el gènere es buit, no faig res.
                    {
                        genres.Add(parts[i]);
                    }
                }
                // Instanciar una Película amb les dades i el seu constructor
                Pelicula movie = new Pelicula(titol, idioma, genres, startDate, endDate, startTime, duration, new Sala(sala));
                // Afegir-lo a la Observable collection.
                movies.Add(movie);

            }
            return movies;   
        }
    }
}
