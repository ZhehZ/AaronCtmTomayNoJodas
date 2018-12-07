using System.Configuration;

namespace Datos
{
    public class Conexion
    {
        protected string conexionString { get; set; }

        public Conexion()
        {
            conexionString = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        }
    }
}

