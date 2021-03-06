﻿using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Models.gestion_roles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando Visualizar Permisos
    /// </summary>
    public class M13_COListarPermisos : Command<List<Entidad>>
    {
        ///<summary>
        ///Constructor vacio
        ///</summary>
        public M13_COListarPermisos()
        {
        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        public override List<Entidad> ejecutar()
        {
            List<Entidad> listapermisos;
            try
            {
                IDAORol daoRol = (IDAORol)FabricaDAO.instanciarDAORol();
                listapermisos = daoRol.ListarPermisos();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listapermisos;
        }

    }
}