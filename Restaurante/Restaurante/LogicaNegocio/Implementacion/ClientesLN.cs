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
    public class ClientesLN: IClientesLN
    {
        //CONEXION ACCESODATOS
        public static SREntities _gobjContextoSR=new SREntities();

        private readonly IClientesAD _gobjClienteAD= new ClientesAD(_gobjContextoSR);

        //LLAMAR ACCESODATOS
        public List<recClientes_Result> recCliente()
        {
            List<recClientes_Result> lobjRespuesta = new List<recClientes_Result>();
            try
            {
                lobjRespuesta = _gobjClienteAD.recCliente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        public recClientesXId_Result recClienteXId(int pId)
        {
            recClientesXId_Result objRespuesta=new recClientesXId_Result();
            try
            {
                objRespuesta = _gobjClienteAD.recClienteXId(pId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool insCliente(Clientes pobjCliente)
        {
            bool objRespuesta= new bool();
            try
            {
                objRespuesta = _gobjClienteAD.insCliente(pobjCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool updCliente(Clientes pobjCliente)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = _gobjClienteAD.updCliente(pobjCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool delCliente(Clientes pobjCliente)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = _gobjClienteAD.delCliente(pobjCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
    }
    
    
}
