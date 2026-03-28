using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisenoEscritorio
{
    /// <summary>
    /// Object that is used to contain an user's data from the database
    /// </summary>
    public class Usuario
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

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Nombre { get => nombre; set => nombre = value; }

        /// <summary>
        /// Description of the user
        /// </summary>
        public string Descripcion { get => descripcion; set => descripcion = value; }

        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get => email; set => email = value; }

        /// <summary>
        /// Password of the user's account
        /// </summary>
        public string Password { get => password; set => password = value; }

        /// <summary>
        /// Creation date of the user's account
        /// </summary>
        public string FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    }
}
