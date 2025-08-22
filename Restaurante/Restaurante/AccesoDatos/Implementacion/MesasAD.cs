using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class MesasAD: IMesasAD
    {
        private SREntities gobjContextoSR;

        public MesasAD(SREntities _gobjContextoSR)
        {
            this.gobjContextoSR = _gobjContextoSR;
        }
        


        //llmar mesas
        public List<recMesas_Result> recMesa()
        {
            List<recMesas_Result> lobjRespuesta=new List<recMesas_Result>();
            try
            {
                lobjRespuesta = gobjContextoSR.recMesas().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }
        //id

        public recMesasXId_Result recMesaXID(int pId)
        {
            recMesasXId_Result objRespuesta = new recMesasXId_Result();
            try
            {
                objRespuesta = gobjContextoSR.recMesasXId(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        //inser

        public bool insMesa(Mesas pobjMesas)
        {
            bool objRespuesta= new bool();

            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.insMesa(pobjMesas.NumeroMesa, pobjMesas.DescripcionMesa);
                if(intVal==1)
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

        //upd

        public bool updMesa(Mesas pobjMesas)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.updMesa(pobjMesas.IdMesa,pobjMesas.NumeroMesa, pobjMesas.DescripcionMesa);
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

        public bool delMesa(Mesas pobjMesas)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.delMesa(pobjMesas.IdMesa);
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
