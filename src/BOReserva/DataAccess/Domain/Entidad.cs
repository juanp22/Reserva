﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase entidad, utilizada para poder acceder a todas las clases del DAO
    /// </summary>
    public class Entidad
    {
        /// <summary>
        /// Atributo propio de la clase entidad.
        /// utilizado para acceder a cada registro.
        /// </summary>
        public int _id { get; set; }

        public Entidad() { }

        public Entidad(int id) { this._id = id; }
    }
}