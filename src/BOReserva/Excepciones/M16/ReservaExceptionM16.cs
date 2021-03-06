﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Excepciones.M16
{
    /// <summary>
    /// Clase que maneja las excepciones del módulo para la gestión de reclamos
    /// </summary>
    public class ReservaExceptionM16 : Exception
    {

        private Exception _excepcion;
        private string _codigoException;
        private string _mensajeException;

        /// <summary>
        /// Get y set del codigo
        /// </summary>
        public string Codigo 
        {
            get { return _codigoException ; }
            set { _codigoException = value; }
        }

        /// <summary>
        /// Get y set del mensaje
        /// </summary>
        public string Mensaje
        {
            get { return _mensajeException; }
            set { _mensajeException = value; }
        }

        /// <summary>
        /// Get y set de excepcion
        /// </summary>
        public Exception Excepcion
        {
            get { return _excepcion; }
            set { _excepcion = value; }
        }

        /// <summary>
        /// constructor para la excepcion SqlException
        /// </summary>
        /// <param name="mensaje">recibe el mensaje</param>
        /// <param name="inner">y la excepcion</param>        
        public ReservaExceptionM16(string mensaje, SqlException inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un problema con la base de datos. Para mayor detalle revisar el Log de errores";
            _excepcion = inner;
        }

        /// <summary>
        /// constructor para la excepcion NullReferenceException
        /// </summary>
        /// <param name="mensaje">recibe el mensaje</param>
        /// <param name="inner">y la excepcion</param>
        public ReservaExceptionM16(string mensaje, NullReferenceException inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un problema con una referencia nula. Para mayor detalle revisar el Log de errores";
            _excepcion = inner;
        }

        /// <summary>
        /// constructor para la excepcion ArgumentNullException
        /// </summary>
        /// <param name="mensaje">recibe el mensaje</param>
        /// <param name="inner">y la excepcion</param>
        public ReservaExceptionM16(string mensaje, ArgumentNullException inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un problema con un argumento nulo. Para mayor detalle revisar el Log de errores";
            _excepcion = inner;
        }

        /// <summary>
        /// constructor para la excepcion LogException
        /// </summary>
        /// <param name="mensaje"> recibe el mensaje</param>
        /// <param name="inner"> y la excepcion</param>
        public ReservaExceptionM16(string mensaje, LogException inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un error al escribir el log. Para mayor detalle revisar el Log de errores";
           _excepcion = inner;
        }

        /// <summary>
        /// constructor para la excepcion de tipo Exception
        /// </summary>
        /// <param name="mensaje">recibe el mensaje</param>
        /// <param name="inner">y la excepcion</param>
        public ReservaExceptionM16(string mensaje, Exception inner)
        {
            _mensajeException = "Reserva-404: Ha ocurrido un error desconocido. Para mayor detalle revisar el Log de errores";
            _excepcion = inner;
        }

        
    }
}