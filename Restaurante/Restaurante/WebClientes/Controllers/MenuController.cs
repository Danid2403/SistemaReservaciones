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
    public class MenuController : Controller
    {
       private IMenuLN objMenus= new MenuLN();

        //ver platos
        public ActionResult ListaMenu()
        {
            List<recMenu_Result> lstMenus = new List<recMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            lstMenus = objMenus.recMenus();

            foreach(var menu in lstMenus )
            {
                M_Menu objModeloMenu= new M_Menu();
                objModeloMenu.IdMenu=menu.IdMenu;
                objModeloMenu.Descripcion=menu.Descripcion;
                objModeloMenu.Precio=menu.Precio;

                lstModeloMenu.Add(objModeloMenu);

            }

            return View(lstModeloMenu);


        }

        //agregar cliente
        public ActionResult AgregarMenu()
        {
            return View();
        }

        //upd cliente
        public ActionResult ModificaMenu(int id)
        {
            recMenuXId_Result objMenu = new recMenuXId_Result();
            M_Menu objMenuEnt= new M_Menu();
            objMenu=objMenus.recMenusXID(id);
            objMenuEnt.IdMenu = objMenu.IdMenu;
            objMenuEnt.Descripcion = objMenu.Descripcion;
            objMenuEnt.Precio=objMenu.Precio;
            
            return View(objMenuEnt);
        }
        //eliminar
        public ActionResult EliminaMenu(int id)
        {
            recMenuXId_Result objMenu = new recMenuXId_Result();
            M_Menu objMenuEnt = new M_Menu();
            objMenu = objMenus.recMenusXID(id);
            objMenuEnt.IdMenu = objMenu.IdMenu;
            objMenuEnt.Descripcion = objMenu.Descripcion;
            objMenuEnt.Precio = objMenu.Precio;

            return View(objMenuEnt);
        }
        //detalles
        public ActionResult DetalleMenu(int id)
        {
            recMenuXId_Result objMenu = new recMenuXId_Result();
            M_Menu objMenuEnt = new M_Menu();
            objMenu = objMenus.recMenusXID(id);
            objMenuEnt.IdMenu = objMenu.IdMenu;
            objMenuEnt.Descripcion = objMenu.Descripcion;
            objMenuEnt.Precio = objMenu.Precio;

            return View(objMenuEnt);
        }

        //______________________________________________________________________________
        //metodos


        //INSER
        public ActionResult IngresarMenu(Menu objMenu)
        {
            List<recMenu_Result> lstMenus= new List<recMenu_Result>();
            List<M_Menu> lstModeloMenu= new List<M_Menu>();
            try
            {
                if(objMenus.insMenu(objMenu))
                {
                    lstMenus = objMenus.recMenus();
                    foreach(var menu in lstMenus)
                    {
                        M_Menu objModeloMenu= new M_Menu();
                        objModeloMenu.IdMenu= menu.IdMenu;
                        objModeloMenu.Descripcion= menu.Descripcion;
                        objModeloMenu.Precio = menu.Precio;
                        lstModeloMenu.Add(objModeloMenu);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMenu", lstModeloMenu);
        }


        //modif
        public ActionResult ModificarMenu(Menu objMenu)
        {
            List<recMenu_Result> lstMenus = new List<recMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            try
            {
                if (objMenus.updMenu(objMenu))
                {
                    lstMenus = objMenus.recMenus();
                    foreach (var menu in lstMenus)
                    {
                        M_Menu objModeloMenu = new M_Menu();
                        objModeloMenu.IdMenu = menu.IdMenu;
                        objModeloMenu.Descripcion = menu.Descripcion;
                        objModeloMenu.Precio = menu.Precio;
                        lstModeloMenu.Add(objModeloMenu);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMenu", lstModeloMenu);
        }

        //elimianr
        public ActionResult EliminarMenu(Menu objMenu)
        {
            List<recMenu_Result> lstMenus = new List<recMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            try
            {
                if (objMenus.delMenu(objMenu))
                {
                    lstMenus = objMenus.recMenus();
                    foreach (var menu in lstMenus)
                    {
                        M_Menu objModeloMenu = new M_Menu();
                        objModeloMenu.IdMenu = menu.IdMenu;
                        objModeloMenu.Descripcion = menu.Descripcion;
                        objModeloMenu.Precio = menu.Precio;
                        lstModeloMenu.Add(objModeloMenu);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMenu", lstModeloMenu);
        }
        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Menu pMenu)
        {
            try
            {


                Menu objMe= new Menu();
                objMe.IdMenu=pMenu.IdMenu;
                objMe.Descripcion=pMenu.Descripcion;
                objMe.Precio=pMenu.Precio;
                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarMenu(objMe);
                    case "Editar":
                        return ModificarMenu(objMe);
                    case "Eliminar":
                        return EliminarMenu(objMe);

                    default:
                        return RedirectToAction("ListaMenu", "Menu");
                }
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Menu", "Acciones"));
            }
        }

    }
}