using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.models
{
    public class PelisList
    {
        public ObservableCollection<Pelicula> Peliculas { get; set; }
        public PelisList()
        {
            Peliculas = new ObservableCollection<Pelicula>()
            {
                new Pelicula("Wild Robot", 3, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 127, "18:40", new string[] { "Animacion", "Fantasía", "Aventura" }),
                new Pelicula("Gladiator", 1, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 227, "20:40", new string[] { "Historica", "Fantasía", "Sangrienta" }),
                new Pelicula("Vaiana 2", 2, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 116, "17:40", new string[] { "Animacion", "Fantasía", "Aventura" }),
                new Pelicula("Smile 2", 3, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 128, "21:40", new string[] { "Terror", "Psicológica" }),
                new Pelicula("El Mago de oz", 1, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 203, "23:40", new string[] { "Fantasía", "Aventura" }),
                new Pelicula("Wild Robot", 2, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 127, "20:00", new string[] { "Animacion", "Fantasía", "Aventura" }),
                new Pelicula("Wild Robot", 3, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 127, "10:30", new string[] { "Animacion", "Fantasía", "Aventura" }),
                new Pelicula("Wild Robot", 3, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 127, "17:40", new string[] { "Animacion", "Fantasía", "Aventura" }),
                new Pelicula("Wild Robot", 3, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 127, "12:40", new string[] { "Animacion", "Fantasía", "Aventura" }),
                new Pelicula("Wild Robot", 3, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 127, "11:40", new string[] { "Animacion", "Fantasía", "Aventura" }),
                new Pelicula("Wild Robot", 3, "Castellano", DateTime.ParseExact("15/01/2025", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2025", "dd/MM/yyyy", CultureInfo.InvariantCulture), 127, "23:40", new string[] { "Animacion", "Fantasía", "Aventura" }),
                new Pelicula("Wild Robot", 3, "Castellano", DateTime.ParseExact("15/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("23/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), 127, "18:40", new string[] { "Animacion", "Fantasía", "Aventura" }),
            };
            
        }

        public ObservableCollection<Pelicula> OrdenarPeliculasPorHoraInicio()
        {
            // Ordenar las peliculas por Duracion
            var peliculasOrdenadas = Peliculas.OrderBy(p => p.horaInicio).ToList();
            Peliculas.Clear();
            foreach (var pelicula in peliculasOrdenadas)
            {
                Peliculas.Add(pelicula);
            }
            return Peliculas;
        }
    }
}
