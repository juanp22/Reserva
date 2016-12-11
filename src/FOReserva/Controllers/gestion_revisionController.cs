﻿using FOReserva.Models.Revision;
using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Restaurantes;

namespace FORevision.Controllers
{
    /// <summary>
    /// Gestion Revision Controlador
    /// </summary>
    public class gestion_revisionController : Controller
    {
       

 

        /// <summary>
        /// Creacion Modelo Consultar_Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Consultar_RevisionUsuario(string nombre , string apellido)
        {
        
            List<CRevision> lista;
            ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();
            lista = manejador.ConsultarRevision(nombre, apellido);

            return PartialView(lista);
        }

        /// <summary>
        /// Creacion Modelo Eliminar Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Eliminar_Revision(string nombre, string apellido, int revision)
        {
           
           

                CRevision Revision = new CRevision();
                ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();  // crear en Servicios un manejador para listar 
                Revision = manejador.Eliminar_Revision(nombre, apellido, revision);
                return PartialView(Revision);
           

           
            
            

        }
        
        /// <summary>
        /// Creacion Modelo Crear Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        public ActionResult Crear_Revision(string nombre, string apellido, int revision) 
        {

            CRevision Revision = new CRevision();
            ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();
            Revision = manejador.Crear_Revision(nombre, apellido, revision);
            return PartialView(Revision);

        }

        /// <summary>
        /// Creacion Modelo Crear Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>

        public ActionResult Editar_Revision(string nombre, string apellido, int revision)
        {

            CRevision Revision = new CRevision();
            ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();
            Revision = manejador.Editar_Revision(nombre, apellido, revision);
            return PartialView(Revision);



        }

        /// <summary>
        /// Creacion Modelo Consultar_Revision
        /// </summary>
        /// <returns>Vista Modelo</returns>
        
        public ActionResult Mostrar_Revision(string nombre, string apellido, int tipo )
        {

            if (tipo == 1)
            {
                List<CRevision> lista;
                ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();
                lista = manejador.MostrarRevision_Restaurant(nombre, apellido, tipo);
                return PartialView(lista);
            }
            else if (tipo ==2)
            {

                List<CRevision> lista;
                ManejadorSQLMuestraRevision manejador = new ManejadorSQLMuestraRevision();
                lista = manejador.MostrarRevision_Hotel(nombre, apellido, tipo);
                return PartialView(lista);


            }
        }

    }
}

