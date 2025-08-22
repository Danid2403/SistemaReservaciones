using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClientes.Models
{
    public class M_Mesas
    {

        [Required(ErrorMessage = "El ID de la mesa es requerido")]
        [Display(Name = "ID. Mesa")]
        public int IdMesa { get; set; }

        [Required(ErrorMessage = "El Numero de mesa es requerido")]
        [Display(Name = "Numero de Mesa")]
        public int NumeroMesa { get; set; }

        [Required(ErrorMessage = "La descripcion de la mesa es requerida")]
        [Display(Name = "Mesa")]
        [MinLength(4, ErrorMessage = "El Nombre de la mesa debe contener 4 caracteres")]
        [MaxLength(15, ErrorMessage = "El Nombre de la mesa no debe contener mas de 15 caracteres")]
        public string DescripcionMesa { get; set; }
    }
}