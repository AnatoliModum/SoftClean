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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModalCreate();", true);
        }

        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void DDL_AreasInstalacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}