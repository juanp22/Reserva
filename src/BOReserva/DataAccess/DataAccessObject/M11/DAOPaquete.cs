﻿using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M11
{
    /// <summary>
    /// Clase DAOPquete que implementa la interface IDAOPaquete
    /// </summary>
    public class DAOPaquete : DAO, IDAOPaquete
    {
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public DAOPaquete() { }

        int IDAO.Agregar(Entidad e)
        {
            Paquete paquete = (Paquete)e;

            int estado; //estado nos indica si el paquete está activo o no
            if (paquete._estadoPaquete == true)
                estado = 1;
            else
                estado = 0;

            SqlConnection conexion = Connection.getInstance(_connexionString);  //Para obtener la conexión a la 
                                                                                //base de datos
            try
            {
                conexion.Open();
                SqlCommand query = conexion.CreateCommand(); //El método SqlConnection.CreateCommand()
                                                             //crea y devuelve un objeto SqlCommand asociado 
                                                             //a la conexión SqlConnection.
                                                             //Se usa SqlCommand para las instrucciones que se 
                                                             //ejecutan en una base de datos de SQL Server.
                query.CommandText = "INSERT INTO Paquete (paq_nombre, paq_precio, paq_fk_automovil,"+
                " paq_fk_restaurante, paq_fk_hotel, paq_fk_crucero, paq_fk_vuelo, paq_fechaInicio_automovil,"+
                " paq_fechaInicio_restaurante, paq_fechaInicio_crucero, paq_fechaInicio_hotel,"+
                " paq_fechaInicio_boleto, paq_fechaFin_automovil, paq_fechaFin_restaurante, paq_fechaFin_hotel,"+
                " paq_fechaFin_crucero, paq_fechaFin_boleto, paq_estado) VALUES  (@pn, @pp, @pfa, @pfr, @pfh,"+
                " @pfc, @pfv, @fia, @fir, @fic, @fih, @fib, @ffa, @ffr, @ffh, @ffc, @ffb, @pe);";

                query.Parameters.AddWithValue("@pn", paquete._nombrePaquete);
                query.Parameters.AddWithValue("@pp", paquete._precioPaquete);
                query.Parameters.AddWithValue("@pfa", (object)paquete._idAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfr", (object)paquete._idRestaurante ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfh", (object)paquete._idHotel ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfc", (object)paquete._idCrucero ?? DBNull.Value);
                query.Parameters.AddWithValue("@pfv", (object)paquete._idVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@fia", (object)paquete._fechaIniAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@fir", (object)paquete._fechaIniRest ?? DBNull.Value);
                query.Parameters.AddWithValue("@fic", (object)paquete._fechaIniCruc ?? DBNull.Value);
                query.Parameters.AddWithValue("@fih", (object)paquete._fechaIniHotel ?? DBNull.Value);
                query.Parameters.AddWithValue("@fib", (object)paquete._fechaIniVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffa", (object)paquete._fechaFinAuto ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffr", (object)paquete._fechaFinRest ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffh", (object)paquete._fechaFinHotel ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffc", (object)paquete._fechaFinCruc ?? DBNull.Value);
                query.Parameters.AddWithValue("@ffb", (object)paquete._fechaFinVuelo ?? DBNull.Value);
                query.Parameters.AddWithValue("@pe", estado);
            }
            catch (Exception)
            {
                
                throw;
            }
            return 0;
        }
    }
}