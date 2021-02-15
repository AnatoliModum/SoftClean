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
                    //idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    //Response.Redirect(direcciones.ViewLevantamientoEquipos + idObjeto);
                    break;
                case "Eliminar":
                    //idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModaldata();", true);
                    //LevantamientoEquipos levantamientoEquipos = levantamientoEquiposRepository.GetLevantamientoByID(int.Parse(idObjeto)).First();
                    //lblID.Text = String.Concat(levantamientoEquipos.id);
                    //lblFecha.Text = Convert.ToDateTime(levantamientoEquipos.dteFecha.ToString()).ToString("dd/MM/yyyy");
                    break;
            }
        }
        #endregion

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            //string idObjeto = this.lblID.Text;
            //if (levantamientoEquiposRepository.EliminarLevantamiento(int.Parse(idObjeto)))
            //{
            //    Response.Redirect(direcciones.ViewListaLevantamiento);
            //}
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
                userNew.contrasenia = TextPassword.Text;
                userNew.idCategoria = Int32.Parse(DDL_Categorias.SelectedValue.ToString());

                RU.InsertarUsuario(userNew);
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