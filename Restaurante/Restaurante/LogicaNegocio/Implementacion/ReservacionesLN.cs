using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion
{
    public class ReservacionesLN: IReservacionesLN
    {
        public static SREntities _gobjContextoSR=new SREntities();
        private readonly IReservacionesAD _gobjReservacionAD= new ReservacionesAD(_gobjContextoSR);


        //llamar

        public List<recReservaciones_Result> recReservacion()
        {
            List<recReservaciones_Result> lobjRespuesta= new List<recReservaciones_Result> ();
            try
            {
                lobjRespuesta = _gobjReservacionAD.recReservacion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        //id

        public recReservacionesXId_Result recReservacionXID(int pId)
        {
            recReservacionesXId_Result objRespuesta= new recReservacionesXId_Result();
            try
            {
                objRespuesta = _gobjReservacionAD.recReservacionXId(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        //ins

        public bool insReservacion(Reservaciones pobjReservacion)
        {
            bool objRespuesta= new bool ();
            try
            {
                objRespuesta = _gobjReservacionAD.insReservacion(pobjReservacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (objRespuesta);
        }

        // upd
        public bool updReservacion(Reservaciones pobjReservacion)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = _gobjReservacionAD.updReservacion(pobjReservacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (objRespuesta);
        }

        //del
        public bool delReservacion(Reservaciones pobjReservacion)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = _gobjReservacionAD.delReservacion(pobjReservacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (objRespuesta);
        }

    }
}
