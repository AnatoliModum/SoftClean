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
    public partial class ViewDivisiones : System.Web.UI.Page
    {

        [Dependency]
        public IDivisionesRepository divisionesRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillGridViewData();
            }
        }

        private void FillGridViewData()
        {
            List<AdmDivisiones> divisiones = divisionesRepository.GetAllDivisiones();
            this.dgvDatos.getCatalog(divisiones);
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.FormDivisiones + 0);
        }

        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string idDivision;
            switch (e.CommandName)
            {
                case "Editar":
                    idDivision = dgvDatos.Rows[index].Cells[0].Text;
                    Response.Redirect(direcciones.FormDivisiones + idDivision);
                    break;
                case "Eliminar":
                    idDivision = dgvDatos.Rows[index].Cells[0].Text;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModaldata();", true);
                    AdmDivisiones divisiones = divisionesRepository.GetDivisionesByID(int.Parse(idDivision)).First();
                    lblID.Text = String.Concat(divisiones.id);
                    lblNombre.Text = divisiones.Nombre;
                    break;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            string idArea = this.lblID.Text;
            if (divisionesRepository.EliminarDivision(int.Parse(idArea)))
            {
                Response.Redirect(direcciones.ViewDivisiones);
            }
        }
    }
}