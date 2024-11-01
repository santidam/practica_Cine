using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Npgsql;
using Practica01.model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Practica01.DAO
{


    public class UsuarioDAO
    {
        private string _connectionString = "Host=localhost;Port=6060;Username=postgres;Password=santi;Database=cineDAO;";

        public ObservableCollection<Usuario> ObtenerUsuarios()
        {
            var nombre = "";
            var email = "";
            var password = "";
            var admin = false;
            var usuarios = new ObservableCollection<Usuario>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT email, nombre, password, admin FROM usuarios", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        
                    {
                        usuarios.Add(new Usuario
                        (
                            
                            email = reader.GetString(0),
                            nombre = reader.GetString(1),
                            password = reader.GetString(2),
                            admin = reader.GetBoolean(3)

                        ));
                        Console.WriteLine(email);

                    }
                }
            }
            
            return usuarios;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("INSERT INTO usuarios (nombre, email, password,admin) VALUES (@nombre, @correo, @password,@admin)", connection))
                {
                    command.Parameters.AddWithValue("nombre", usuario.nombre);
                    command.Parameters.AddWithValue("correo", usuario.email);
                    command.Parameters.AddWithValue("password", usuario.password);
                    command.Parameters.AddWithValue("admin", usuario.admin);
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
