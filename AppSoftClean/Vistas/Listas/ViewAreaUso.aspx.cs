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

namespace AppSoftClean.Vistas.PantallasDePrueba
{
    public partial class ViewAreaUso : System.Web.UI.Page
    {

        [Dependency]
        public IAreaUsoRepository areausoRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillGridViewArea();
            }
        }

        private void FillGridViewArea()
        {
            List<AreaUso> area = areausoRepository.GetAllAreasUso();
            this.dgvDatos.getCatalog(area);
        }


        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string idArea;
            switch (e.CommandName)
            {
                case "Editar":
                    idArea = dgvDatos.Rows[index].Cells[0].Text;
                    Response.Redirect(direcciones.FormAreaUso + idArea);
                    break;
                case "Eliminar":
                    idArea = dgvDatos.Rows[index].Cells[0].Text;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModaldata();", true);
                    AreaUso areaUso = areausoRepository.GetAreaUsoByID(int.Parse(idArea)).First();
                    lblID.Text = String.Concat(areaUso.id);
                    lblArea.Text = areaUso.Area;
                    break;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            string idArea = this.lblID.Text;
            if (areausoRepository.EliminarAreaUso(int.Parse(idArea))){
                Response.Redirect(direcciones.ViewAreaUso);
            }
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.FormAreaUso + 0);
        }
    }
}