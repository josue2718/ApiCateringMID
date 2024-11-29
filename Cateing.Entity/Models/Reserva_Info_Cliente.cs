using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Reserva_info_cliente")]
    public class Reserva_Info_Cliente
    {
        [Key]
        public Guid id_info { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_telefono { get; set; }
        public string segundo_telefono { get; set; }
    }
}
