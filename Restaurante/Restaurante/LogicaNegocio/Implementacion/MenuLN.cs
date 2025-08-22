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
    public class MenuLN: IMenuLN
    {
        public static SREntities _gobjContextoSR=new SREntities();
        private readonly IMenuAD _gobjMenuAD = new MenuAD(_gobjContextoSR);

        public List<recMenu_Result> recMenus()
        {
            List<recMenu_Result> lobjRespuesta = new List<recMenu_Result>();
            try
            {
                lobjRespuesta = _gobjMenuAD.recMenus();
            }
            catch (Exception ex)
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
                objRespuesta = _gobjMenuAD.recMenusXID(pId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        //ins

        public bool insMenu(Menu pobjMenu)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = _gobjMenuAD.insMenu(pobjMenu);
            }
            catch (Exception ex)
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
                objRespuesta = _gobjMenuAD.updMenu(pobjMenu);
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
                objRespuesta = _gobjMenuAD.delMenu(pobjMenu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }



    }
}
