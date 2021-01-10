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
    public partial class FormModEqDos : System.Web.UI.Page
    {
        private RepositoryModEqDos REP = new RepositoryModEqDos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) this.eleccionCargaDeDatos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AdmModEqDos equipoObj = this.GetViewData();

            if (this.lblAccion.Text.ToString() == "Actualizar")
            {
                equipoObj.IdAdmModEqDos = Int32.Parse(Request.QueryString["id"]);
                this.actualizarParametros(equipoObj);
            }
            else
            {
                this.insertarParametros(equipoObj);
            }
        }

        protected AdmModEqDos GetViewData()
        {
            AdmModEqDos equipoObj = new AdmModEqDos
            {
                Modelo = TextModelo.Text,
                EqDisponibles = Int32.Parse(TextEquiDis.Text)
            };

            return equipoObj;
        }

        protected void eleccionCargaDeDatos()
        {
            AdmModEqDos equipoObj = new AdmModEqDos();

            try
            {
                int id = Int32.Parse(Request.QueryString["id"]);

                equipoObj = REP.GetEquipoDosificadorByID(id).First();

                TextModelo.Text = equipoObj.Modelo.ToString();
                TextEquiDis.Text = equipoObj.EqDisponibles.ToString();

                lblAccion.Text = "Actualizar";
            }
            catch
            {
                lblAccion.Text = "Nuevo";
            }
        }

        protected void insertarParametros(AdmModEqDos equipoObj)
        {
            if (REP.InsertarEquipoDosificador(equipoObj))
            {
                this.popupTodoBien();
            }
            else
            {
                this.popupNadaBien();
            }
        }

        protected void actualizarParametros(AdmModEqDos equipoObj)
        {
            if (REP.ActualizarEquipoDosificador(equipoObj))
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