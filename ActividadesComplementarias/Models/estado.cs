using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ActividadesComplementarias.Models
{
    public class estado
    {
        [Key]
        public int idestado { get; set; }

        [Required]
        [StringLength(50, MinimumLength =1, ErrorMessage = "El nombre del estado debe tener de 1 a 45 caracteres")]
        public string nombre_estado { get; set;}

    }
}
