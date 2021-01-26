using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using AppSoftClean.Data.Recursos;
using AppSoftClean.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSoftClean.Web.Control;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.CompilerServices;

namespace AppSoftClean.Data.Repository.Tests
{
    [TestClass()]
    public class RepositoryUsuariosPruebasDeUsuarios
    {
        [TestMethod()]
        public void LogeoDeUsuarioTest()
        {
           
            RepositoryUsuarios RU = new RepositoryUsuarios();
            usuarios user = new usuarios();
            string result;

            user.usuario = "Pepe";
            user.contrasenia = "pepillo";

            if (RU.LogeoDeUsuario(user))
            {
                result = "Exito jaja";

            }else
            {
                result = "Fallo :( ";
            }

            Assert.AreEqual("Exito jaja", result);
        }
    }
}