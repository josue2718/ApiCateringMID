using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Calificacion")]
    public class Calificacion
    {
        [Key]
        public Guid id_calificacion { get; set; }
        public Guid id_empresa { get; set; }
        public Guid id_cliente { get; set; }
        public string comentario { get; set; }
        public int estrellas { get; set; }
        public string link_imagen { get; set; }
        public DateTime fecha_creacion { get; set; } = DateTime.Now;
    }
}
