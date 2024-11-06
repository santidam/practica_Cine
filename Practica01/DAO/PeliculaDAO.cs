using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Npgsql;
using Practica01.model;

namespace Practica01.DAO
{

    public class PeliculaDAO
    {
        private string _connectionString = "Host=localhost;Port=6060;Username=postgres;Password=santi;Database=cineDAO;";

        public PeliculaDAO() { }
        // Obtener todas las películas
        public List<Pelicula> ObtenerPeliculasByDay()
        {
            var peliculas = new List<Pelicula>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT DISTINCT titulo FROM peliculas WHERE fecha_inicio <= CURRENT_DATE AND fecha_final >= CURRENT_DATE", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        peliculas.Add(new Pelicula
                        (
                            titulo: reader.GetString(0)
                       
                        )
                        
                        );
                    }
                }
            }
            return peliculas;
        }
        public List<Pelicula> ObtenerPeliculasByName(Pelicula p)
        {
            List<Pelicula> pelicula = new List<Pelicula>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT id, titulo, idioma, horario, sala_id, butacas titulo FROM peliculas WHERE titulo = @titu AND fecha_inicio<= CURRENT_DATE AND fecha_final >= CURRENT_DATE", connection))
                {
                    command.Parameters.AddWithValue("titu",p.titulo);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pelicula.Add(new Pelicula
                            (
                                id: reader.GetInt32(0),
                                titulo: reader.GetString(1),
                                idioma: reader.GetString(2),
                                horario: reader.GetTimeSpan(3),
                                sala: new Sala(reader.GetInt32(4)),
                                butacas: new List<bool>(reader.GetFieldValue<bool[]>(5))
                            )
                            ); 
                        }
                    }
                }
            }
            return pelicula;
        }

        // Insertar una nueva película
        public void InsertarPelicula(Pelicula pelicula)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(@"INSERT INTO peliculas (titulo, idioma, genero, fecha_inicio, fecha_final, horario, duracion, butacas, sala_id) 
                                                     VALUES (@titulo, @idioma, @genero, @fecha_inicio, @fecha_final, @horario, @duracion, @butacas, @sala_id)", connection))
                {
                    command.Parameters.AddWithValue("@titulo", pelicula.titulo);
                    command.Parameters.AddWithValue("@idioma", pelicula.idioma );
                    command.Parameters.AddWithValue("@genero", pelicula.genero.ToArray() );
                    command.Parameters.AddWithValue("@fecha_inicio", pelicula.fecha_inicio);
                    command.Parameters.AddWithValue("@fecha_final", pelicula.fecha_final);
                    command.Parameters.AddWithValue("@horario", pelicula.horario );
                    command.Parameters.AddWithValue("@duracion", pelicula.duracion);
                    command.Parameters.AddWithValue("@butacas", pelicula.butacas.ToArray() );
                    command.Parameters.AddWithValue("@sala_id", pelicula.sala.numero);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Actualizar una película existente
        public void ActualizarPelicula(Pelicula pelicula)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(@"UPDATE peliculas SET butacas = @butacas WHERE id=@id", connection))
                {
                    command.Parameters.AddWithValue("@id", pelicula.id);
                    command.Parameters.AddWithValue("@butacas", pelicula.butacas.ToArray());
                    command.ExecuteNonQuery();
                }
            }
        }

        // Eliminar una película
        public void EliminarPelicula(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("DELETE FROM peliculas WHERE id=@id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Pelicula> ObtenerPeliculasFiltradas(Pelicula pelicula, DateTime fecha)
        {
            var peliculas = new List<Pelicula>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                // Construcción de la consulta SQL
                var query = @"SELECT id, titulo, idioma, horario, butacas, sala_id 
                      FROM peliculas 
                      WHERE fecha_inicio <= @fecha 
                        AND fecha_final >= @fecha 
                        AND genero && @generos";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    // Asignar la fecha al parámetro
                    command.Parameters.AddWithValue("@fecha", fecha);

                    // Asignar el array de géneros al parámetro
                    command.Parameters.AddWithValue("@generos", pelicula.genero.ToArray());

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            peliculas.Add(new Pelicula
                            (
                                id: reader.GetInt32(0),
                                titulo: reader.GetString(1),
                                idioma: reader.GetString(2),
                                horario: reader.GetTimeSpan(3),
                                butacas: new List<bool>(reader.GetFieldValue<bool[]>(4)),
                                sala: new Sala ( reader.GetInt32(5))
                            
                            ));
                        }
                    }
                }
            }

            return peliculas;
        }

    }

}
