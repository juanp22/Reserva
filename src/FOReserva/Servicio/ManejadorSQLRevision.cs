﻿using System;
using System.Collections.Generic;
using System.Linq;
using FOReserva.Models.Revision;
using System.Data.SqlClient;
using FOReserva.Models.Restaurantes;


namespace FOReserva.Servicio
{
    public class ManejadorSQLRevision : manejadorSQL
    {

        public ManejadorSQLRevision() : base() { }


        public List<CRevision> Consultar_Revision(string nombre, string apellido)
        {

            string query = "SELECT us.usu_id, us.usu_activo, rev.rev_fecha, rev.rev_mensaje, rev.rev_tipo, rev.rev_puntuacion, val.rv_val_pos, val.rv_val_neg FROM Revision as rev, Revision_Valoracion as val, Usuario as us where val.rv_id=rev.rev_FK_rev_val_id and LOWER(us.usu_nombre) LIKE LOWER('%" + nombre + "%') and LOWER(us.usu_apellido) LIKE LOWER('%" + apellido + "%') and rev.rev_FK_usu_id=us.usu_id";
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    DateTime _fecha = read.GetDateTime(0);
                    string _mensaje = read.GetString(1);
                    int _tipo = read.GetInt32(2);
                    int _puntuacion = read.GetInt32(3);
                    // int _valoracion = read.GetInt32(4);
                    CRevision rev = new CRevision();
                    // CRevisionValoracion reva = new CRevisionValoracion();
                    rev.Fecha = _fecha;
                    rev.Mensaje = _mensaje;
                    rev.Tipo = _tipo;
                    rev.Puntuacion = _puntuacion;
                    //  reva. = _valoracion;
                    lista_rev.Add(rev);


                }
            }

            CloseConnection();
            return lista_rev;
        }

        public bool Eliminar_Revision(string nombre, string apellido, int revision)
        {
            string query = "DELETE FROM Reserva_Restaurante ( Reserva_Nombre, Fecha, Hora,Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) VALUES( )";
            this.Executer(query);
            CloseConnection();
            return true;
        }

        public bool Crear_Revision(string nombre, string apellido)
        {
            string query = "INSERT INTO Reserva_Restaurante ( Reserva_Nombre, Fecha, Hora,Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) VALUES( )";
            this.Executer(query);
            CloseConnection();
            return true;
        }

        public List<CRevision> Mostrar_Revision_Restaurant(string nombre, string apellido, int tipo)
        {

            string query = "SELECT us.usu_id, us.usu_activo, rev.rev_fecha, rev.rev_mensaje, rev.rev_tipo, rev.rev_puntuacion, val.rv_val_pos, val.rv_val_neg FROM Revision as rev, Revision_Valoracion as val, Usuario as us, Reserva_Restaurante as rest where val.rv_id=rev.rev_FK_rev_val_id and LOWER(us.usu_nombre) LIKE LOWER('%" + nombre + "%') and LOWER(us.usu_apellido) LIKE LOWER('%" + apellido + "%') and rev.rev_FK_usu_id=us.usu_id and  rest.FK_USUARIO=us.usu_id and rest.FK_RESTAURANTE=rev.rev_FK_res_res_id ";
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    DateTime _fecha = read.GetDateTime(0);
                    string _mensaje = read.GetString(1);
                    int _tipo = read.GetInt32(2);
                    int _puntuacion = read.GetInt32(3);
                    // int _valoracion = read.GetInt32(4);
                    CRevision rev = new CRevision();
                    // CRevisionValoracion reva = new CRevisionValoracion();
                    rev.Fecha = _fecha;
                    rev.Mensaje = _mensaje;
                    rev.Tipo = _tipo;
                    rev.Puntuacion = _puntuacion;
                    //  reva. = _valoracion;
                    lista_rev.Add(rev);


                }
            }

            CloseConnection();
            return lista_rev;
        }

        public List<CRevision> Mostrar_Revision_Hotel(string nombre, string apellido, int tipo)
        {

            string query = "SELECT us.usu_id, us.usu_activo, rev.rev_fecha, rev.rev_mensaje, rev.rev_tipo, rev.rev_puntuacion, val.rv_val_pos, val.rv_val_neg FROM Revision as rev, Revision_Valoracion as val, Usuario as us, Reserva_Habitacion as hot where val.rv_id=rev.rev_FK_rev_val_id and LOWER(us.usu_nombre) LIKE LOWER('%" + nombre + "%') and LOWER(us.usu_apellido) LIKE LOWER('%" + apellido + "%') and rev.rev_FK_usu_id=us.usu_id AND hot.rha_fk_usu_id=us.usu_id and hot.rha_id=rev.rev_FK_res_hot_id;";
            SqlDataReader read = Executer(query);
            List<CRevision> lista_rev = new List<CRevision>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    DateTime _fecha = read.GetDateTime(0);
                    string _mensaje = read.GetString(1);
                    int _tipo = read.GetInt32(2);
                    int _puntuacion = read.GetInt32(3);
                    // int _valoracion = read.GetInt32(4);
                    CRevision rev = new CRevision();
                    // CRevisionValoracion reva = new CRevisionValoracion();
                    rev.Fecha = _fecha;
                    rev.Mensaje = _mensaje;
                    rev.Tipo = _tipo;
                    rev.Puntuacion = _puntuacion;
                    //  reva. = _valoracion;
                    lista_rev.Add(rev);


                }
            }

            CloseConnection();
            return lista_rev;
        }

        public bool Editar_Revision(string nombre, string apellido, int revision)
        {
            string query = "INSERT INTO Reserva_Restaurante ( Reserva_Nombre, Fecha, Hora,Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) VALUES( )";
            this.Executer(query);
            CloseConnection();
            return true;
        }


    }
}

