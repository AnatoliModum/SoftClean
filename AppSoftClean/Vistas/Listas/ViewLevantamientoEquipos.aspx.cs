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

namespace AppSoftClean.Vistas.Listas
{
    public partial class ViewLevantamientoEquipos : System.Web.UI.Page
    {

        private RepositoryLevantamientoEquipos REP = new RepositoryLevantamientoEquipos();
        private RepositoryProdQuim RPQ = new RepositoryProdQuim();
        private RepositoryReportes RR = new RepositoryReportes();
        private RepositoryPedidosArea RPA = new RepositoryPedidosArea();
        private ControlDeStocks CDS = new ControlDeStocks();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                this.eleccionCargaDeDatos();
                FillDropDownListModEqDos();
                FillDropDownListDosLav();
                FillDropDownListDosEstLim();
                FillDropDownListProdQuim();
                FillDropDownListModJab();
                FillDropDownListTipMaqLav();
                FillDropDownListPorGalon();
            }
        }

        #region Fill Of DDL

        private void FillDropDownListDivision()
        {
            this.DDL_Division.getCatalogoDivisiones();
        }

        private void FillDropDownListDosLav()
        {
            DDL_DosLav.Items.Clear();
            this.DDL_DosLav.getCatalogoDosLav();
        }

        private void FillDropDownListPorGalon()
        {
            DDL_PorGalon.Items.Clear();
            this.DDL_PorGalon.getCatalogoPorGalon();
        }

        private void FillDropDownListTipMaqLav()
        {
            DDL_TipMaqLav.Items.Clear();
            this.DDL_TipMaqLav.getCatalogoTipMaqLav();
        }

        private void FillDropDownListModJab()
        {
            DDL_ModJab.Items.Clear();
            this.DDL_ModJab.getCatalogoModJab();
        }

        private void FillDropDownListProdQuim()
        {
            DDL_ProdQuim.Items.Clear();
            List<AdmProdQuim> lista = RPQ.GetAllQuimicosCocina();
            DDL_ProdQuim.Items.Insert(0, "Selecciona un Químico");
            DDL_ProdQuim.DataTextField = "Quimico";
            DDL_ProdQuim.DataValueField = "id";
            DDL_ProdQuim.DataSource = lista;
            DDL_ProdQuim.DataBind();
        }

        private void FillDropDownListDosEstLim()
        {
            DDL_DosEstLim.Items.Clear();
            this.DDL_DosEstLim.getCatalogoDosEstLim();
        }

        private void FillDropDownListModEqDos()
        {
            DDL_ModEqDos.Items.Clear();
            this.DDL_ModEqDos.getCatalogoModEqDos();
        }

        #endregion

        private void eleccionCargaDeDatos()
        {
            LevantamientoEquipos equipoObj = new LevantamientoEquipos();
            int id = Int32.Parse(Request.QueryString["id"]);

            equipoObj = REP.GetLevantamientoByID(id).First();

            //TextFecha.Text = Convert.ToDateTime(equipoObj.dteFecha.ToString()).ToString("dd/MM/yyyy");
            TextFecha.Text = equipoObj.dteFecha.ToString();
            TextNumHoja.Text = equipoObj.NumHoja.ToString();
            DDL_Division.Items.Clear();
            this.FillDropDownListDivision();
            DDL_Division.SelectedValue = string.Concat(equipoObj.IdDivision);

            List<Reportes> levantamientoEquipos = RR.ObtenerListado(RPA.GetPedidoByIDLevantamiento(id), equipoObj);
            this.dgvDatos.getCatalog(levantamientoEquipos);
        }
        
        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModalCreate();", true);
        }

        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int idPedido = Int32.Parse(dgvDatos.Rows[index].Cells[0].Text);

            switch (e.CommandName)
            {
                #region Boton Editar
                case "Editar":
                    RepositoryPedidosArea RPA = new RepositoryPedidosArea();
                    PedidosArea pedido = new PedidosArea();
                    List<string> listaGenerica = new List<string>();

                    pedido = RPA.GetPedidoByID(idPedido).First();
                    Session["idPerma"] = idPedido;

                    TextAreaInstalacion.Text = pedido.AreaIns;

                    DDL_CanModEqDos.SelectedValue = pedido.IdModEqDos != null?pedido.CanModEqDos.ToString():"0";
                    DDL_ModEqDos.SelectedValue = pedido.IdModEqDos!=null?pedido.IdModEqDos.ToString():null;

                    CanDosEstLim.SelectedValue = pedido.IdDosEstLim!=null?pedido.CanDosEstLim.ToString():"0";
                    DDL_DosEstLim.SelectedValue = pedido.IdDosEstLim!=null?pedido.IdDosEstLim.ToString():null;

                    DDL_ModJab.SelectedValue = pedido.IdModJab!=null?pedido.IdModJab.ToString():null;
                    TextCanModJab.Text = !string.IsNullOrEmpty(pedido.CanModJab.ToString())?pedido.CanModJab.ToString():"0";

                    TextCanConsumibles.Text = !string.IsNullOrEmpty(pedido.CanCepInBas.ToString())?pedido.CanCepInBas.ToString():"0";

                    TextCanTipMaqLav.Text = !string.IsNullOrEmpty(pedido.CanTipMaqLav.ToString())?pedido.CanTipMaqLav.ToString():"0";
                    DDL_TipMaqLav.SelectedValue = pedido.IdTipMaqLav!=null?pedido.IdTipMaqLav.ToString():null;

                    TextCanPorGalon.Text = !string.IsNullOrEmpty(pedido.CanPorGalon.ToString())?pedido.CanPorGalon.ToString():"0";
                    DDL_PorGalon.SelectedValue = pedido.IdPorGalon !=null?pedido.IdPorGalon.ToString():null;

                    LBProdQuim.Items.Clear();
                    if (pedido.ProdQuim !=null)
                    {
                        listaGenerica = this.getProductos(pedido.ProdQuim);

                        for (int i = 0; i < listaGenerica.Count; i++)
                        {
                            LBProdQuim.Items.Add(listaGenerica[i] + ".");
                            this.UpdateProdQuimAgregar.Update();
                        }
                    }
                    

                    LBDosLav.Items.Clear();
                    if (pedido.DosLav !=null)
                    {
                        listaGenerica = this.getProductos(pedido.DosLav);
                        for (int i = 0; i < listaGenerica.Count; i++)
                        {
                            LBDosLav.Items.Add(listaGenerica[i] + ".");
                            this.UpdateDosLavCargar.Update();
                        }
                    }
                    

                    btnCrear_Modal.Text = "Actualizar";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModalCreate();", true);
                    break;
                #endregion

                case "Eliminar":
                    RPA = new RepositoryPedidosArea();
                    CDS.EliminarPedido(RPA.GetPedidoByID(idPedido).First());
                    this.eleccionCargaDeDatos();
                    break;
            }

        }

        #region Botones Controladores de LB Modal

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            LBProdQuim.Items.Add(this.DDL_ProdQuim.SelectedItem.Text + ".");
            this.UpdateProdQuimAgregar.Update();
        }

        protected void BtnQuitar_ProdQuim_Click(object sender, EventArgs e)
        {
            if (LBProdQuim.Items.Count <= 0)
            {
                
            }
            else
            {
                LBProdQuim.Items.RemoveAt(LBProdQuim.SelectedIndex);
                this.UpdateProdQuimQuitar.Update();
            }
        }

        protected void BtnCargar_DosLav_Click(object sender, EventArgs e)
        {
            LBDosLav.Items.Add(this.DDL_DosLav.SelectedItem.Text + ".");
            this.UpdateDosLavCargar.Update();
        }

        protected void BtnQuitar_DosLav_Click(object sender, EventArgs e)
        {
            if (LBDosLav.Items.Count <= 0)
            {

            }
            else
            {
                LBDosLav.Items.RemoveAt(LBDosLav.SelectedIndex);
                this.UpdateDosLavQuitar.Update();
            }
        }

        #endregion

        protected void btnCrear_Modal_Click(object sender, EventArgs e)
        {

            PedidosArea pedidoArea = new PedidosArea();

            //Area
            pedidoArea.AreaIns = !string.IsNullOrEmpty(TextAreaInstalacion.Text) ? TextAreaInstalacion.Text : null;


            //Modelo Equipo Dosificador
            pedidoArea.IdModEqDos = (DDL_ModEqDos.SelectedIndex >= 1) ? int.Parse(DDL_ModEqDos.SelectedValue) : (int?)null;
            pedidoArea.CanModEqDos = pedidoArea.IdModEqDos != null ? int.Parse(DDL_CanModEqDos.SelectedValue) : 0;
            //Dosificador de limpieza
            pedidoArea.IdDosEstLim = DDL_DosEstLim.SelectedIndex >= 1 ? int.Parse(DDL_DosEstLim.SelectedValue) : (int?)null;
            pedidoArea.CanDosEstLim = pedidoArea.IdDosEstLim != null ? int.Parse(CanDosEstLim.SelectedValue) : 0;

            //Productos quimicos
            if (LBProdQuim.Items.Count > 0)
            {
                for (int i = 0; i < LBProdQuim.Items.Count; i++)
                {
                    pedidoArea.ProdQuim += LBProdQuim.Items[i].ToString();

                }
            }
            else
            {
                pedidoArea.ProdQuim = null;
            }
        
            //Modelo Jabonero
            pedidoArea.IdModJab = DDL_ModJab.SelectedIndex >= 1 ? int.Parse(DDL_ModJab.SelectedValue) : (int?)null;
            pedidoArea.CanModJab = !string.IsNullOrEmpty(TextCanModJab.Text) ? int.Parse(TextCanModJab.Text) : 0;

            //Cepillo Inserto Base
            pedidoArea.CanCepInBas = !string.IsNullOrEmpty(TextCanConsumibles.Text) ? int.Parse(TextCanConsumibles.Text) : 0;

            //Tipo MaqTav
            pedidoArea.IdTipMaqLav = DDL_TipMaqLav.SelectedIndex >= 1 ? int.Parse(DDL_TipMaqLav.SelectedValue) : (int?)null;
            pedidoArea.CanTipMaqLav = !string.IsNullOrEmpty(TextCanTipMaqLav.Text) ? int.Parse(TextCanTipMaqLav.Text) : 0;

            //DosificadorLav
            if (LBDosLav.Items.Count > 0)
            {
                for (int i = 0; i < LBDosLav.Items.Count; i++)
                {
                    pedidoArea.DosLav += LBDosLav.Items[i].ToString();
                }
            }
            else
            {
                pedidoArea.DosLav = null;
            }

            //Porta Galon
            pedidoArea.IdPorGalon = DDL_PorGalon.SelectedIndex >= 1 ? int.Parse(DDL_PorGalon.SelectedValue) : (int?)null;
            pedidoArea.CanPorGalon = !string.IsNullOrEmpty(TextCanPorGalon.Text) ? int.Parse(TextCanPorGalon.Text) : 0;

            //id
            pedidoArea.IdLevantamientoEquipo = Int32.Parse(Request.QueryString["id"]);

            if (btnCrear_Modal.Text != "Actualizar") { lblResultados.Text = CDS.ComenzarPedido(pedidoArea); }
            else
            {
                pedidoArea.id = (Int32)Session["idPerma"];
                lblResultados.Text = CDS.ActualizarPedido(pedidoArea);
            }
            this.eleccionCargaDeDatos();

        }

        private List<string> getProductos(string cadena)
        {
            List<string> quimicosList = new List<string>();
            string[] quimicos = null;

            if (cadena != "")
            {

                quimicos = cadena.Split('.');

                foreach (var item in quimicos)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        quimicosList.Add(item);
                    }

                }

                return quimicosList;
            }
            else
            {
                return null;
            }

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            int idObjeto = Int32.Parse(Request.QueryString["id"]);
            Response.Redirect("~/Vistas/Listas/ViewDiseñoReportes.aspx?id=" + idObjeto);
        }
    }
}