using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
using BOReserva.Models.gestion_usuarios;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando.M12;
using BOReserva.Controllers.PatronComando;
using BOReserva.Controllers;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M12;
using System.Web.Mvc;



namespace TestUnitReserva.BO.gestion_usuarios
{
    [TestFixture]
    public class TestUsuario
    {
        //#region Atributos

        //public CUsuario elUsuario;
        //List<ListarUsuario> lista;
        //PersistenciaUsuario prueba;
        //int id;
        //ListarUsuario liastarusu;
        //bool revision;

        //#endregion

        //#region SetUp And TearDown
        ///// <summary>
        ///// SetUp para las pruebas de DAOUsuario
        ///// </summary>
        //[SetUp]
        //public void init()
        //{
        //    // BOReserva.Models.gestion_usuarios.
        //    elUsuario = new CUsuario("nombre", "apellido", "contraseņa456", "correosssssss@gmail.com", "activo", 1);
        //    prueba = new PersistenciaUsuario();
        //    liastarusu = new ListarUsuario();
        //}

        ///// <summary>
        ///// TearDown para las pruebas de DAOUsuario
        ///// </summary>
        //[TearDown]
        //public void clean()
        //{
        //    elUsuario = null;
        //    prueba = null;
        //    lista = null;
        //}
        //#endregion
        //#region Test
        //[Test]
        //public void TestListar()
        //{
        //    lista = prueba.ListaUsuarios();
        //    Assert.IsNotNull(lista);
        //}

        //[Test]
        //public void TestModificar()
        //{
        //    bool primero = prueba.AgregarUsuario(elUsuario);
        //    CUsuario elUsuario2 = new CUsuario("hola", "cambio", "1234678tghfhf", "correosssssss@gmail.com", "activo", 1);
        //    id = prueba.ultimoUsuarioID();
        //    bool segundo = prueba.ModificarUsuario(elUsuario2, id);
        //    CUsuario elUsuario3 = prueba.consultarUsuario(id);
        //    Assert.AreEqual(elUsuario2.nombreUsuario, elUsuario3.nombreUsuario);
        //    Assert.AreEqual(elUsuario2.correoUsuario, elUsuario3.correoUsuario);
        //    Assert.AreEqual(elUsuario2.apellidoUsuario, elUsuario3.apellidoUsuario);
        //    Assert.AreEqual(elUsuario2.activoUsuario, elUsuario3.activoUsuario);
        //    revision = prueba.eliminarUsuario(id);
        //}

        //[Test]
        //public void TestAgregar()
        //{
        //    int numero1 = prueba.contarUsuario();
        //    revision = prueba.AgregarUsuario(elUsuario);
        //    int numero2 = prueba.contarUsuario();
        //    Assert.AreEqual(numero1+1,numero2);
        //    id = prueba.ultimoUsuarioID();
        //    revision = prueba.eliminarUsuario(id);
        //}
        //[Test]
        //public void TestBorrar()
        //{
        //    int numero1 = prueba.contarUsuario();
        //    bool primero = prueba.AgregarUsuario(elUsuario);
        //    id = prueba.ultimoUsuarioID();
        //    bool segundo = prueba.eliminarUsuario(id);
        //    int numero2 = prueba.contarUsuario();
        //    Assert.AreEqual(numero1,numero2);
        //}
        //[Test]
        //public void TestConsultar()
        //{
        //    revision = prueba.AgregarUsuario(elUsuario);
        //    id = prueba.ultimoUsuarioID();
        //    elUsuario = prueba.consultarUsuario(id);
        //    Assert.IsNotNull(elUsuario);
        //    Assert.IsNotNull(elUsuario.apellidoUsuario);
        //    Assert.IsNotNull(elUsuario.correoUsuario);
        //    Assert.IsNotNull(elUsuario.nombreUsuario);
        //    revision = prueba.eliminarUsuario(id);
        //}
        //#endregion

    //    private Usuario mockUsuario;
    //    private Usuario mockUsuario2;
    //    private Rol mockRol;


    //    IDAO prueba;
    //    DAOUsuario daoUsuario;

    //    BOReserva.Controllers.gestion_usuariosController controlador = new BOReserva.Controllers.gestion_usuariosController();

    //    [SetUp]
    //    public void Before()
    //    {

    //        mockRol = new Rol(1, "Administrador");
    //        mockUsuario = new Usuario("Ana", "Duran", "ana@reserva.com", "12345a", mockRol, System.DateTime.Parse("yyyy-MM-dd"), "Activo");
    //        mockUsuario2 = new Usuario(999, "Ana", "Duran", "ana@reserva.com", "12345a", mockRol, System.DateTime.Parse("yyyy-MM-dd"), "Activo");

    //        daoUsuario = new DAOUsuario();



    //    }

    //    [TearDown]
    //    public void After()
    //    {
    //        mockUsuario = null;
    //        mockUsuario2 = null;
    //        mockRol = null;
    //    }

    //    [Test]
    //    public void M12_DaoUsuarioInsertarUsuario()
    //    {
    //        //Probando caso de exito de la prueba
    //        int resultadoAgregar = daoUsuario.Agregar(mockUsuario);
    //        Assert.AreEqual(resultadoAgregar, 1);
    //        //Probando caso de fallo
    //        int resultadoAgregarIncorrecto = daoUsuario.Agregar(null);
    //        Assert.AreEqual(resultadoAgregarIncorrecto, 0);
    //    }

    }
}
