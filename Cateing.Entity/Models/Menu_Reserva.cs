using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Menu_reserva")]
    public class Menu_Reserva
    {
        [Key]
        public Guid id_menu { get; set; }
        public Guid id_cliente { get; set; }
    }
}
