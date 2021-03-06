﻿using BOReserva.Controllers.PatronComando.M09;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M09;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Clase para el comando de obtencion de paises
    /// </summary>
    public class M09_COObtenerPaises : Command<Dictionary<int,Entidad>> , IM09_COObtenerPaises
    {
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Dictionary<int,Entidad></returns>
        public override Dictionary<int,Entidad> ejecutar()
        {
            try
            {
                IDAO daoPais = FabricaDAO.instanciarDaoPais();
                Dictionary<int, Entidad> paisesSinCiudad = daoPais.ConsultarTodos();
                IDAO daoCiudad = FabricaDAO.instanciarDaoCiudad();
                Dictionary<int, Entidad> ciudades = daoCiudad.ConsultarTodos();
                Dictionary<int, Entidad> paisesConCiudad = new Dictionary<int, Entidad>();

                foreach (var pais in paisesSinCiudad)
                {
                    Pais p = (Pais)pais.Value;
                    p._ciudades = obtenerCiudadesPorPais(ciudades, p._id);
                    paisesConCiudad.Add(pais.Key, p);
                }

                return paisesConCiudad;
            }
            catch (Exception ex) {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }


        /// <summary>
        /// Metodo implementado proveniente de la interfaz IM09_COObtenerPaises
        /// </summary>
        /// <returns>Dictionary<int,Entidad></returns>
        Dictionary<int, Entidad> IM09_COObtenerPaises.obtenerCiudadesPorPais(Dictionary<int, Entidad> ciudades, int fkPais)
        {
            try
            {
                Dictionary<int, Entidad> ciudadesPorPais = new Dictionary<int, Entidad>();
                foreach (var item in ciudades)
                {
                    Ciudad ciudad = (Ciudad)item.Value;
                    if (ciudad._fkPais == fkPais)
                    {
                        ciudadesPorPais.Add(item.Key, item.Value);
                    }
                    // do something with entry.Value or entry.Key
                }

                return ciudadesPorPais;
            }
            catch (Exception e) 
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
        }

        /// <summary>
        /// Metodo para obtener las ciudades por pais
        /// </summary>
        /// <returns>Dictionary<int,Entidad></returns>
        private Dictionary<int, Entidad> obtenerCiudadesPorPais(Dictionary<int, Entidad> ciudades, int fkPais)
        {
            try
            {
                Dictionary<int, Entidad> ciudadesPorPais = new Dictionary<int, Entidad>();
                foreach (var item in ciudades)
                {
                    Ciudad ciudad = (Ciudad)item.Value;
                    if (ciudad._fkPais == fkPais)
                    {
                        ciudadesPorPais.Add(item.Key, item.Value);
                    }
                    // do something with entry.Value or entry.Key
                }

                return ciudadesPorPais;
            }
            catch(Exception e) 
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;

            }
        }

        /// <summary>
        /// Metodo ipara obtener el identificador de una ciudad
        /// </summary>
        /// <param name="ciudad">Ciudad a buscar</param>
        /// <returns>Retorna un _idHotel entero</returns>
        public int obtenerIdentificadorCiudad(String ciudad)
        {
            try
            {
                int id;
                DAOCiudad daoPais = (DAOCiudad)FabricaDAO.instanciarDaoCiudad();
                id = daoPais.obtenerIDciudad(ciudad);
                return id;
            }
            catch (ReservaExceptionM09 ex)
            {
                throw ex;
            }
        }
    }
}