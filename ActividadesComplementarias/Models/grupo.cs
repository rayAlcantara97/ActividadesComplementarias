using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ActividadesComplementarias.Models
{
    public class grupo
    {
          [Key]
            public int idgrupo { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 1, ErrorMessage = "El nombre del grupo debe tener de 1 a 45 caracteres")]
            public string nombre_grupo { get; set; }

            public int capacidad { get; set; }

            
            public DateTime hora_inicial { get; set; }

            public DateTime hora_final { get; set; }

            public int instructor_idinstructor { get; set; }

            public int area_idarea { get; set; }
         
            public int actividad_idactividad { get; set; }

            public int periodo_idperiodo { get; set; }




}
}
