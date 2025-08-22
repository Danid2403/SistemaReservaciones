using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClientes.Models
{
    public class M_Clientes
    {
        [Required(ErrorMessage ="El ID del Cliente es requerido")]
        [Display(Name ="ID. Cliente")]
        public int IdCliente { get; set; }


        [Required(ErrorMessage = "El nombre del cliente es requerido")]
        [Display(Name = "Nombre del Cliente")]
        [MinLength(5, ErrorMessage ="El nombre del cliente debe contener 5 o mas caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido del cliente es requerido")]
        [Display(Name = "Apellido del Cliente")]
        [MinLength(5, ErrorMessage = "El apellido del cliente debe contener 5 o mas caracteres")]
        public string Apellidos { get; set; }


        [Required(ErrorMessage = "El numero de telefono del cliente es requerido")]
        [Display(Name = "Telefono del Cliente")]
        [MinLength(8, ErrorMessage = "El telefono del cliente debe contener 8 caracteres")]
        [MaxLength(8, ErrorMessage = "El telefono del cliente no debe contener mas de 8 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Correo Electronico del cliente es requerido")]
        [Display(Name = "Correo Electronico ")]
        [MinLength(10, ErrorMessage = "El Correo Electronico del cliente debe contener 10 o mas caracteres")]
        public string CorreoElectronico { get; set; }
    }
}
