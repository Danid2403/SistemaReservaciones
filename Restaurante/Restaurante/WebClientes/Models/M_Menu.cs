using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClientes.Models
{
    public class M_Menu
    {

        [Required(ErrorMessage = "El ID del Plato es requerido")]
        [Display(Name = "ID. Plato")]
        public int IdMenu { get; set; }

        [Required(ErrorMessage = "La descripcion del plato es requerida")]
        [Display(Name = "Descripcion")]
        [MinLength(4, ErrorMessage = "El Nombre del plato debe contener 4 caracteres")]
        [MaxLength(15, ErrorMessage = "El Nombre del plato no debe contener mas de 15 caracteres")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "El Precio del Plato es requerido")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

    }
}