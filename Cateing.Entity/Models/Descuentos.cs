using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Descuentos")]

    public class Descuentos
    {
        [Key]
        public Guid id_descuento { get; set; }
        public Guid id_empresa { get; set; }
        public string descripcion { get; set; }
        public string link_imagen { get; set; }
        public int cantidad { get; set; }
        public int porcentaje { get; set; }
        public DateTime fecha_inicio { get; set; }
        public TimeSpan hora_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public TimeSpan hora_fin { get; set; }
        public DateTime fecha_creacion { get; set; } = DateTime.Now;
    }
}
