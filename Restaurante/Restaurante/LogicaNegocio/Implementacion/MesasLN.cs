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
    public class MesasLN: IMesasLN
    {
        public static SREntities _gobjContextoSR= new SREntities();
        private readonly IMesasAD _gobjMesasAD= new MesasAD(_gobjContextoSR);
        

        //llamar mesa
        public List<recMesas_Result> recMesa()
        {
            List<recMesas_Result> lobjRespuesta= new List<recMesas_Result>();
            try
            {
                lobjRespuesta = _gobjMesasAD.recMesa();
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
            recMesasXId_Result objRespuesta= new recMesasXId_Result();
            try
            {
                objRespuesta = _gobjMesasAD.recMesaXID(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        //ins

        public bool insMesa(Mesas pobjMesa)
        {
            bool objRepuesta= new bool();
            try
            {
                objRepuesta = _gobjMesasAD.insMesa(pobjMesa);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objRepuesta;
        }

        //upd

        public bool updMesa(Mesas pobjMesa)
        {
            bool objRepuesta = new bool();
            try
            {
                objRepuesta = _gobjMesasAD.updMesa(pobjMesa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRepuesta;
        }

        //eliminar
        public bool delMesa(Mesas pobjMesa)
        {
            bool objRepuesta = new bool();
            try
            {
                objRepuesta = _gobjMesasAD.delMesa(pobjMesa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRepuesta;
        }
    }
}
