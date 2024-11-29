using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cateing.Entity.Models
{
    [Table("Propietario_empresa")]
    public class Propietario_Empresa
    {
        [Key]
        public Guid id_propietario { get; set; }
        public Guid id_cuenta { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string rfc { get; set; }
        public string clave { get; set; }
        public string link_imagen { get; set; }
        public DateTime fecha_de_creacion { get; set; } = DateTime.Now;
    }
}
