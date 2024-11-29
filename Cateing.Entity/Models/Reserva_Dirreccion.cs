using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Reserva_direccion")]
    public class Reserva_Dirreccions
    {
        [Key]
        public Guid id_direccion { get; set; }
        public Guid id_cliente { get; set; }
        public decimal? latitud { get; set; }
        public decimal? longitud { get; set; }
        public string calle { get; set; }
        public string nombre_lugar { get; set; }
        public string num_casa { get; set; }
        public string referencias { get; set; }
    }
}
