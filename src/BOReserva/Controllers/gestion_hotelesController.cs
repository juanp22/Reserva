﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Servicio.Servicio_Hoteles;
using System.Diagnostics;
using System.Net;

namespace BOReserva.Controllers
{
    public class gestion_hotelesController : Controller
    {
        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Crear()
        {
            CHotel crear = new CHotel()
            {
                _listapaises = new List<SelectListItem>(pais())
            };

            return PartialView(crear);
        }

        [HttpPost]
        public JsonResult crearhotel(CHotel crear) {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult editarhotel(CGestionHoteles_EditarHotel modificar)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Metodo para que el Hotel NO este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema</returns>
        [HttpPost]
        public JsonResult deshabilitarHotel(int id)
        {
            CManejadorSQL_Hoteles sql = new CManejadorSQL_Hoteles();
            Boolean resultado = sql.deshabilitarHotelBD(id);
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error  
                String error = "Error en la base de datos";
                //Retorno el error  
                return Json(error);
            }
        }

        public static List<SelectListItem> pais()
        {
            CManejadorSQL_Hoteles pais = new CManejadorSQL_Hoteles();
            List<SelectListItem> _pais = new List<SelectListItem>();
            String[] paises = pais.MListarpaisesBD();

            _pais.Add(new SelectListItem
            {
                Text = "Seleccione País",
                Value = ""
            });

            int i = 0;
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _pais.Add(new SelectListItem
                    {
                        Text = paises[i].ToString(),
                        Value =paises[i].ToString()

                    });
                    i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }
            return _pais;
        }

        public ActionResult M09_GestionHoteles_Visualizar()
        { 
            CManejadorSQL_Hoteles buscarhoteles = new CManejadorSQL_Hoteles();
            List<CHotel> listahoteles = buscarhoteles.MListarHotelesBD();  //AQUI SE BUSCAN TODO LOS HOTELES QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA       
            return PartialView(listahoteles);
        }

        public List<SelectListItem> ciudad(string pais)
        {
            Debug.WriteLine("CIUDAD FILTRADA");
            List<SelectListItem> _ciudades = new List<SelectListItem>();
            CManejadorSQL_Hoteles ciudad = new CManejadorSQL_Hoteles();
            String[] ciudadesBD = ciudad.MListarciudadesBD(pais);

            _ciudades.Add(new SelectListItem
            {
                Text = "Seleccione Ciudad",
                Value = "0"
            });

            int i = 0;
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _ciudades.Add(new SelectListItem
                    {
                        Text = _ciudades[i].ToString(),
                        Value = i.ToString()
                    });
                    i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }

            return _ciudades;
        }

        [HttpPost]
        public JsonResult guardarHotel(CHotel model)
        {
            Debug.WriteLine(model._direccion);
            Debug.WriteLine(model._email);
            Debug.WriteLine(model._estrellas.ToString());
            Debug.WriteLine(model._canthabitaciones.ToString());
            Debug.WriteLine(model._paginaweb);
            Debug.WriteLine("Pais "+model._pais);
            Debug.WriteLine(model._nombre);

            //Chequeo si los campos obligatorios estan vacios como medida de seguridad
            if ((model._canthabitaciones == 0) || (model._direccion == null) || (model._nombre == null)
                || (model._email == null) || (model._estrellas == 0)  || (model._paginaweb == null) || (model._pais == null)) 
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, campo obligatorio vacio";
                //Retorno el error
                return Json(error);
            }
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            CManejadorSQL_Hoteles sql = new CManejadorSQL_Hoteles();
            //realizo el insert
            bool resultado = sql.insertarHotel(model);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD";
                return Json(error);
            }
        }

        /// <summary>
        /// Metodo que carga la vista para modificar el Hotel 
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> ActionResult con los datos de un Hotel </returns>
        public ActionResult ConsultarHotel(int id)
        {
            Debug.WriteLine("CONSULTAR HOTEL CONTROLLER");
            CManejadorSQL_Hoteles sql = new CManejadorSQL_Hoteles();
            CHotel hotel = new CHotel();
            hotel = sql.consultarHotel(id);
            Debug.WriteLine(hotel._nombre);
            CGestionHoteles_EditarHotel modelo = new CGestionHoteles_EditarHotel(hotel);
            Debug.WriteLine(modelo._nombre);
            Debug.WriteLine("MODELO EITAR HOTEL");
            return PartialView("M09_GestionHoteles_ModificarHotel", modelo);
        }

        /// Metodo para que el hotel este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema </returns>
        [HttpPost]
        public JsonResult habilitarHotel(int id)
        {
            CManejadorSQL_Hoteles sql = new CManejadorSQL_Hoteles();
            Boolean resultado = sql.activarHotelBD(id);
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error  
                String error = "Error en la base de datos";
                //Retorno el error  
                return Json(error);
            }
        }

    }
}