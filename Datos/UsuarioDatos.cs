using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDatos : Conexion
    {

        SqlConnection connection;

        public UsuarioDatos()
        {

            connection = new SqlConnection(conexionString);

        }

        public List<Usuario> getUsersList()
        {
            List<Usuario> usersList = null;
            connection.Open();
            var sqlStatement = "sp_getUsersList";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (reader.HasRows)
            {

                usersList = new List<Usuario>();

                while (reader.Read())
                {

                    Usuario user = new Usuario();
                    user.codigoUsuario = int.Parse(reader["codigoUsuario"].ToString());
                    user.codigoTipoUsuario = int.Parse(reader["codigoTipoUsuario"].ToString());
                    user.passwordU = reader["passwordUsuario"].ToString();
                    user.Dni = reader["Dni"].ToString();
                    user.nombre = reader["nombreUsuario"].ToString();
                    user.apellido = reader["apellidoPropietario"].ToString();
                    user.telefono = reader["telefono"].ToString();
                    user.email = reader["email"].ToString();
                    user.fechaIngreso = Convert.ToDateTime(reader["fechaIngreso"]);
                    user.codigoEstado = int.Parse(reader["codigoEstado"].ToString());

                    usersList.Add(user);
                }
            }
            connection.Close();
            return usersList;
        }

        public List<Usuario> getAllUsersList()
        {
            List<Usuario> usersList = null;
            connection.Open();
            var sqlStatement = "sp_getAllUsersList";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (reader.HasRows)
            {
                usersList = new List<Usuario>();
                while (reader.Read())
                {

                    Usuario user = new Usuario();
                    user.codigoUsuario = int.Parse(reader["codigoUsuario"].ToString());
                    user.codigoTipoUsuario = int.Parse(reader["codigoTipoUsuario"].ToString());
                    user.passwordU = reader["passwordUsuario"].ToString();
                    user.Dni = reader["Dni"].ToString();
                    user.nombre = reader["nombreUsuario"].ToString();
                    user.apellido = reader["apellidoPropietario"].ToString();
                    user.telefono = reader["telefono"].ToString();
                    user.email = reader["email"].ToString();
                    user.fechaIngreso = Convert.ToDateTime(reader["fechaIngreso"]);
                    user.codigoEstado = int.Parse(reader["codigoEstado"].ToString());

                    usersList.Add(user);
                }
            }

            connection.Close();
            return usersList;
        }


        public Usuario loginUsuario(string email, string pwd)
        {
            Usuario login = null;
            string query = "Sp_Login";
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@login", email);
            cmd.Parameters.AddWithValue("@pass", pwd);


            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                login = new Usuario();
                while (rd.Read())
                {
                    login.codigoUsuario = (Int32)rd["codigoUsuario"];
                    login.nombre = rd["nombre"].ToString();
                    login.passwordU = rd["passwordU"].ToString();
                    login.codigoEstado = (Int32)rd["codigoEstado"];

                }
            }

            connection.Close();

            return login;
        }
    }
}
