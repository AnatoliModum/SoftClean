﻿using AppSoftClean.Data.Model;
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

        private void eleccionCargaDeDatos()
        {
            LevantamientoEquipos equipoObj = new LevantamientoEquipos();
            int id = Int32.Parse(Request.QueryString["id"]);

            equipoObj = REP.GetLevantamientoByID(id).First();

            TextFecha.Text = equipoObj.dteFecha.ToString();
            TextNumHoja.Text = equipoObj.NumHoja.ToString();
            DDL_Division.Items.Clear();
            this.FillDropDownListDivision();
            DDL_Division.SelectedValue = string.Concat(equipoObj.IdDivision);

            List<Reportes> levantamientoEquipos = RR.ObtenerListado(RPA.GetPedidoByIDLevantamiento(id), equipoObj);

            this.dgvDatos.getCatalog(levantamientoEquipos);
        }

        private void FillDropDownListDivision()
        {
            this.DDL_Division.getCatalogoDivisiones();
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            btnCrear_Modal.Text = "Crear";
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModalCreate();", true);
        }

        protected void dgvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Editar":
                    RepositoryPedidosArea RPA = new RepositoryPedidosArea();
                    PedidosArea pedido = new PedidosArea();
                    List<string> listaGenerica = new List<string>();
                    int index = Convert.ToInt32(e.CommandArgument.ToString());
                    int idPedido = Int32.Parse( dgvDatos.Rows[index].Cells[0].Text ) ;

                    pedido = RPA.GetPedidoByID(idPedido).First();
                    Session["idPerma"] = idPedido;

                    TextAreaInstalacion.Text = pedido.AreaIns;

                    DDL_CanModEqDos.SelectedValue = pedido.CanModEqDos.ToString();
                    DDL_ModEqDos.SelectedValue = pedido.IdModEqDos.ToString();

                    CanDosEstLim.SelectedValue = pedido.CanDosEstLim.ToString();
                    DDL_DosEstLim.SelectedValue = pedido.IdDosEstLim.ToString();

                    DDL_ModJab.SelectedValue = pedido.IdModJab.ToString();
                    TextCanModJab.Text = pedido.CanModJab.ToString();

                    TextCanConsumibles.Text = pedido.CanCepInBas.ToString();

                    TextCanTipMaqLav.Text = pedido.CanTipMaqLav.ToString();
                    DDL_TipMaqLav.SelectedValue = pedido.IdTipMaqLav.ToString();

                    TextCanPorGalon.Text = pedido.CanPorGalon.ToString();
                    DDL_PorGalon.SelectedValue = pedido.IdPorGalon.ToString();

                    listaGenerica = this.getProductos(pedido.ProdQuim);
                    for(int i = 0; i < listaGenerica.Count; i++)
                    {
                        LBProdQuim.Items.Add(listaGenerica[i] + ".");
                        this.UpdateProdQuimAgregar.Update();
                    }

                    listaGenerica = this.getProductos(pedido.DosLav);
                    for (int i = 0; i < listaGenerica.Count; i++)
                    {
                        LBDosLav.Items.Add(listaGenerica[i] + ".");
                        this.UpdateDosLavCargar.Update();
                    }

                    btnCrear_Modal.Text = "Actualizar";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "MyModalCreate();", true);
                    break;
            }
        }

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

        protected void btnCrear_Modal_Click(object sender, EventArgs e)
        {

            PedidosArea pedidoArea = new PedidosArea();

            //Area
            pedidoArea.AreaIns = TextAreaInstalacion.Text;


            //Modelo Equipo Dosificador
            pedidoArea.IdModEqDos = int.Parse(DDL_ModEqDos.SelectedValue);
            pedidoArea.CanModEqDos = int.Parse(DDL_CanModEqDos.SelectedValue);
            //Dosificador de limpieza
            pedidoArea.IdDosEstLim = int.Parse(DDL_DosEstLim.SelectedValue);
            pedidoArea.CanDosEstLim = int.Parse(CanDosEstLim.SelectedValue);

            //Productos quimicos
            for (int i = 0; i < LBProdQuim.Items.Count; i++)
            {
                pedidoArea.ProdQuim += LBProdQuim.Items[i].ToString();

            }

            //Modelo Jabonero
            pedidoArea.IdModJab = int.Parse(DDL_ModJab.SelectedValue);
            pedidoArea.CanModJab = int.Parse(TextCanModJab.Text);

            //Cepillo Inserto Base
            pedidoArea.CanCepInBas = int.Parse(TextCanConsumibles.Text);

            //Tipo MaqTav
            pedidoArea.IdTipMaqLav = int.Parse(DDL_TipMaqLav.SelectedValue);
            pedidoArea.CanTipMaqLav = int.Parse(TextCanTipMaqLav.Text);

            //DosificadorLav
            for (int i = 0; i < LBDosLav.Items.Count; i++)
            {
                pedidoArea.DosLav += LBDosLav.Items[i].ToString();
            }
            

            //Porta Galon
            pedidoArea.IdPorGalon = int.Parse(DDL_PorGalon.SelectedValue);
            pedidoArea.CanPorGalon = int.Parse(TextCanPorGalon.Text);

            //id
            pedidoArea.IdLevantamientoEquipo = Int32.Parse(Request.QueryString["id"]);

            if (btnCrear_Modal.Text != "Actualizar") { lblResultados.Text = CDS.ComenzarPedido(pedidoArea); }
            else {
                pedidoArea.id = (Int32) Session["idPerma"];
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
    }
}