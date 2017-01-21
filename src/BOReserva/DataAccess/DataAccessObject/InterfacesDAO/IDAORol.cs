﻿using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DAO
{
    interface IDAORol : IDAO
    {
        int AgregarRolPermiso(Entidad e);
        List<Entidad> ConsultarRoles();
        List<Entidad> ConsultarPermisos(int id);
        Entidad ConsultarModulos(int id);
        List<Entidad> ListarPermisos();
    }
}