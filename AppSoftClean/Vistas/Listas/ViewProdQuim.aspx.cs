using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using AppSoftClean.Data.Recursos;
using AppSoftClean.Web.Control;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSoftClean.Vistas.Listas
{
    public partial class ViewProdQuim : System.Web.UI.Page
    {
        [Dependency]
        public IProdQuimRepository prodQuimRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillGridViewData();
            }
        }

        private void FillGridViewData()
        {
            List<AdmProdQuim> prodQuim = prodQuimRepository.GetAllQuimicos();
            this.dgvDatos.getCatalog(prodQuim);
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.FormProdQuim + 0);
        }

        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string idObjeto;
            switch (e.CommandName)
            {
                case "Editar":
                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    Response.Redirect(direcciones.FormProdQuim + idObjeto);
                    break;
                case "Eliminar":
                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModaldata();", true);
                    AdmProdQuim admProdQuim = prodQuimRepository.GetQuimicoByID(int.Parse(idObjeto)).First();
                    lblID.Text = String.Concat(admProdQuim.id);
                    lblQuimico.Text = admProdQuim.Quimico;
                    break;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            string idObjeto = this.lblID.Text;
            if (prodQuimRepository.EliminarQuimico(int.Parse(idObjeto)))
            {
                Response.Redirect(direcciones.ViewProdQuim);
            }
        }
    }
}