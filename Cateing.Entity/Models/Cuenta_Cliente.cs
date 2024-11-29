using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Cuenta_cliente")]
    public class Cuenta_Cliente
    {
        [Key]
        public Guid id_cuenta_cliente { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public DateTime fecha_de_creacion { get; set; } = DateTime.Now;
    }
}
