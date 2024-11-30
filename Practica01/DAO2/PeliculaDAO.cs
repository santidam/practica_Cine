using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


using Npgsql;
using Practica01.models;

namespace Practica01.DAO2
{

    public class PeliculaDAO
    {
        private string _connectionString = "Host=localhost;Port=6060;Username=postgres;Password=santi;Database=cineDAO;";

        public PeliculaDAO() { }
        // Obtener todas las películas
        public List<Pelicula> ObtenerPeliculasToday()
        {
            var peliculas = new List<Pelicula>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT DISTINCT UPPER(titulo) FROM peliculas WHERE fecha_inicio <= CURRENT_DATE AND fecha_final >= CURRENT_DATE", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        peliculas.Add(new Pelicula
                        (
                            titulo: TimeSpanExtensions.Capitalize(reader.GetString(0)),
                            sala: new Sala(0, DateTime.Today)
                       
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
                using (var command = new NpgsqlCommand("SELECT id, titulo, idioma, horario, sala_id  FROM peliculas WHERE LOWER(titulo) = LOWER(@titu) AND fecha_inicio<= @fecha1 AND fecha_final >= @fecha2 ORDER BY horario", connection))
                {
                    command.Parameters.AddWithValue("titu",p.titulo);
                    command.Parameters.AddWithValue("fecha1",p.sala.fecha);
                    command.Parameters.AddWithValue("fecha2", p.sala.fecha);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pelicula.Add(new Pelicula
                            (
                                id: reader.GetInt32(0),
                                titulo: TimeSpanExtensions.Capitalize(reader.GetString(1)),
                                idioma: reader.GetString(2),
                                horario: reader.GetTimeSpan(3),
                                sala: new Sala(reader.GetInt32(4),p.sala.fecha)
                  
                            )
                            ); 
                        }
                    }
                }
            }
            return pelicula;
        }

        // Opcion 1 para peliculas filtradas FALTA MEJORAR!!  devuelve una list con todas las peliculas que cumplan el criterio
        // si embargo es encesario analizar la salida en el GUI
        //public List<Pelicula> ObtenerPeliculasFiltradas(List<string> generosSeleccionados, List<string> idiomasSeleccionados, DateTime? fechaSeleccionada)
        //{
        //    var peliculas = new List<Pelicula>();

        //    using (var connection = new NpgsqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        // Base de la consulta SQL
        //        var query = @"SELECT id, titulo, idioma, horario, sala_id 
        //              FROM peliculas 
        //              WHERE 1=1";  // 1=1 permite agregar condiciones dinámicamente

        //        // Lista para parámetros
        //        var parameters = new List<NpgsqlParameter>();

        //        // Agregar filtro de fecha
        //        if (fechaSeleccionada.HasValue)
        //        {
        //            query += " AND fecha_inicio <= @fecha AND fecha_final >= @fecha";
        //            parameters.Add(new NpgsqlParameter("@fecha", fechaSeleccionada.Value));
        //        }
        //        else
        //        {
        //            fechaSeleccionada = DateTime.Today;
        //            query += " AND fecha_inicio <= CURRENT_DATE AND fecha_final >= CURRENT_DATE";
        //        }

        //        // Agregar filtro de géneros si hay seleccionados
        //        if (generosSeleccionados != null && generosSeleccionados.Count > 0)
        //        {
        //            query += " AND (";
        //            for (int i = 0; i < generosSeleccionados.Count; i++)
        //            {
        //                if (i > 0) query += " OR ";
        //                query += $"@genero{i} = ANY(genero)";
        //                parameters.Add(new NpgsqlParameter($"@genero{i}", generosSeleccionados[i]));
        //            }
        //            query += ")";
        //        }

        //        // Agregar filtro de idiomas si hay seleccionados
        //        if (idiomasSeleccionados != null && idiomasSeleccionados.Count > 0)
        //        {
        //            query += " AND (";
        //            for (int i = 0; i < idiomasSeleccionados.Count; i++)
        //            {
        //                if (i > 0) query += " OR ";
        //                query += $"idioma = @idioma{i}";
        //                parameters.Add(new NpgsqlParameter($"@idioma{i}", idiomasSeleccionados[i]));
        //            }
        //            query += ")";
        //        }

        //        using (var command = new NpgsqlCommand(query, connection))
        //        {
        //            // Asignar todos los parámetros
        //            foreach (var parameter in parameters)
        //            {
        //                command.Parameters.Add(parameter);
        //            }

        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    peliculas.Add(new Pelicula
        //                    (
        //                        id: reader.GetInt32(0),
        //                        titulo: reader.GetString(1),
        //                        idioma: reader.GetString(2),
        //                        horario: reader.GetTimeSpan(3),
        //                        sala: new Sala(reader.GetInt32(4), fechaSeleccionada)
        //                    ));
        //                }
        //            }
        //        }
        //    }

        //    return peliculas;
        //}



        //Opcion 2 para peliculas filtradas

        //public List<Pelicula> ObtenerPeliculasFiltradas(Pelicula pelicula, DateTime fecha)
        //{
        //    var peliculas = new List<Pelicula>();

        //    using (var connection = new NpgsqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        // Construcción de la consulta SQL
        //        var query = @"SELECT id, titulo, idioma, horario, sala_id 
        //              FROM peliculas 
        //              WHERE fecha_inicio <= @fecha 
        //                AND fecha_final >= @fecha 
        //                AND genero && @generos";

        //        using (var command = new NpgsqlCommand(query, connection))
        //        {
        //            // Asignar la fecha al parámetro
        //            command.Parameters.AddWithValue("@fecha", fecha);

        //            // Asignar el array de géneros al parámetro
        //            command.Parameters.AddWithValue("@generos", pelicula.genero.ToArray());

        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    peliculas.Add(new Pelicula
        //                    (
        //                        id: reader.GetInt32(0),
        //                        titulo: reader.GetString(1),
        //                        idioma: reader.GetString(2),
        //                        horario: reader.GetTimeSpan(3),
        //                        sala: new Sala(reader.GetInt32(4))

        //                    ));
        //                }
        //            }
        //        }
        //    }

        //    return peliculas;
        //}



        //Opcion 3 Para peliculas filtradas solo 1 titulo por coincidencia !!!!!

        public List<Pelicula> ObtenerPeliculasFiltradas(List<string> generosSeleccionados, List<string> idiomasSeleccionados, DateTime? fechaSeleccionada)
        {
            var peliculas = new List<Pelicula>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                // Base de la consulta SQL
                var query = @"SELECT DISTINCT LOWER(titulo) 
                      FROM peliculas 
                      WHERE 1=1";  // 1=1 permite agregar condiciones dinámicamente

                // Lista para parámetros
                var parameters = new List<NpgsqlParameter>();

                // Agregar filtro de fecha
                if (fechaSeleccionada.HasValue)
                {
                    query += " AND fecha_inicio <= @fecha AND fecha_final >= @fecha";
                    parameters.Add(new NpgsqlParameter("@fecha", fechaSeleccionada.Value));
                }
                else
                {
                    fechaSeleccionada = DateTime.Today;
                    query += " AND fecha_inicio <= CURRENT_DATE AND fecha_final >= CURRENT_DATE";
                }

                // Agregar filtro de géneros si hay seleccionados
                if (generosSeleccionados != null && generosSeleccionados.Count > 0)
                {
                    query += " AND (";
                    for (int i = 0; i < generosSeleccionados.Count; i++)
                    {
                        if (i > 0) query += " OR ";
                        query += $"@genero{i} = ANY(genero)";
                        parameters.Add(new NpgsqlParameter($"@genero{i}", generosSeleccionados[i].ToLower()));
                    }
                    query += ")";
                }

                // Agregar filtro de idiomas si hay seleccionados
                if (idiomasSeleccionados != null && idiomasSeleccionados.Count > 0)
                {
                    query += " AND (";
                    for (int i = 0; i < idiomasSeleccionados.Count; i++)
                    {
                        if (i > 0) query += " OR ";
                        query += $"LOWER(idioma) = @idioma{i}";
                        parameters.Add(new NpgsqlParameter($"@idioma{i}", idiomasSeleccionados[i].ToLower()));
                    }
                    query += ")";
                }

                using (var command = new NpgsqlCommand(query, connection))
                {
                    // Asignar todos los parámetros
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            peliculas.Add(new Pelicula
                            (

                                titulo: TimeSpanExtensions.Capitalize(reader.GetString(0)) 

                            ));
                        }
                    }
                }
            }

            return peliculas;
        }
        //Insertar una nueva película
        public void InsertarPelicula(Pelicula pelicula)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(@"INSERT INTO peliculas (titulo, idioma, genero, fecha_inicio, fecha_final, horario, duracion, sala_id) 
                                                     VALUES (@titulo, @idioma, @genero, @fecha_inicio, @fecha_final, @horario, @duracion, @sala_id)", connection))
                {
                    command.Parameters.AddWithValue("@titulo", pelicula.titulo.ToLower());
                    command.Parameters.AddWithValue("@idioma", pelicula.idioma );
                    command.Parameters.AddWithValue("@genero", pelicula.generos.ToArray() );
                    command.Parameters.AddWithValue("@fecha_inicio", pelicula.fechaInicio);
                    command.Parameters.AddWithValue("@fecha_final", pelicula.fechaFin);
                    command.Parameters.AddWithValue("@horario", pelicula.horaInicio );
                    command.Parameters.AddWithValue("@duracion", pelicula.duracion);
                    command.Parameters.AddWithValue("@sala_id", pelicula.sala.numero);
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

        

        // Encontrar una sesion, sino devolver null, el controlador debe generar la logica para en caso de recibir un null pasar la informacion
        // de la Pelicula introducida anteriormente pero inicializando butacas en 0;
        public Pelicula GetPeliculaInSesion(Pelicula p)
        {
            Pelicula p1 = null;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open ();
                using (var command = new NpgsqlCommand("SELECT s.fecha, s.id_peliculas, p.titulo, p.horario, p.idioma ,s.butacas, s.id_sala, s.id as id_sesion FROM peliculas p JOIN sesion s on p.id = s.id_peliculas  WHERE p.id = @id_pelicula AND s.fecha = @fecha AND s.id_sala = @id_sala", connection))
                {
                    command.Parameters.AddWithValue("@id_pelicula",p.id);
                    command.Parameters.AddWithValue("@id_sala", p.sala.numero);
                    command.Parameters.AddWithValue("@fecha", p.sala.fecha);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p1 = new Pelicula(reader.GetInt32(1), TimeSpanExtensions.Capitalize(reader.GetString(2)) , reader.GetString(4), reader.GetTimeSpan(3), new Sala(reader.GetInt32(6),reader.GetInt32(7), reader.GetFieldValue<int[]>(5), reader.GetDateTime(0)));
                        }
                    }

                }

            }


            return p1;
        }

        // Añadir una sesion nueva 

        public void addSesion(Pelicula p)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
            connection.Open ();
                using (var command = new NpgsqlCommand("INSERT INTO SESION (fecha, id_peliculas, id_sala, butacas) VALUES (@fecha, @id_peliculas, @id_sala, @butacas)", connection))
                {
                    command.Parameters.AddWithValue("@fecha", p.sala.fecha);
                    command.Parameters.AddWithValue("@id_peliculas", p.id);
                    command.Parameters.AddWithValue("@id_sala", p.sala.numero);
                    command.Parameters.AddWithValue("@butacas", p.sala.disponibilidadButacas.ToArray());
                    command.ExecuteNonQuery();


                }
            }
        }

        // Actualizar una sesion existente
        public void ActualizarPelicula(Pelicula pelicula)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(@"UPDATE sesion SET butacas = @butacas WHERE id=@id", connection))
                {
                    command.Parameters.AddWithValue("@id", pelicula.sala.id_sesion);
                    command.Parameters.AddWithValue("@butacas", pelicula.sala.disponibilidadButacas.ToArray());
                    command.ExecuteNonQuery();
                }
            }
        }

    }

}
