using AppSoftClean.Data.Model;
using AppSoftClean.Data.Recursos;
using AppSoftClean.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSoftClean.Vistas
{
    public partial class FormDosEstLim : System.Web.UI.Page
    {
        private RepositoryDosEstLimp REP = new RepositoryDosEstLimp();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.eleccionCargaDeDatos();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AdmDosEstLim estacionObj = this.GetViewData();

            if (this.lblAccion.Text.ToString() == "Actualizar")
            {
                estacionObj.id = Int32.Parse(Request.QueryString["id"]);
                this.actualizarParametros(estacionObj);
                Response.Redirect(direcciones.ViewDosEstLim);
            }
            else
            {
                this.insertarParametros(estacionObj);
                Response.Redirect(direcciones.ViewDosEstLim);
            }
        }

        protected AdmDosEstLim GetViewData()
        {
            AdmDosEstLim dosificadorObj = new AdmDosEstLim
            {
                DosEstLimp = TextDosEstLim.Text,
                EqDisponibles = Int32.Parse(TextEquiDis.Text)
            };

            return dosificadorObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AdmDosEstLim estacionObj = new AdmDosEstLim();

            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                estacionObj = REP.GetEstacionesByID(id).First();

                TextDosEstLim.Text = estacionObj.DosEstLimp.ToString();
                TextEquiDis.Text = estacionObj.EqDisponibles.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }

        protected void insertarParametros(AdmDosEstLim estacionObj)
        {
            if (REP.InsertarEstacion(estacionObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AdmDosEstLim estacionObj)
        {
            if (REP.ActualizarEstacion(estacionObj))
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.ViewDosEstLim);
        }
    }
}