using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
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
    public partial class ViewLevantamientoEquipos : System.Web.UI.Page
    {

        [Dependency]
        public ILevantamientoEquiposRepository levantamientoEquiposRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillGridViewData();
                FillDropDownListDivisiones();
            }
        }

        private void FillDropDownListDivisiones()
        {
            this.DDL_Divisiones.getCatalogoDivisiones();
        }

        private void FillGridViewData()
        {
            List<LevantamientoEquipos> levantamientoEquipos = levantamientoEquiposRepository.GetAllLevantamientos();
            this.dgvDatos.getCatalog(levantamientoEquipos );
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModalCreate();", true);
        }

        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "Editar":
                    
                    break;
                case "Eliminar":
                   
                    break;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Modal_Click(object sender, EventArgs e)
        {

        }
    }
}