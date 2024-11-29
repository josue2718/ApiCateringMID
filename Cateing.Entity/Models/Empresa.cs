using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public Guid id_empresa { get; set; }
        public Guid id_propietario { get; set; }
        public string nombre { get; set; }
        public string link_facebook { get; set; }
        public string link_instagram { get; set; }
        public string link_logo { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public decimal? latitud { get; set; }
        public decimal? longitud { get; set; }
        public DateTime fecha_de_creacion { get; set; } = DateTime.Now;
    }
}
