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
    public partial class FormCepInBas : System.Web.UI.Page
    {
        private RepositoryCepInsBas RECIB = new RepositoryCepInsBas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.eleccionCargaDeDatos();
            }
        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AdmCepInBas areaObj = this.GetViewCepInBas();

            if (this.lblAccion.Text.ToString() == "Actualizar")
            {
                areaObj.id = Int32.Parse(Request.QueryString["id"]);
                this.actualizarParametros(areaObj);
                Response.Redirect(direcciones.ViewCepInBas);
            }
            else
            {
                this.insertarParametros(areaObj);
                Response.Redirect(direcciones.ViewCepInBas);
            }
        }

        protected AdmCepInBas GetViewCepInBas()
        {
            AdmCepInBas suministrosObj = new AdmCepInBas
            {
                Objeto = TextObjeto.Text,
                Stock = Int32.Parse(TextStock.Text)
            };
            
            return suministrosObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AdmCepInBas suministroObj = new AdmCepInBas();

            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                suministroObj = RECIB.GetConsumiblesByID(id).First();

                TextObjeto.Text = suministroObj.Objeto.ToString();
                TextStock.Text = suministroObj.Stock.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }

        protected void insertarParametros(AdmCepInBas suministroObj)
        {
            if (RECIB.InsertarConsumibles(suministroObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AdmCepInBas suministroObj)
        {
            if (RECIB.ActualizarConsumibles(suministroObj))
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
            Response.Redirect(direcciones.ViewCepInBas);
        }
    }
}