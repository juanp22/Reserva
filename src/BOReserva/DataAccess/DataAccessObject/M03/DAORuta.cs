﻿using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.DataAccess.Domain;
using System.Data;

namespace BOReserva.DataAccess.DataAccessObject.M03
{
    public class DAORuta : DAO, IDAORuta
    {

        public DAORuta() { }
        public Dictionary<int, Entidad> MListarRutasBD()
        {
            List<CRuta> listarutas = new List<CRuta>();
            Dictionary<int, Entidad> listarRutas = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "SELECT r.rut_id as IRuta, lO.lug_nombre as PaisO, lD.lug_nombre as PaisD,  a.lug_nombre AS NOrigen,b.lug_nombre AS NDestino,r.rut_tipo_ruta AS TRuta,r.rut_distancia AS DRuta,r.rut_status_ruta AS SRuta FROM Ruta r, Lugar a, Lugar b, Lugar lO, Lugar lD WHERE r.rut_FK_lugar_origen=a.lug_id AND r.rut_FK_lugar_destino=b.lug_id AND a.lug_FK_lugar_id=lO.lug_id AND b.lug_FK_lugar_id=lD.lug_id";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO RUTA SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Rutas>"]
                        //Y  SE AGREGA a listarutas
                        Ruta ruta = new Ruta(Int32.Parse(reader["IRuta"].ToString()), Int32.Parse(reader["DRuta"].ToString()), reader["SRuta"].ToString(), reader["TRuta"].ToString(),
                            reader["NOrigen"].ToString() + " - " + reader["PaisO"].ToString(), reader["NDestino"].ToString() + " - " + reader["PaisD"].ToString());
                        listarRutas.Add(ruta._idRuta,ruta);
                    }
                }
                conexion.Close();
                return listarRutas;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                throw ex;
            }
        }
        public Boolean ValidarRuta(Entidad e)
        {
            Ruta ruta = (Ruta)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {

                String[] strDes = ruta._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
                String[] strOri = ruta._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);


                conexion.Open();

                SqlCommand query = new SqlCommand("M03_ValidarRuta", conexion);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add("@ciudadOrigenRuta", SqlDbType.VarChar).Value = strOri[0];
                query.Parameters.Add("@paisOrigenRuta", SqlDbType.VarChar).Value = strOri[1];
                query.Parameters.Add("@ciudadDestinoRuta", SqlDbType.VarChar).Value = strDes[0];
                query.Parameters.Add("@paisDestinoRuta", SqlDbType.VarChar).Value = strDes[1];
                query.Parameters.Add("@tipoRuta", SqlDbType.VarChar).Value = ruta._tipo;

                query.ExecuteNonQuery();

                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();


                if (!lector.HasRows)
                {
                    conexion.Close();
                    lector.Close();
                    return true;

                }
                else
                {
                    conexion.Close();
                    lector.Close();
                    return false;
                }

                


            }
            catch (SqlException ex)
            {
                conexion.Close();
                throw ex;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean habilitarRuta(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                //Inicializo la conexion con el string de conexion
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Ruta SET rut_status_ruta='Activa' where rut_id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                conexion.Close();
                return true;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Boolean deshabilitarRuta(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Ruta SET rut_status_ruta='Inactiva' where rut_id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                conexion.Close();
                return true;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Dictionary<int, Entidad> listarLugares()
        {

            List<String> lugares = new List<String>();
            Dictionary<int, Entidad> listaLugares = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection conexion = Connection.getInstance(_connexionString);
            String lugar;
            try
            {
                //Inicializo la conexion con el string de conexion
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT l.lug_nombre as ciudad, ll.lug_nombre as pais, l.lug_id as idlugar from Lugar l, Lugar ll where l.lug_FK_lugar_id = ll.lug_id ";

                SqlCommand cmd = new SqlCommand(query, conexion);


                SqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    lugar = lector["ciudad"].ToString() + " - " + lector["pais"].ToString();
                    int id = Int32.Parse(lector["idlugar"].ToString());
                    Ciudad lugarO = new Ciudad();
                    lugarO._nombre = lugar;
                    lugarO._id = id;

                    listaLugares.Add(lugarO._id,lugarO);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listaLugares;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Dictionary<int, Entidad> consultarDestinos()
        {
            var lugares = new List<String>();
            Dictionary<int, Entidad> listaDestinos = new Dictionary<int, Entidad>();
            SqlConnection conexion = Connection.getInstance(_connexionString);
            String lugar;
            try
            {
                //Inicializo la conexion con el string de conexion
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT l.lug_nombre as ciudad, ll.lug_nombre as pais, l.lug_id as idciudad from Lugar l, Lugar ll where l.lug_FK_lugar_id = ll.lug_id ";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    lugar = lector["ciudad"].ToString() + " - " + lector["pais"].ToString();

                    lugares.Add(lugar);
                    int id = Int32.Parse(lector["idciudad"].ToString());
                    Ciudad lugarD = new Ciudad();
                    lugarD._nombre = lugar;
                    lugarD._id = id;

                    listaDestinos.Add(lugarD._id, lugarD);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listaDestinos;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Entidad MMostrarRutaBD(int idRuta)
        {
            Ruta ruta = new Ruta();
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "SELECT a.lug_nombre AS NOrigen, lO.lug_nombre as PaisO, lD.lug_nombre as PaisD,b.lug_nombre AS NDestino,r.rut_tipo_ruta AS TRuta,r.rut_distancia AS DRuta,r.rut_status_ruta AS SRuta FROM Ruta r, Lugar a, Lugar b, Lugar lO, Lugar lD WHERE r.rut_FK_lugar_origen=a.lug_id AND r.rut_FK_lugar_destino=b.lug_id AND a.lug_FK_lugar_id=lO.lug_id AND b.lug_FK_lugar_id=lD.lug_id AND r.rut_id = '" + idRuta + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ruta._idRuta = idRuta;
                        ruta._origenRuta = reader["NOrigen"].ToString() + " - " + reader["PaisO"].ToString();
                        ruta._destinoRuta = reader["NDestino"].ToString() + " - " + reader["PaisD"].ToString();
                        ruta._status = reader["SRuta"].ToString();
                        ruta._tipo = reader["TRuta"].ToString();
                        ruta._distancia = Int32.Parse(reader["DRuta"].ToString());
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return ruta;
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                throw ex;
            }
        }
        int IDAO.Agregar(Entidad e)
        {
            Ruta ruta = (Ruta)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            IDAORuta rutas = new DAORuta();
            try
            {

                String[] strDes = ruta._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
                String[] strOri = ruta._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);



                if (rutas.ValidarRuta(ruta))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("M03_AgregarRuta", conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ciudadOrigenRuta", System.Data.SqlDbType.VarChar, 100);
                    cmd.Parameters["@ciudadOrigenRuta"].Value = strOri[0];
                    cmd.Parameters.Add("@paisOrigenRuta", System.Data.SqlDbType.VarChar, 100);
                    cmd.Parameters["@paisOrigenRuta"].Value = strOri[1];
                    cmd.Parameters.Add("@ciudadDestinoRuta", System.Data.SqlDbType.VarChar, 100);
                    cmd.Parameters["@ciudadDestinoRuta"].Value = strDes[0];
                    cmd.Parameters.Add("@paisDestinoRuta", System.Data.SqlDbType.VarChar, 100);
                    cmd.Parameters["@paisDestinoRuta"].Value = strDes[1];
                    cmd.Parameters.Add("@tipoRuta", System.Data.SqlDbType.VarChar, 10);
                    cmd.Parameters["@tipoRuta"].Value = ruta._tipo;
                    cmd.Parameters.Add("@estadoRuta", System.Data.SqlDbType.VarChar, 10);
                    cmd.Parameters["@estadoRuta"].Value = ruta._status;
                    cmd.Parameters.Add("@distanciaRuta", System.Data.SqlDbType.Int, 100);
                    cmd.Parameters["@distanciaRuta"].Value = ruta._distancia;

                    SqlDataReader lector = cmd.ExecuteReader();


                  

                    lector.Close();
                    conexion.Close();

                    return 1;
                }
                return 2;

            }
            catch (SqlException ex)
            {
                return 3;
                throw ex;
            }
            catch (Exception ex)
            {
                return 4;
                throw ex;
            }
        }
        public Boolean MModificarRuta(Entidad e)
        {
            Ruta ruta = (Ruta)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                String status = ruta._status;
                int distancia = ruta._distancia;
                int id = ruta._idRuta;

                conexion.Open();
                String query = "UPDATE Ruta Set rut_status_ruta = '" + status + "', rut_distancia = " + distancia + " where rut_id = " + id;
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();

                lector.Close();
                conexion.Close();
                return true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}