using Datos;
using Modelos;
using System.Collections.Generic;

namespace Negocios
{
    public class UsuarioNegocios
    {
        UsuarioDatos data = new UsuarioDatos();

        public Usuario getlogin(string email, string pwd)
        {
            Usuario user = data.loginUsuario(email, pwd);
            return user;
        }
        public List<Usuario> getUsersList()
        {
            return data.getAllUsersList();
        }
    }
}
