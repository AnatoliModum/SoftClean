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
    public partial class FormModJab : System.Web.UI.Page
    {
        private RepositoryModJab REP = new RepositoryModJab();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) this.eleccionCargaDeDatos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AdmModJab equipoObj = this.GetViewData();

            if (this.lblAccion.Text.ToString() == "Actualizar")
            {
                equipoObj.id = Int32.Parse(Request.QueryString["id"]);
                this.actualizarParametros(equipoObj);
                Response.Redirect(direcciones.ViewModJab);
            }
            else
            {
                this.insertarParametros(equipoObj);
                Response.Redirect(direcciones.ViewModJab);
            }
        }

        protected AdmModJab GetViewData()
        {
            AdmModJab equipoObj = new AdmModJab
            {
                Modelo = TextModelo.Text,
                Stock = Int32.Parse(TextStock.Text)
            };

            return equipoObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AdmModJab equipoObj = new AdmModJab();

            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                equipoObj = REP.GetJaboneraByID(id).First();

                TextModelo.Text = equipoObj.Modelo.ToString();
                TextStock.Text = equipoObj.Stock.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }

        protected void insertarParametros(AdmModJab equipoObj)
        {
            if (REP.InsertarJabonera(equipoObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AdmModJab equipoObj)
        {
            if (REP.ActualizarJabonera(equipoObj))
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
            Response.Redirect(direcciones.ViewModJab);
        }
    }
}