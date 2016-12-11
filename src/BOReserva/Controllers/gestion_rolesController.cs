﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_roles;
using BOReserva.Models.gestion_aviones;
using BOReserva.Servicio;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BOReserva.Controllers
{
    public class gestion_rolesController : Controller
    {
        //
        // GET: /gestion_roles/
        public ActionResult M13_AgregarRol()
        {
            manejadorSQL sql = new manejadorSQL();            
            CRoles rol = new CRoles();
            rol.Menu = sql.consultarLosModulos();
            return PartialView(rol);
        }
        public ActionResult M13_VisualizarRol()
        {
            return PartialView();
        }
        //Metodo para agregar roles
        [HttpPost]
        public JsonResult agregarrol(CRoles model)
        {
            //Verifico que todos los campos no sean nulos
            if (model.Nombre_rol == null)
            {             
                //Creo el codigo de error de respuesta
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error               
                String error = "Error, campo obligatorio vacio";
                //Retorno el error                
                return Json(error);
            }            
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //Realizo el insert y Guardo la respuesta de mi metodo sql en un bool
            bool respuesta= sql.insertarRol(model);
            //envio una respuesta dependiendo del resultado del insert
            return (Json(respuesta, JsonRequestBehavior.AllowGet));

        
        }
        //Metodo para consultar permisos de modulo
        [HttpPost]
        public JsonResult Consultarpermisos(string json)
        {
            // creo un item para guardar el Json 
            dynamic _item = JObject.Parse(json);
            //guardo el primer argumento del json en una variable
            var _temp = _item.mod;
            //convierto el objeto json en string
            String modulo = _temp.ToString().Trim();
            //Verifico que todos los campos no sean nulos
            if (modulo == null)
            {
                //Creo el codigo de error de respuesta
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error               
                String error = "Error, campo obligatorio vacio";
                //Retorno el error                
                return Json(error);
            }
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //instancio mi clase modulo general
            CListaGenerica<CModulo_detallado> permisos = new CListaGenerica<CModulo_detallado>();
            //coloco el nombre
            
            //Realizo el consulto y Guardo la respuesta de mi metodo sql 
             permisos = sql.consultarPermisos(modulo);
             System.Diagnostics.Debug.WriteLine(permisos);
            //envio el resultado de la consulta
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

 

	}
}