using AppSoftClean.Data.Model;
using AppSoftClean.Data.Repository;
using AppSoftClean.Web.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSoftClean.Vistas.Listas
{
    public partial class ViewDiseñoReportes : System.Web.UI.Page
    {
        private RepositoryReportes RR = new RepositoryReportes();
        private RepositoryPedidosArea RPA = new RepositoryPedidosArea();
        private RepositoryLevantamientoEquipos REP = new RepositoryLevantamientoEquipos();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request.QueryString["id"]);
            LevantamientoEquipos equipoObj = new LevantamientoEquipos();
            equipoObj = REP.GetLevantamientoByID(id).First();
            List<Reportes> levantamientoEquipos = RR.ObtenerListado(RPA.GetPedidoByIDLevantamiento(id), equipoObj);

            txtIdLevantamiento.Text = equipoObj.id.ToString();
            txtDivision.Text = levantamientoEquipos[0].Division;
            txtFechaLevantamiento.Text = levantamientoEquipos[0].Fecha.ToString();
            txtNoHoja.Text = equipoObj.NumHoja.ToString();

            this.dgvDatos.getCatalog(levantamientoEquipos);
        }
    }
}