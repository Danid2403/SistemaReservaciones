using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using WebClientes.Models;

namespace WebClientes.Controllers
{
    public class MesasController : Controller
    {
        private IMesasLN objMesas = new  MesasLN();

        //ver mesas

        public ActionResult ListaMesas()
        {
            List<recMesas_Result> lstMesas = new List<recMesas_Result>();
            List<M_Mesas>lstModeloMesas = new List<M_Mesas>();
            lstMesas = objMesas.recMesa();

            foreach(var mesa in lstMesas)
            {
                M_Mesas objModeloMesas=new M_Mesas();
                objModeloMesas.IdMesa = mesa.IdMesa;
                objModeloMesas.DescripcionMesa=mesa.DescripcionMesa;
                objModeloMesas.NumeroMesa=mesa.NumeroMesa;


                lstModeloMesas .Add(objModeloMesas);
            }
            return View(lstModeloMesas);
        }

        //agregar Mesa

        public ActionResult AgregarMesas()
        {
            return View();
        }

        //upd

        public ActionResult ModificaMesa(int id)
        {
            recMesasXId_Result objMesa = new recMesasXId_Result();
            M_Mesas objMesaEnt= new M_Mesas();
            objMesa=objMesas.recMesaXID(id);
            objMesaEnt.IdMesa = objMesa.IdMesa;
            objMesaEnt.DescripcionMesa = objMesa.DescripcionMesa;
            objMesaEnt.NumeroMesa= objMesa.NumeroMesa;

            return View(objMesaEnt);
        }

        //eliminar

        public ActionResult EliminaMesa(int id)
        {
            recMesasXId_Result objMesa = new recMesasXId_Result();
            M_Mesas objMesaEnt = new M_Mesas();
            objMesa = objMesas.recMesaXID(id);
            objMesaEnt.IdMesa = objMesa.IdMesa;
            objMesaEnt.DescripcionMesa = objMesa.DescripcionMesa;
            objMesaEnt.NumeroMesa = objMesa.NumeroMesa;

            return View(objMesaEnt);
        }

        //detalles
        public ActionResult DetalleMesa(int id)
        {
            recMesasXId_Result objMesa = new recMesasXId_Result();
            M_Mesas objMesaEnt = new M_Mesas();
            objMesa = objMesas.recMesaXID(id);
            objMesaEnt.IdMesa = objMesa.IdMesa;
            objMesaEnt.DescripcionMesa = objMesa.DescripcionMesa;
            objMesaEnt.NumeroMesa = objMesa.NumeroMesa;

            return View(objMesaEnt);
        }

        //___________________________________________________________________________________________
        //metodos

        //inser

        public ActionResult IngresarMesa(Mesas objMesa)
        {
            List<recMesas_Result> lstMesas = new List<recMesas_Result>();
            List<M_Mesas> lstModeloMesas= new List<M_Mesas>();
            try
            {
                if (objMesas.insMesa(objMesa))
                {
                    lstMesas = objMesas.recMesa();
                    foreach(var mesa in lstMesas)
                    {
                        M_Mesas objModeloMesa = new M_Mesas();
                        objModeloMesa.IdMesa = mesa.IdMesa;
                        objModeloMesa.DescripcionMesa = mesa.DescripcionMesa;
                        objModeloMesa.NumeroMesa = mesa.NumeroMesa;
                        lstModeloMesas.Add(objModeloMesa);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMesas", lstModeloMesas);

        }

        //modif
        public ActionResult ModificarMesa(Mesas objMesa)
        {
            List<recMesas_Result> lstMesas = new List<recMesas_Result>();
            List<M_Mesas> lstModeloMesas = new List<M_Mesas>();
            try
            {
                if (objMesas.updMesa(objMesa))
                {
                    lstMesas = objMesas.recMesa();
                    foreach (var mesa in lstMesas)
                    {
                        M_Mesas objModeloMesa = new M_Mesas();
                        objModeloMesa.IdMesa = mesa.IdMesa;
                        objModeloMesa.DescripcionMesa = mesa.DescripcionMesa;
                        objModeloMesa.NumeroMesa = mesa.NumeroMesa;
                        lstModeloMesas.Add(objModeloMesa);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMesas", lstModeloMesas);

        }

        //eliminar
        public ActionResult EliminarMesa(Mesas objMesa)
        {
            List<recMesas_Result> lstMesas = new List<recMesas_Result>();
            List<M_Mesas> lstModeloMesas = new List<M_Mesas>();
            try
            {
                if (objMesas.delMesa(objMesa))
                {
                    lstMesas = objMesas.recMesa();
                    foreach (var mesa in lstMesas)
                    {
                        M_Mesas objModeloMesa = new M_Mesas();
                        objModeloMesa.IdMesa = mesa.IdMesa;
                        objModeloMesa.DescripcionMesa = mesa.DescripcionMesa;
                        objModeloMesa.NumeroMesa = mesa.NumeroMesa;
                        lstModeloMesas.Add(objModeloMesa);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMesas", lstModeloMesas);

        }
        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Mesas pMesa)
        {
            try
            {
                Mesas objM = new Mesas();
                objM.IdMesa = pMesa.IdMesa;
                objM.DescripcionMesa = pMesa.DescripcionMesa;
                objM.NumeroMesa = pMesa.NumeroMesa;
                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarMesa(objM);
                    case "Editar":
                        return ModificarMesa(objM);
                    case "Eliminar":
                        return EliminarMesa(objM);

                    default:
                        return RedirectToAction("ListaMesas", "Mesas");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Acciones"));
            }
        }
    }
}