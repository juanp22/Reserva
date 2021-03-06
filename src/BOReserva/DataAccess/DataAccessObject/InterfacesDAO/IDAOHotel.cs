﻿using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    /// <summary>
    /// Interfaz que posee los metodos eliminarHotel y disponibilidadHotel
    /// </summary>
    public interface IDAOHotel : IDAO
    {
        String eliminarHotel(int id);

        Entidad disponibilidadHotel(Entidad e, int disponibilidad);
    }
}
