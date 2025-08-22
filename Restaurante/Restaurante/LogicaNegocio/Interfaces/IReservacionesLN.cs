using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IReservacionesLN
    {
        List<recReservaciones_Result> recReservacion();
        recReservacionesXId_Result recReservacionXID(int pId);
        bool insReservacion(Reservaciones pobjReservacion);
        bool updReservacion(Reservaciones pobjReservacion);
        bool delReservacion(Reservaciones pobjReservacion);
    }
}
