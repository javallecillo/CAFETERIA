using sisCafetería.capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisCafetería.capaLogica
{
    internal class UsuariosCL
    {
        private readonly UsuariosCD usuariosCD = new UsuariosCD();

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }

        public bool ValidarUsuario(string usuario, string contrasenia)
        {
            return usuariosCD.ValidarUsuario(usuario, contrasenia);
        }
    }
}
