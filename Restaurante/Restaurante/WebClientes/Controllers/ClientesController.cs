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
    public class ClientesController : Controller
    {
       private IClientesLN objClientes= new ClientesLN();

        //vistas


        //ver clientes
        public ActionResult ListaClientes()
        {
            List<recClientes_Result> lstClientes= new List<recClientes_Result>();
            List<M_Clientes> lstModeloClientes= new List<M_Clientes>();
            lstClientes = objClientes.recCliente();

            foreach(var clientes in lstClientes)
            {
                M_Clientes objModeloClientes = new M_Clientes();
                objModeloClientes.IdCliente= clientes.IdCliente;
                objModeloClientes.Nombre= clientes.Nombre;
                objModeloClientes.Apellidos= clientes.Apellidos;
                objModeloClientes.Telefono= clientes.Telefono;
                objModeloClientes.CorreoElectronico= clientes.CorreoElectronico;

                lstModeloClientes.Add(objModeloClientes);
            }
            return View(lstModeloClientes);
        }


        //agregar cliente

        public ActionResult AgregaClientes()
        {
            return View();
        }


        //update

        public ActionResult ModificaClientes(int id)
        {
            recClientesXId_Result objCliente= new recClientesXId_Result();
            M_Clientes objClienteEnt= new M_Clientes();
            objCliente = objClientes.recClienteXId(id);
            objClienteEnt.IdCliente = objCliente.IdCliente;
            objClienteEnt.Nombre = objCliente.Nombre;
            objClienteEnt.Apellidos = objCliente.Apellidos;
            objClienteEnt.Telefono = objCliente.Telefono;
            objClienteEnt.CorreoElectronico=objCliente.CorreoElectronico;
            
            return View(objClienteEnt);
        }

        //eliminar

        public ActionResult EliminaClientes(int id)
        {
            recClientesXId_Result objCliente = new recClientesXId_Result();
            M_Clientes objClienteEnt = new M_Clientes();
            objCliente = objClientes.recClienteXId(id);
            objClienteEnt.IdCliente = objCliente.IdCliente;
            objClienteEnt.Nombre = objCliente.Nombre;
            objClienteEnt.Apellidos = objCliente.Apellidos;
            objClienteEnt.Telefono = objCliente.Telefono;
            objClienteEnt.CorreoElectronico = objCliente.CorreoElectronico;

            return View(objClienteEnt);
        }

        //detalles
        public ActionResult DetalleClientes(int id)
        {
            recClientesXId_Result objCliente = new recClientesXId_Result();
            M_Clientes objClienteEnt = new M_Clientes();
            objCliente = objClientes.recClienteXId(id);
            objClienteEnt.IdCliente = objCliente.IdCliente;
            objClienteEnt.Nombre = objCliente.Nombre;
            objClienteEnt.Apellidos = objCliente.Apellidos;
            objClienteEnt.Telefono = objCliente.Telefono;
            objClienteEnt.CorreoElectronico = objCliente.CorreoElectronico;

            return View(objClienteEnt);
        }

        //_____________________________________________________________________________
        //metodos


        //ingresar
        public ActionResult IngresearCliente(Clientes objCliente)
        {
            List<recClientes_Result> lstClientes= new List<recClientes_Result>();
            List<M_Clientes> lstModeloClientes = new List<M_Clientes>();
            try
            {
                if(objClientes.insCliente(objCliente))
                {
                    lstClientes = objClientes.recCliente();
                    foreach(var clientes in lstClientes)
                    {
                        M_Clientes objModeloClientes= new M_Clientes();
                        objModeloClientes.IdCliente= clientes.IdCliente;
                        objModeloClientes.Nombre = clientes.Nombre;
                        objModeloClientes.Apellidos = clientes.Apellidos;
                        objModeloClientes.Telefono = clientes.Telefono;
                        objModeloClientes.CorreoElectronico = clientes.CorreoElectronico;
                        lstModeloClientes.Add(objModeloClientes);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaClientes", lstModeloClientes);
        }

        //Editar
        public ActionResult ModificarCliente(Clientes objCliente)
        {
            List<recClientes_Result> lstClientes = new List<recClientes_Result>();
            List<M_Clientes> lstModeloClientes = new List<M_Clientes>();
            try
            {
                if (objClientes.updCliente(objCliente))
                {
                    lstClientes = objClientes.recCliente();
                    foreach (var clientes in lstClientes)
                    {
                        M_Clientes objModeloClientes = new M_Clientes();
                        objModeloClientes.IdCliente = clientes.IdCliente;
                        objModeloClientes.Nombre = clientes.Nombre;
                        objModeloClientes.Apellidos = clientes.Apellidos;
                        objModeloClientes.Telefono = clientes.Telefono;
                        objModeloClientes.CorreoElectronico = clientes.CorreoElectronico;
                        lstModeloClientes.Add(objModeloClientes);
                    }

                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaClientes", lstModeloClientes);
        }

        //eliminar
        public ActionResult EliminarCliente(Clientes objCliente)
        {
            List<recClientes_Result> lstClientes = new List<recClientes_Result>();
            List<M_Clientes> lstModeloClientes = new List<M_Clientes>();
            try
            {
                if (objClientes.delCliente(objCliente))
                {
                    lstClientes = objClientes.recCliente();
                    foreach (var clientes in lstClientes)
                    {
                        M_Clientes objModeloClientes = new M_Clientes();
                        objModeloClientes.IdCliente = clientes.IdCliente;
                        objModeloClientes.Nombre = clientes.Nombre;
                        objModeloClientes.Apellidos = clientes.Apellidos;
                        objModeloClientes.Telefono = clientes.Telefono;
                        objModeloClientes.CorreoElectronico = clientes.CorreoElectronico;
                        lstModeloClientes.Add(objModeloClientes);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaClientes", lstModeloClientes);
        }
        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Clientes pCliente)
        {
            try
            {

                Clientes objClient = new Clientes();
                objClient.IdCliente= pCliente.IdCliente;
                objClient.Nombre= pCliente.Nombre;
                objClient.Apellidos= pCliente.Apellidos;
                objClient.Telefono= pCliente.Telefono;
                objClient.CorreoElectronico= pCliente.CorreoElectronico;
                switch(submitButton)
                {
                    case "Agregar":
                        return IngresearCliente(objClient);
                    case "Editar":
                        return ModificarCliente(objClient);
                    case "Eliminar":
                        return EliminarCliente(objClient);

                        default:
                        return RedirectToAction("ListaClientes", "Cliente");
                }               
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Cliente", "Acciones"));
            }
        }
    }
}