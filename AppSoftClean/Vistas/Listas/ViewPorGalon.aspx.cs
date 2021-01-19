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
    public partial class ViewPorGalon : System.Web.UI.Page
    {

        [Dependency]
        public IPortGalonRepository portGalonRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillGridViewData();
            }
        }

        private void FillGridViewData()
        {
            List<AdmPortGalon> portgalon = portGalonRepository.GetAllGaloneras();
            this.dgvDatos.getCatalog(portgalon);
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.FormPortGalon + 0);
        }

        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string idObjeto;
            switch (e.CommandName)
            {
                case "Editar":
                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    Response.Redirect(direcciones.FormPortGalon + idObjeto);
                    break;
                case "Eliminar":
                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModaldata();", true);
                    AdmPortGalon admPortGalon = portGalonRepository.GetGaloneraByID(int.Parse(idObjeto)).First();
                    lblID.Text = String.Concat(admPortGalon.id);
                    lblTipo.Text = admPortGalon.Tipo;
                    break;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            string idObjeto = this.lblID.Text;
            if (portGalonRepository.EliminarGalonera(int.Parse(idObjeto)))
            {
                Response.Redirect(direcciones.ViewPortGalon);
            }
        }
    }
}