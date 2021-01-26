using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using AppSoftClean.Data.Recursos;
using AppSoftClean.Data.Repository;
using AppSoftClean.Web.Control;
using AppSoftClean.Web.Session;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSoftClean
{
    public partial class login : System.Web.UI.Page
    {
        [Dependency]
        public IUsuariosRepository usuarioRepository { get; set; }
        private SessionManager sessionManager = null;
        private usuarios usuarios = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = TextUser.Text;
            string contrasena = TextPass.Text;

            this.usuarios = usuarioRepository.GetUsuariosLogin(usuario, contrasena);
            if(this.usuarios != null)
            {
                this.sessionManager = new SessionManager();
                this.sessionManager.IdUsuarios = this.usuarios.id;
                this.sessionManager.Parametros["usuario"] = this.usuarios;
                Session["manager"] = sessionManager;
                lblEstado.Text = "Accediste";
            }

        }
    }
}