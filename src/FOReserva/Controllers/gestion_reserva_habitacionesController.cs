﻿using FOReserva.DataAccess.Domain;
using FOReserva.Controllers.PatronComando;
using FOReserva.Models.ReservaHabitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Controllers
{
    /// <summary>
    /// Clase encargada de controlar la comunicacion entre la vista y el controlador
    /// </summary>
    public class gestion_reserva_habitacionesController : Controller
    {
        /// <summary>
        /// Metodo para cargar las reservas
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        [HttpGet]
        public ActionResult mis_reservas()
        {
            var user_id = 207;

            //if (Session["id_usuario"] != null && Session["id_usuario"] is int)
            //    user_id = (int)Session["id_usuario"];

            Command<Dictionary<int, Entidad>> comando = FabricaComando.mostrarReservaUsuario(user_id);
            Dictionary<int, Entidad> listareserva = comando.ejecutar();
            return PartialView(listareserva);
        }
        /// <summary>
        /// Metodo para cargar la ventana de Buscar hoteles 
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        [HttpGet]
        public ActionResult buscar_hoteles(Cvista_BuscarHotel model)
        {
            Command<List<CiudadHab>> comando = FabricaComando.obtenerCiudades();
            List<CiudadHab> listaciudad = comando.ejecutar();
            if (Session["RHACiudades"] == null)
                Session["RHACiudades"] = listaciudad;

            if (model.Ciudades == null)
                model.Ciudades = (List<CiudadHab>)Session["RHACiudades"];

            if (model.FechaLlegada.Ticks == 0)
            {
                model.FechaLlegada = DateTime.Now.AddDays(1);
            }

            if (model.CantidadDias < 1)
                model.CantidadDias = 1;

            return PartialView(model);
        }
        /// <summary>
        /// Metodo para cargar la ventana de Hoteles con Habitaciones
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        [HttpGet]
        public ActionResult hoteles_con_habitaciones(Cvista_BuscarHotel datos)
        {

            Command<Dictionary<int, Entidad>> comando = FabricaComando.obtenerHotelCiudad(datos.LugId);
            Dictionary<int, Entidad> listaHoteles = comando.ejecutar();

            return PartialView(listaHoteles);
        }
        /// <summary>
        /// Metodo para cargar la ventana de Realizar Reserva
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        [HttpPost]
        public ActionResult realizar_reserva(Cvista_ReservarHabitacion reserva)
        {
            var user_id = 207;

            if (Session["id_usuario"] != null && Session["id_usuario"] is int)
                user_id = (int)Session["id_usuario"];

            reserva.UsuId = user_id; // Usuario Actual
            ReservaHabitacion Habitacion = new ReservaHabitacion(reserva.CantidadDias, reserva.FechaLlegada, reserva.HotId, reserva.UsuId);
            Command<string> comando = FabricaComando.agregarReservaHabitacion(Habitacion);
            string agrego = comando.ejecutar();
            return Json(agrego, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Metodo para cargar la ventana de Cancelar Reserva
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        [HttpPost]
        public ActionResult cancelar_reserva(int seleccion)
        {
            Command<String> comando = FabricaComando.eliminarReservaUsuario(seleccion);
            string agrego = comando.ejecutar();
            return Json(agrego, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Metodo para cargar la ventana de Modificar Reserva
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        [HttpPost]
        public ActionResult modificar_reserva(int id_reserva, int cant_dias)
        {
            Command<String> comando = FabricaComando.modificarReservaUsuario(id_reserva, cant_dias);
            String agrego = comando.ejecutar();
            return Json(agrego, JsonRequestBehavior.AllowGet);
        }
    }
}