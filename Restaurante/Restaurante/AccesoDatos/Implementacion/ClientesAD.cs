using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class ClientesAD: IClientesAD
    {
        private SREntities gobjContextoSR;

        public ClientesAD(SREntities _gobContextoSR)
        {
            this.gobjContextoSR = _gobContextoSR;

        }

        public List<recClientes_Result> recCliente()
        {
            List<recClientes_Result> lobjRespuesta= new List<recClientes_Result>();
            try
            {
                lobjRespuesta = gobjContextoSR.recClientes().ToList();

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return lobjRespuesta;
        }

        //id

        public recClientesXId_Result recClienteXId(int pId)
        {
            recClientesXId_Result objRespuesta= new recClientesXId_Result();
            try
            {
                objRespuesta = gobjContextoSR.recClientesXId(pId).Single();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        //inser

        public bool insCliente(Clientes pobjCliente)
        {
            bool objRespuesta= new bool();

            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.insCliente(pobjCliente.Nombre, pobjCliente.Apellidos, pobjCliente.Telefono, pobjCliente.CorreoElectronico);
                if(intVal==1)
                {
                    objRespuesta = true;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objRespuesta ;
        }

        //update

        public bool updCliente(Clientes pobjCliente)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.updCliente(pobjCliente.IdCliente,pobjCliente.Nombre ,pobjCliente.Apellidos, pobjCliente.Telefono, pobjCliente.CorreoElectronico);
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

        //delete
        public bool delCliente(Clientes pobjCliente)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.delCliente(pobjCliente.IdCliente);
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
