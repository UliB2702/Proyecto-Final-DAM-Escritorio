using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisenoEscritorio
{
    internal class Usuario
    {
        private string nombre;
        private string descripcion;
        private string email;
        private string password;
        private string fechaCreacion;

        public Usuario()
        {

        }
        public Usuario(string nombre, string descripcion, string email, string password, string fechaCreacion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Email = email;
            this.Password = password;
            this.FechaCreacion = fechaCreacion;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    }
}
