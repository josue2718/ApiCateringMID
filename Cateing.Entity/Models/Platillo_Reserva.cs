using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Platillo_reserva")]
    public class Platillo_Reserva
    {
        [Key]
        public Guid id_menu_platillo { get; set; }
        public Guid id_platillo { get; set; }
        public int cantidad { get; set; }
    }
}
