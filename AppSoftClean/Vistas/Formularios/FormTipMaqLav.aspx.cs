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
    public partial class FormTipMaqLav : System.Web.UI.Page
    {

        private RepositoryTipMaqLav REP = new RepositoryTipMaqLav();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) this.eleccionCargaDeDatos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AdmTipMaqLav equipoObj = this.GetViewData();

            if (this.lblAccion.Text.ToString() == "Actualizar")
            {
                equipoObj.id = Int32.Parse(Request.QueryString["id"]);
                this.actualizarParametros(equipoObj);
            }
            else
            {
                this.insertarParametros(equipoObj);
            }
        }

        protected AdmTipMaqLav GetViewData()
        {
            AdmTipMaqLav equipoObj = new AdmTipMaqLav
            {
                Tipo = TextTipo.Text,
                Stock = Int32.Parse(TextStock.Text),
            };

            return equipoObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AdmTipMaqLav equipoObj = new AdmTipMaqLav();

            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                equipoObj = REP.GetLavavajillasByID(id).First();

                TextTipo.Text = equipoObj.Tipo.ToString();
                TextStock.Text = equipoObj.Stock.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }

        protected void insertarParametros(AdmTipMaqLav equipoObj)
        {
            if (REP.InsertarLavavajillas(equipoObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AdmTipMaqLav equipoObj)
        {
            if (REP.ActualizarLavavajillas(equipoObj))
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