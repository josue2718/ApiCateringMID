using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public Guid id_cliente { get; set; }
        public Guid id_cuenta { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public decimal? latitud { get; set; }
        public decimal? longitud { get; set; }
        public string rfc { get; set; }
        public DateTime fecha_de_creacion { get; set; } = DateTime.Now;
    }
}
