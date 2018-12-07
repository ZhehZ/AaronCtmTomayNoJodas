using System;
using Negocios;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Modelos;

namespace Gestimonio.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        UsuarioNegocios userBusiness = new UsuarioNegocios();

        [HttpPost]
        public Usuario getLogin(Usuario usuario)
        {
            var user = userBusiness.getlogin(usuario.email, usuario.passwordU);
            return user;
        }

        [HttpGet]
        public List<Usuario> getAllUsers()
        {
            var list = userBusiness.getUsersList();
            return list;
        }

        [HttpGet]
        public Usuario getUserById(int id)
        {
            var list = userBusiness.getUsersList();
            Usuario user = list.FirstOrDefault(x => x.codigoUsuario == id);
            return user;
        }
    }
}
