using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Bebida_reserva")]
    public class Bebida_Reserva
    {
        public Guid id_menu_bebida { get; set; }
        public Guid id_bebida { get; set; }
        public int cantidad { get; set; }
    }
}
