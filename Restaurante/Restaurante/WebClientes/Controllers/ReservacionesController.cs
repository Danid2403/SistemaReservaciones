using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClientes.Models;


namespace WebClientes.Controllers
{
    public class ReservacionesController : Controller
    {

        //vistas
        private IReservacionesLN objReservaciones = new ReservacionesLN();

        //ver Reservaciones

        public ActionResult ListaReservaciones()
        {
            List<recReservaciones_Result> lstReservaciones = new List<recReservaciones_Result>();
            List<M_Reservaciones> lstModeloReservaciones= new List<M_Reservaciones>();
            lstReservaciones = objReservaciones.recReservacion();

            foreach(var reservacion in lstReservaciones)
            {
                M_Reservaciones objModeloReservaciones= new M_Reservaciones();
                objModeloReservaciones.NumeroReservacion = reservacion.NumeroReservacion;
                objModeloReservaciones.IdCliente = reservacion.IdCliente;
                objModeloReservaciones.IdMesa = reservacion.IdMesa;
                objModeloReservaciones.IdMenu=reservacion.IdMenu;
                objModeloReservaciones.Cantidad=reservacion.Cantidad;
                objModeloReservaciones.FechaReservacion=reservacion.FechaReservacion;
                
                
                lstModeloReservaciones.Add(objModeloReservaciones);
            }
            return View(lstModeloReservaciones);
        }
        //agregar
        public ActionResult AgregarReservacion()
        {
            return View();
        }

        //upd
        public ActionResult ModificaReservacion(int id)
        {
            recReservacionesXId_Result objReservacion= new recReservacionesXId_Result();
            M_Reservaciones objReservaEnt= new M_Reservaciones();
            objReservacion= objReservaciones.recReservacionXID(id);
            objReservaEnt.NumeroReservacion=objReservacion.NumeroReservacion;
            objReservaEnt.IdCliente = objReservacion.IdCliente;
            objReservaEnt.IdMesa = objReservacion.IdMesa;
            objReservaEnt.IdMenu =objReservacion.IdMenu;
            objReservaEnt.Cantidad=objReservacion.Cantidad;
            objReservaEnt.FechaReservacion = objReservacion.FechaReservacion;

            return View(objReservaEnt);
        }

        //ELIMINAR
        public ActionResult EliminaReservacion(int id)
        {
            recReservacionesXId_Result objReservacion = new recReservacionesXId_Result();
            M_Reservaciones objReservaEnt = new M_Reservaciones();
            objReservacion = objReservaciones.recReservacionXID(id);
            objReservaEnt.NumeroReservacion = objReservacion.NumeroReservacion;
            objReservaEnt.IdCliente = objReservacion.IdCliente;
            objReservaEnt.IdMesa = objReservacion.IdMesa;
            objReservaEnt.IdMenu = objReservacion.IdMenu;
            objReservaEnt.Cantidad = objReservacion.Cantidad;
            objReservaEnt.FechaReservacion = objReservacion.FechaReservacion;

            return View(objReservaEnt);
        }

        //detalles
        public ActionResult DetalleReservacion(int id)
        {
            recReservacionesXId_Result objReservacion = new recReservacionesXId_Result();
            M_Reservaciones objReservaEnt = new M_Reservaciones();
            objReservacion = objReservaciones.recReservacionXID(id);
            objReservaEnt.NumeroReservacion = objReservacion.NumeroReservacion;
            objReservaEnt.IdCliente = objReservacion.IdCliente;
            objReservaEnt.IdMesa = objReservacion.IdMesa;
            objReservaEnt.IdMenu = objReservacion.IdMenu;
            objReservaEnt.Cantidad = objReservacion.Cantidad;
            objReservaEnt.FechaReservacion = objReservacion.FechaReservacion;

            return View(objReservaEnt);
        }
        //________________________________________________________________________
        //metodos
        
        //inser

        public ActionResult IngresaReservacion(Reservaciones objReservacion)
        {
            List<recReservaciones_Result> lstReservaciones = new List<recReservaciones_Result>();
            List<M_Reservaciones> lstModeloReservaciones = new List<M_Reservaciones>();
            try
            {
                if (objReservaciones.insReservacion(objReservacion)) // Inserta la reservación
                {
                    lstReservaciones = objReservaciones.recReservacion(); // Recupera todas las reservaciones
                    foreach (var reserv in lstReservaciones)
                    {
                        M_Reservaciones objModeloReservaciones = new M_Reservaciones
                        {
                            NumeroReservacion = reserv.NumeroReservacion,
                            IdCliente = reserv.IdCliente,
                            IdMesa = reserv.IdMesa,
                            IdMenu = reserv.IdMenu,
                            Cantidad = reserv.Cantidad,
                            FechaReservacion = reserv.FechaReservacion
                        };
                        lstModeloReservaciones.Add(objModeloReservaciones); // Añade a la lista
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Reservaciones", "IngresaReservacion"));
            }

            // Asegúrate de usar RedirectToAction para evitar la repetición del código en la vista
            return RedirectToAction("ListaReservaciones");
        }
        //modif
        public ActionResult ModReservacion(Reservaciones objReservacion)
        {
            List<recReservaciones_Result> lstReservaciones = new List<recReservaciones_Result>();
            List<M_Reservaciones> lstModeloReservaciones = new List<M_Reservaciones>();
            try
            {
                if (objReservaciones.updReservacion(objReservacion))
                {
                    lstReservaciones = objReservaciones.recReservacion();
                    foreach (var reserv in lstReservaciones)
                    {
                        M_Reservaciones objModeloReservaciones = new M_Reservaciones();
                        objModeloReservaciones.NumeroReservacion = reserv.NumeroReservacion;
                        objModeloReservaciones.IdCliente = reserv.IdCliente;
                        objModeloReservaciones.IdMesa = reserv.IdMesa;
                        objModeloReservaciones.IdMenu = reserv.IdMenu;
                        objModeloReservaciones.Cantidad = reserv.Cantidad;
                        objModeloReservaciones.FechaReservacion = reserv.FechaReservacion;
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaReservaciones", lstModeloReservaciones);
        }

        //eliminaar
        public ActionResult EliminReservacion(Reservaciones objReservacion)
        {
            List<recReservaciones_Result> lstReservaciones = new List<recReservaciones_Result>();
            List<M_Reservaciones> lstModeloReservaciones = new List<M_Reservaciones>();
            try
            {
                if (objReservaciones.delReservacion(objReservacion))
                {
                    lstReservaciones = objReservaciones.recReservacion();
                    foreach (var reserv in lstReservaciones)
                    {
                        M_Reservaciones objModeloReservaciones = new M_Reservaciones();
                        objModeloReservaciones.NumeroReservacion = reserv.NumeroReservacion;
                        objModeloReservaciones.IdCliente = reserv.IdCliente;
                        objModeloReservaciones.IdMesa = reserv.IdMesa;
                        objModeloReservaciones.IdMenu = reserv.IdMenu;
                        objModeloReservaciones.Cantidad = reserv.Cantidad;
                        objModeloReservaciones.FechaReservacion = reserv.FechaReservacion;
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaReservaciones", lstModeloReservaciones);
        }
        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Reservaciones pReserva)
        {
            try
            {
                Reservaciones objRe = new Reservaciones();
                objRe.NumeroReservacion = pReserva.NumeroReservacion;
                objRe.IdCliente = pReserva.IdCliente;
                objRe.IdMesa = pReserva.IdMesa;
                objRe.IdMenu = pReserva.IdMenu;
                objRe.Cantidad = pReserva.Cantidad;
                objRe.FechaReservacion = pReserva.FechaReservacion;
                switch(submitButton)
                {
                    case "Agregar":
                        return IngresaReservacion(objRe);
                    case "Editar":
                        return ModReservacion(objRe);
                    case "Eliminar":
                        return EliminReservacion(objRe);

                    default:
                        return RedirectToAction("ListaReservaciones", "Reservaciones");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Reservaciones", "Acciones"));
            }
        }
    }
}