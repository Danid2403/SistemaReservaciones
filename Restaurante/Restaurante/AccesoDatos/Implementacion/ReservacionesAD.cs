using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class ReservacionesAD: IReservacionesAD
    {
        private SREntities gobjContextoSR;

        public ReservacionesAD(SREntities _gobjContexto)
        {
            this.gobjContextoSR = _gobjContexto;
        }

        //llamar
        public List<recReservaciones_Result> recReservacion()
        {
            List<recReservaciones_Result> lobjRespuesta= new List<recReservaciones_Result> ();
            try
            {
                lobjRespuesta = gobjContextoSR.recReservaciones().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        //id

        public recReservacionesXId_Result recReservacionXId(int pId)
        {
            recReservacionesXId_Result objRespuesta= new recReservacionesXId_Result ();
            try
            {
                objRespuesta = gobjContextoSR.recReservacionesXId(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        //insert

        public bool insReservacion(Reservaciones pobjReservaciones)
        {
            bool objRespuesta= new bool ();
            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.insReservacion(pobjReservaciones.IdCliente, pobjReservaciones.IdMesa, pobjReservaciones.IdMenu, pobjReservaciones.Cantidad, pobjReservaciones.FechaReservacion);
                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta ;
        }

        //upd
        public bool updReservacion(Reservaciones pobjReservaciones)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.updReservacion(pobjReservaciones.NumeroReservacion,pobjReservaciones.IdCliente, pobjReservaciones.IdMesa, pobjReservaciones.IdMenu, pobjReservaciones.Cantidad, pobjReservaciones.FechaReservacion);

                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        //eliminar

        public bool delReservacion(Reservaciones pobjReservaciones)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.delReservacion(pobjReservaciones.NumeroReservacion);
                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
    }
}
