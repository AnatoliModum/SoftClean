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
    public partial class FormPorGalon : System.Web.UI.Page
    {

        private RepositoryPortGalon REP = new RepositoryPortGalon();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) this.eleccionCargaDeDatos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AdmPortGalon equipoObj = this.GetViewData();

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

        protected AdmPortGalon GetViewData()
        {
            AdmPortGalon equipoObj = new AdmPortGalon
            {
                Tipo = TextTipo.Text,
                Stock = Int32.Parse(TextStock.Text)
            };

            return equipoObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AdmPortGalon equipoObj = new AdmPortGalon();

            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                equipoObj = REP.GetGaloneraByID(id).First();

                TextTipo.Text = equipoObj.Tipo.ToString();
                TextStock.Text = equipoObj.Stock.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }

        protected void insertarParametros(AdmPortGalon equipoObj)
        {
            if (REP.InsertarGalonera(equipoObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AdmPortGalon equipoObj)
        {
            if (REP.ActualizarGalonera(equipoObj))
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