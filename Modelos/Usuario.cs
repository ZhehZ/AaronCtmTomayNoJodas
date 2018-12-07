using System;

namespace Modelos
{
    public class Usuario
    {
        public int codigoUsuario { get; set; }
        public string email { get; set; }
        public string passwordU { get; set; }
        public int codigoTipoUsuario { get; set; }
        public string Dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int codigoEstado { get; set; }
    }
}
