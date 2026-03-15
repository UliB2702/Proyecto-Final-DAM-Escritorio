using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisenoEscritorio
{
    internal class Post
    {
        private int id;
        private string usuario;
        private string texto;
        private string fechaPublicacion;
        private int idCategoria;

        public Post()
        {

        }
        public Post(int id, string usuario, string texto, string fechaPublicacion, int categoria)
        {
            this.id = id;
            this.usuario = usuario;
            this.texto = texto;
            this.fechaPublicacion = fechaPublicacion;
            this.idCategoria = categoria;
        }

        public int Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Texto { get => texto; set => texto = value; }
        public string FechaPublicacion { get => fechaPublicacion; set => fechaPublicacion = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
    }
}
