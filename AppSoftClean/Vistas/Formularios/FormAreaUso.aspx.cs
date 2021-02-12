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
    public partial class FormAreaUso : System.Web.UI.Page
    {
        private RepositoryAreaUso RAU = new RepositoryAreaUso();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.eleccionCargaDeDatos();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.ViewAreaUso);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AreaUso areaObj = this.GetViewAreaUso();

            if (this.lblAccion.Text.ToString() == "Actualizar")
            {
                areaObj.id = Int32.Parse(Request.QueryString["id"]);
                this.actualizarParametros(areaObj);
                Response.Redirect(direcciones.ViewAreaUso);
            }
            else
            {
                this.insertarParametros(areaObj);
                Response.Redirect(direcciones.ViewAreaUso);
            }
        }

        protected AreaUso GetViewAreaUso()
        {
            AreaUso areaObj = new AreaUso
            {
                Area = TextArea.Text,
                Descripcion = TextDescripcion.Text
            };

            string areaTest = areaObj.Area;

            return areaObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AreaUso areaObj = new AreaUso();
            
            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                areaObj = RAU.GetAreaUsoByID(id).First();

                TextArea.Text = areaObj.Area.ToString();
                TextDescripcion.Text = areaObj.Descripcion.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }
        
        protected void insertarParametros(AreaUso areaObj)
        {
            if (RAU.InsertarAreaUso(areaObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AreaUso areaObj)
        {
            if (RAU.ActualizarAreaUso(areaObj))
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