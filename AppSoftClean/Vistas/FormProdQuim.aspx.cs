using AppSoftClean.Data.Model;
using AppSoftClean.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSoftClean.Vistas
{
    public partial class FormProdQuim : System.Web.UI.Page
    {

        private RepositoryProdQuim REP = new RepositoryProdQuim();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) this.eleccionCargaDeDatos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AdmProdQuim equipoObj = this.GetViewData();

            if (this.lblAccion.Text.ToString() == "Actualizar")
            {
                equipoObj.IdAdmProdQuim = Int32.Parse(Request.QueryString["id"]);
                this.actualizarParametros(equipoObj);
            }
            else
            {
                this.insertarParametros(equipoObj);
            }
        }

        protected AdmProdQuim GetViewData()
        {
            AdmProdQuim equipoObj = new AdmProdQuim
            {
                Quimico = TextQuimico.Text,
                Stock = Int32.Parse(TextStock.Text),
                IdAreaUso = Int32.Parse(DDL_AreaUso.SelectedValue)
            };

            return equipoObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AdmProdQuim equipoObj = new AdmProdQuim();

            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                equipoObj = REP.GetQuimicoByID(id).First();

                TextQuimico.Text = equipoObj.Quimico.ToString();
                TextStock.Text = equipoObj.Stock.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }

        protected void insertarParametros(AdmProdQuim equipoObj)
        {
            if (REP.InsertarQuimico(equipoObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AdmProdQuim equipoObj)
        {
            if (REP.ActualizarQuimico(equipoObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void popupTodoBien()
        {
            string vtn = "window.open('../Vistas/popupSuccesful.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void popupNadaBien()
        {
            string vtn = "window.open('../Vistas/popupFailed.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }
    }
}