using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Platillo")]
    public class Platillo
    {
        [Key]
        public Guid id_platillo { get; set; }
        public Guid id_empresa { get; set; }
        public int costo { get; set; }
        public string descripcion { get; set; }
        public string link_imagen { get; set; }
    }
}
