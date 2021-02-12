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
    public partial class ViewDosEstLim : System.Web.UI.Page
    {

        [Dependency]
        public IDosEstLimRepository dosEstLimRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillGridViewDosEstLim();
            }
        }

        private void FillGridViewDosEstLim()
        {
            List<AdmDosEstLim> dosestlim = dosEstLimRepository.GetAllEstaciones();
            this.dgvDatos.getCatalog(dosestlim);
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.FormDosEstLim + 0);
        }

        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string idObjeto;
            switch (e.CommandName)
            {
                case "Editar":
                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    Response.Redirect(direcciones.FormDosEstLim + idObjeto);
                    break;
                case "Eliminar":
                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModaldata();", true);
                    AdmDosEstLim admDosEstLim = dosEstLimRepository.GetEstacionesByID(int.Parse(idObjeto)).First();
                    lblID.Text = String.Concat(admDosEstLim.id);
                    lblDosEstLim.Text = admDosEstLim.DosEstLimp;
                    break;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            string idObjeto = this.lblID.Text;
            if (dosEstLimRepository.EliminarEstacion(int.Parse(idObjeto)))
            {
                Response.Redirect(direcciones.ViewDosEstLim);
            }
        }
    }
}