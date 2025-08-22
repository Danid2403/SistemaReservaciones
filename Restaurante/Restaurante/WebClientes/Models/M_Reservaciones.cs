using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClientes.Models
{
    public class M_Reservaciones
    {

        [Required(ErrorMessage ="El numero de Reservacion es requerido")]
        [Display(Name ="Numero de Reservacion")]
        public int NumeroReservacion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un cliente válido.")]
        [Display(Name ="ID. Cliente")]
        public int IdCliente { get; set; }



        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una mesa válida.")]
        [Display(Name = "Numero de mesa")]
        public int IdMesa { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un menú válido.")]
        [Display(Name = "ID. Menu")]
        public int IdMenu { get; set; }


        [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100.")]
        [Display(Name = "Cantidad Personas")]
        public int Cantidad { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        [Display(Name ="Fecha de Reservacion")]
        [Required(ErrorMessage ="La fecha de reservacion ")]
        public DateTime FechaReservacion { get; set; }
    }
}