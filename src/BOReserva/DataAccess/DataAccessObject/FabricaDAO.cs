﻿using BOReserva.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class FabricaDAO
    {
        public static DAO instanciarDaoHotel() {
            return new DAOHotel();
        }

        public static DAO instanciarDaoReclamo() 
        {
            return new DAOReclamo();
        }


        #region M04_Vuelos
        /// <summary>
        /// Método que crea la instancia de DAOVuelo
        /// </summary>
        /// <returns>Retorna la instancia a la clase DAOVuelo</returns>
        public static DAO instanciarDAOVuelo()
        {
            return new DAOVuelo();
        }
        #endregion


        # region M05_Boleto

        public static DAO instanciarDaoPasajero()
        {
            return new DAOPasajero();
        }

        #endregion

        #region M13_Roles
        public static DAO instanciarDAORol()
        {
            return new DAORol();
        }
        public static DAORol instanciarDAORolPermiso()
        {
            return new DAORol();
        }
        #endregion
    }
}