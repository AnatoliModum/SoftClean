using AppSoftClean.Data.Model;
using AppSoftClean.Data.Recursos;
using AppSoftClean.Data.Repository;
using AppSoftClean.Web.Control;
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
            if (!IsPostBack)
            {
                FillDropDownListAreaUso();
                this.eleccionCargaDeDatos();
            }

        }

        private void FillDropDownListAreaUso()
        {
            this.DDL_AreaUso.getCatalogoAreaUso();
        }

        private string GetDropDownListAreaUso()
        {
            return this.DDL_AreaUso.SelectedValue.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if(DDL_AreaUso.Text== "Selecciona un Área de Uso")
            {
                lblErrorDDL.Visible = true;
                lblMargen.Visible = false;
            }
            else
            {
                AdmProdQuim equipoObj = this.GetViewData();

                if (this.lblAccion.Text.ToString() == "Actualizar")
                {
                    equipoObj.id = Int32.Parse(Request.QueryString["id"]);
                    this.actualizarParametros(equipoObj);
                    Response.Redirect(direcciones.ViewProdQuim);
                }
                else
                {
                    this.insertarParametros(equipoObj);
                    Response.Redirect(direcciones.ViewProdQuim);
                }
            }  
        }

        protected AdmProdQuim GetViewData()
        {
            AdmProdQuim equipoObj = new AdmProdQuim
            {
                Quimico = TextQuimico.Text,
                Stock = Int32.Parse(TextStock.Text),
                IdAreaUso = Int32.Parse(GetDropDownListAreaUso())
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
                DDL_AreaUso.Items.Clear();
                this.FillDropDownListAreaUso();
                DDL_AreaUso.SelectedValue = string.Concat(equipoObj.IdAreaUso);

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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.ViewProdQuim);
        }

        protected void DDL_AreaUso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_AreaUso.Text == "Selecciona un Área de Uso")
            {
                lblErrorDDL.Visible = true;
                lblMargen.Visible = false;
            }
            else
            {
                lblErrorDDL.Visible = false;
                lblMargen.Visible = true;
            }
            this.UpdateValidacion.Update();
        }
    }
}