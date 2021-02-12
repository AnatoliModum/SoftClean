using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using AppSoftClean.Data.Recursos;
using AppSoftClean.Web.Control;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSoftClean.Vistas.Listas
{
    public partial class ViewCepInBas : System.Web.UI.Page
    {

        [Dependency]
        public ICepInBasRepository cepInBasRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillGridViewArea();
            }
        }

        private void FillGridViewArea()
        {
            List<AdmCepInBas> cepinbas = cepInBasRepository.GetAllConsumibles();
            this.dgvDatos.getCatalog(cepinbas);
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect(direcciones.FormCepInBas + 0);
        }

        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string idObjeto;
            switch (e.CommandName)
            {
                case "Editar":
                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    Response.Redirect(direcciones.FormCepInBas + idObjeto);
                    break;
                case "Eliminar":
                    idObjeto = dgvDatos.Rows[index].Cells[0].Text;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModaldata();", true);
                    AdmCepInBas admCepInBas = cepInBasRepository.GetConsumiblesByID(int.Parse(idObjeto)).First();
                    lblID.Text = String.Concat(admCepInBas.id);
                    lblObjeto.Text = admCepInBas.Objeto;
                    break;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            string idObjeto = this.lblID.Text;
            if (cepInBasRepository.EliminarConsumibles(int.Parse(idObjeto)))
            {
                Response.Redirect(direcciones.ViewCepInBas);
            }
        }
    }
}