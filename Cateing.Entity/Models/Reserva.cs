using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        [Key]
        public Guid id_reserva { get; set; }
        public Guid id_menu { get; set; }
        public Guid id_direccion { get; set; }
        public Guid id_cliente { get; set; }
        public Guid id_empresa { get; set; }
        public Guid id_info { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public decimal costo { get; set; }
        public decimal anticipo { get; set; }
        public bool completado { get; set; }
        public DateTime fecha_de_creacion { get; set; } = DateTime.Now;
    }
}
