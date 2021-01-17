using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSoftClean.Vistas.PantallasDePrueba
{
    public partial class testCepInBas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccion_Click(object sender, EventArgs e)
        {
            int id;

            if (txtId.Text.ToString() == "")
            {
                id = 0;
            }
            else
            {
                id = Int32.Parse(txtId.Text.ToString());
            }

            Response.Redirect("../FormCepInBas.aspx?id=" + id);
        }

    }
}