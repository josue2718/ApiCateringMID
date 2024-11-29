using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Menu_bebida_reserva")]
    public class Menu_Bebida_Reserva
    {
        [Key, Column(Order = 0)]
        public Guid id_menu { get; set; }
        [Key, Column(Order = 1)]
        public Guid id_menu_bebida { get; set; }
    }
}
