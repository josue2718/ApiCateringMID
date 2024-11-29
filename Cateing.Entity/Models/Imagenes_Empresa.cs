using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Imagenes_empresa")]
    public class Imagenes_Empresa
    {
        [Key]
        public Guid id_imagen { get; set; }
        public Guid id_empresa { get; set; }
        public string nombre { get; set; }
        public string link_imagen { get; set; }
        public DateTime fecha_de_creacion { get; set; } = DateTime.Now;
    }
}
