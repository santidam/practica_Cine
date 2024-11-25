using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using Practica01.models;


namespace Practica01.DAO2
{

    public class UsuarioDAO
    {
        private string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=cineDAO;";

        public List<Usuario> ObtenerUsuarios()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT email, nombre, password, admin FROM usuarios", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        String nombre;
                        String email;
                        String password;
                        bool admin;
                        usuarios.Add(new Usuario
                        (
                            email = reader.GetString(0),
                            nombre = reader.GetString(1),
                            password = reader.GetString(2),
                            admin = reader.GetBoolean(3)
                        ));
                    }
                }
            }
            return usuarios;
        }
        public Usuario findUser(String email)
        {
            Usuario u = null;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT email, nombre, password, admin FROM usuarios WHERE email = @correo", connection))
                {
                    command.Parameters.AddWithValue("correo", email);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            u = new Usuario(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));
                        }
                    }

                }
            }
            return u;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("INSERT INTO usuarios (nombre, email, password) VALUES (@nombre, @correo, @password)", connection))
                {
                    command.Parameters.AddWithValue("nombre", usuario.nombre);
                    command.Parameters.AddWithValue("correo", usuario.email);
                    command.Parameters.AddWithValue("password", usuario.password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("UPDATE usuarios SET nombre = @nombre, email = @correo, password = @password WHERE email = @correo", connection))
                {
                    command.Parameters.AddWithValue("nombre", usuario.nombre);
                    command.Parameters.AddWithValue("correo", usuario.email);
                    command.Parameters.AddWithValue("password", usuario.password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarUsuario(string email)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("DELETE FROM usuarios WHERE email = @correo", connection))
                {
                    command.Parameters.AddWithValue("correo", email);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
