using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class MenuAD: IMenuAD
    {
        private SREntities gobjContextoSR;

        public MenuAD(SREntities _gobjContextoSR)
        {
            this.gobjContextoSR = _gobjContextoSR;
        }

        public List<recMenu_Result> recMenus()
        {
            List<recMenu_Result> lobjRespuesta = new List<recMenu_Result>();
            try
            {
                lobjRespuesta = gobjContextoSR.recMenu().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        //id

        public recMenuXId_Result recMenusXID(int pId)
        {
            recMenuXId_Result objRespuesta = new recMenuXId_Result();
            try
            {
                objRespuesta = gobjContextoSR.recMenuXId(pId).Single();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            return objRespuesta;
        }

        //inser

        public bool insMenu(Menu pobjMenu)
        {
            bool objRespuesta= new bool();


            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.insMenu(pobjMenu.Descripcion, pobjMenu.Precio);
                if (intVal==1)
                {
                    objRespuesta = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        //upd

        public bool updMenu(Menu pobjMenu)
        {
            bool objRespuesta = new bool();


            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.updMenu(pobjMenu.IdMenu,pobjMenu.Descripcion, pobjMenu.Precio);
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
        public bool delMenu(Menu pobjMenu)
        {
            bool objRespuesta = new bool();


            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoSR.delMenu(pobjMenu.IdMenu);
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
