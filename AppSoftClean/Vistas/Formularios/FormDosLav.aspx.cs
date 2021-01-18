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
    public partial class FormDosLav : System.Web.UI.Page
    {
        private RepositoryDosLav REP = new RepositoryDosLav();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) this.eleccionCargaDeDatos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AdmDosLav dosificadorObj = this.GetViewData();

            if (this.lblAccion.Text.ToString() == "Actualizar")
            {
                dosificadorObj.id = Int32.Parse(Request.QueryString["id"]);
                this.actualizarParametros(dosificadorObj);
                Response.Redirect(direcciones.ViewDosLav);
            }
            else
            {
                this.insertarParametros(dosificadorObj);
                Response.Redirect(direcciones.ViewDosLav);
            }
        }

        protected AdmDosLav GetViewData()
        {
            AdmDosLav dosificadorObj = new AdmDosLav
            {
                Equipo = TextEquipo.Text,
                Stock = Int32.Parse(TextStock.Text)
            };

            return dosificadorObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AdmDosLav dosificadorObj = new AdmDosLav();

            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                dosificadorObj = REP.GetDosificadoresByID(id).First();

                TextEquipo.Text = dosificadorObj.Equipo.ToString();
                TextStock.Text = dosificadorObj.Stock.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }

        protected void insertarParametros(AdmDosLav dosificadorObj)
        {
            if (REP.InsertarDosificador(dosificadorObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AdmDosLav dosificadorObj)
        {
            if (REP.ActualizarDosificador(dosificadorObj))
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
            Response.Redirect(direcciones.ViewDosLav);
        }
    }
}