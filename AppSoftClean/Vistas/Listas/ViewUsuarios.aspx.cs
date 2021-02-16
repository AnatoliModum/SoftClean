using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using AppSoftClean.Data.Recursos;
using AppSoftClean.Data.Repository;
using AppSoftClean.Web.Control;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AppSoftClean.Vistas.Listas
{
    public partial class ViewUsuarios : System.Web.UI.Page
    {
        private RepositoryLevantamientoEquipos REP = new RepositoryLevantamientoEquipos();
        private RepositoryUsuarios RU = new RepositoryUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillGridViewData();
                FillDropDownListCategorias();
            }
        }
        
        private void FillDropDownListCategorias()
        {
            this.DDL_Categorias.getCatalogoCategorias();
        }
        
        private void FillGridViewData()
        {
            List<Usuarios> usuariosList = RU.GetAllUsuarios();
            this.dgvDatos.getCatalog(usuariosList);
        }
      
        #region Evento para Mostrar el Modal Crear
        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            btnCrear_Modal.Text = "Crear";
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModalCreate();", true);
        }
        #endregion

        #region Evento editar y eliminar de DGV
        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string idObjeto;
            switch (e.CommandName)
            {
                case "Editar":

                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;

                    Session["idObjeto"] = idObjeto;
                    Usuarios usuario = RU.GetUsuarioByID(Int32.Parse(idObjeto)).First();

                    this.DDL_Categorias.SelectedValue = usuario.idCategoria > 0 ?usuario.idCategoria.ToString(): null;
                    this.TextUser.Text = usuario.usuario;
                    this.TextCorreo.Text = usuario.correo;

                    btnCrear_Modal.Text = "Actualizar";

                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModalCreate();", true);
                    break;
                case "Eliminar":
                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    Session["idDelete"] = idObjeto;
                    Usuarios usuario2 = RU.GetUsuarioByID(int.Parse(idObjeto)).First();

                    this.lblID.Text = usuario2.id.ToString();
                    this.lblUsuario.Text = usuario2.usuario;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModaldata();", true);
                    break;
            }
        }
        #endregion

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {

            int idObjeto = int.Parse(Session["idDelete"].ToString());
           

            if (idObjeto > 0)
            {
                if (RU.EliminarUsuario(idObjeto))
                {
                    Response.Redirect(direcciones.ViewUsuarios);
                }
            }
            
        }

        #region Evento para Guardar Registros
        protected void btnCrear_Modal_Click(object sender, EventArgs e)
        {
            if (DDL_Categorias.Text == "Selecciona una Categoria")
            {
                lblErrorDDL.Visible = true;
                lblMargen.Visible = false;
                this.UpdateValidacionModal.Update();
            }
            else
            {
                Usuarios userNew = new Usuarios();

                userNew.usuario = TextUser.Text;
                userNew.contrasenia =  RU.EncryptarContrasena(TextPassword.Text);
                userNew.idCategoria = Int32.Parse(DDL_Categorias.SelectedValue.ToString());
                userNew.correo = this.TextCorreo.Text;

                userNew.id =Session["idObjeto"]!=null?int.Parse(Session["idObjeto"].ToString()):0;
                if (userNew.id > 0 && btnCrear_Modal.Text == "Actualizar")
                {
                    RU.ActualizarUsuario(userNew);
                }
                else
                {
                    RU.InsertarUsuario(userNew);
                }
                Response.Redirect(direcciones.ViewUsuarios);
            }
        }
        #endregion
        
        #region Evento de Cambio de Selección DropDownList
        protected void DDL_Categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_Categorias.Text == "Selecciona una Categoria")
            {
                lblErrorDDL.Visible = true;
                lblMargen.Visible = false;
            }
            else
            {
                lblErrorDDL.Visible = false;
                lblMargen.Visible = true;
            }
            this.UpdateValidacion.Update();
        }
        #endregion
        
    }
}