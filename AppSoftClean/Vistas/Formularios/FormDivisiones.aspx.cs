using AppSoftClean.Data.Model;
using AppSoftClean.Data.Recursos;
using AppSoftClean.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSoftClean.Vistas.Formularios
{
    public partial class FormDivisiones : System.Web.UI.Page
    {

        private RepositoryDivisiones REP = new RepositoryDivisiones();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) this.eleccionCargaDeDatos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AdmDivisiones dosificadorObj = this.GetViewData();

            if (this.lblAccion.Text.ToString() == "Actualizar")
            {
                dosificadorObj.id = Int32.Parse(Request.QueryString["id"]);
                this.actualizarParametros(dosificadorObj);
                Response.Redirect(direcciones.ViewDivisiones);
            }
            else
            {
                this.insertarParametros(dosificadorObj);
                Response.Redirect(direcciones.ViewDivisiones);
            }
        }

        protected AdmDivisiones GetViewData()
        {
            AdmDivisiones dosificadorObj = new AdmDivisiones
            {
                Nombre = TextDivision.Text,
            };

            return dosificadorObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AdmDivisiones dosificadorObj = new AdmDivisiones();

            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                dosificadorObj = REP.GetDivisionesByID(id).First();

                TextDivision.Text = dosificadorObj.Nombre.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }

        protected void insertarParametros(AdmDivisiones dosificadorObj)
        {
            if (REP.InsertarDivision(dosificadorObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AdmDivisiones dosificadorObj)
        {
            if (REP.ActualizarDivision(dosificadorObj))
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
            string vtn = "window.open('~/Vistas/Formularios/popupSuccesful.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void popupNadaBien()
        {
            string vtn = "window.open('../Vistas/popupFailed.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.ViewDivisiones);
        }
    }
}