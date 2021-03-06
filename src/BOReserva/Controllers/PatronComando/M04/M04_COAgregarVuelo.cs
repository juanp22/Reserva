﻿using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.Excepciones;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COAgregarVuelo : Command<Boolean>
    {
        
        private Entidad _vuelo;

        #region Constructores

        /// <summary>
        /// Constructor simple
        /// </summary>
        public M04_COAgregarVuelo() {}

        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="vuelo">Es el objeto que se quiere agregar</param>
        public M04_COAgregarVuelo(Entidad vuelo)
        {
            _vuelo = vuelo; 
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método Agregar
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override Boolean ejecutar()
        {
            try
            {
                IDAO vueloAdd = FabricaDAO.instanciarDAOVuelo();
                vueloAdd.Agregar(_vuelo);
                return true;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            
        }
        #endregion
    }
}