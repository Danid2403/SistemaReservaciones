using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IReservacionesAD
    {
        List<recReservaciones_Result> recReservacion();
        recReservacionesXId_Result recReservacionXId(int pId);
        bool insReservacion(Reservaciones pobjReservaciones);
        bool updReservacion(Reservaciones pobjReservaciones);
        bool delReservacion(Reservaciones pobjReservaciones);



    }
}
