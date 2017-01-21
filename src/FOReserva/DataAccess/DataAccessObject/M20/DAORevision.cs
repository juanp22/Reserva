﻿using FOReserva.DataAccess.DataAccessObject.Common;
using FOReserva.DataAccess.DataAccessObject.Common.Interface;
using FOReserva.Models.Hoteles;
using FOReserva.Models.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.Models.Restaurantes;
using FOReserva.Models.Usuarios;
using FOReserva.Models.ReservaHabitacion;
using FOReserva.DataAccess.Model;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.M20;
using System.Data;
using static FOReserva.Models.Revision.CRevision;

namespace FOReserva.DataAccess.DataAccessObject.M20
{
    public class DAORevision : DAO, IDAORevision
    {
        #region Patron Singleton DAORevision.
        private static DAORevision instance = null;

        public static DAORevision Singleton()
        {
            if (DAORevision.instance == null)
                DAORevision.instance = (DAORevision)FabricaDAO.CreateDAORevision();
            return DAORevision.instance;
        }
        #endregion

        #region Implementacion DAORevision.        
        public void GuardarRevision(Entidad revision)
        {            
            List<Parametro> parametros = null;
            CRevision iRevision = null;
            try
            {
                if (!(revision is CRevision))
                    throw new DAOM20Exception("La entidad revision debe ser de tipo CRevision.");

                iRevision = (CRevision)revision;

                parametros = FabricaDAO.asignarListaDeParametro();
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionID, SqlDbType.Int, $"{iRevision._id}", false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionMensaje, SqlDbType.VarChar, iRevision.Mensaje.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionTipo, SqlDbType.Int, $"{(int)iRevision.Tipo}", false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionPuntuacion, SqlDbType.Int, $"{iRevision.Puntuacion}", false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionIDUsuario, SqlDbType.Int, $"{iRevision.Usuario._id}", false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroReferencia, SqlDbType.Int, $"{iRevision.Referencia._id}", false));                
                
                EjecutarStoredProcedure(RecursoDAOM20.procedimientoGuardarRevision, parametros);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AplicarValoracion(Entidad revision)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}