using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Bebida")]
    public class Bebida
    {
        [Key]
        public Guid id_bebida { get; set; }
        public Guid id_empresa { get; set; }
        public int costo { get; set; }
        public string descripcion { get; set; }
        public string link_imagen { get; set; }
    }
}
