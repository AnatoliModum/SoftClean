using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AppSoftClean.Web.Control
{
    public static class DropDownListExtended
    {
        public static void getCatalogoAreaUso(this DropDownList _control)
        {
            CtrlGeneric ctrl = new CtrlGeneric();
            List<AreaUso> lista = ctrl.GetCatalogoGenericEntity<AreaUso>();
            _control.Items.Insert(0, "Selecciona un Área de Uso");
            _control.DataTextField = "Area";
            _control.DataValueField = "id";
            _control.DataSource = lista;
            _control.DataBind();
        }

        public static void getCatalogoDivisiones(this DropDownList _control)
        {
            CtrlGeneric ctrl = new CtrlGeneric();
            List<AdmDivisiones> lista = ctrl.GetCatalogoGenericEntity<AdmDivisiones>();
            _control.Items.Insert(0, "Selecciona una División");
            _control.DataTextField = "Nombre";
            _control.DataValueField = "id";
            _control.DataSource = lista;
            _control.DataBind();
        }

        public static void getCatalogoPorGalon(this DropDownList _control)
        {
            CtrlGeneric ctrl = new CtrlGeneric();
            List<AdmPortGalon> lista = ctrl.GetCatalogoGenericEntity<AdmPortGalon>();
            _control.Items.Insert(0, "Selecciona un Porta Galón");
            _control.DataTextField = "Tipo";
            _control.DataValueField = "id";
            _control.DataSource = lista;
            _control.DataBind();
        }

        public static void getCatalogoTipMaqLav(this DropDownList _control)
        {
            CtrlGeneric ctrl = new CtrlGeneric();
            List<AdmTipMaqLav> lista = ctrl.GetCatalogoGenericEntity<AdmTipMaqLav>();
            _control.Items.Insert(0, "Selecciona un Tipo");
            _control.DataTextField = "Tipo";
            _control.DataValueField = "id";
            _control.DataSource = lista;
            _control.DataBind();
        }

        public static void getCatalogoModJab(this DropDownList _control)
        {
            CtrlGeneric ctrl = new CtrlGeneric();
            List<AdmModJab> lista = ctrl.GetCatalogoGenericEntity<AdmModJab>();
            _control.Items.Insert(0, "Selecciona un Módelo");
            _control.DataTextField = "Modelo";
            _control.DataValueField = "id";
            _control.DataSource = lista;
            _control.DataBind();
        }

        public static void getCatalogoDosEstLim(this DropDownList _control)
        {
            CtrlGeneric ctrl = new CtrlGeneric();
            List<AdmDosEstLim> lista = ctrl.GetCatalogoGenericEntity<AdmDosEstLim>();
            _control.Items.Insert(0, "Selecciona un Dosificador");
            _control.DataTextField = "DosEstLimp";
            _control.DataValueField = "id";
            _control.DataSource = lista;
            _control.DataBind();
        }

        public static void getCatalogoModEqDos(this DropDownList _control)
        {
            CtrlGeneric ctrl = new CtrlGeneric();
            List<AdmModEqDos> lista = ctrl.GetCatalogoGenericEntity<AdmModEqDos>();
            _control.Items.Insert(0, "Selecciona un Modelo");
            _control.DataTextField = "Modelo";
            _control.DataValueField = "id";
            _control.DataSource = lista;
            _control.DataBind();
        }

        public static void getCatalogoDosLav(this DropDownList _control)
        {
            CtrlGeneric ctrl = new CtrlGeneric();
            List<AdmDosLav> lista = ctrl.GetCatalogoGenericEntity<AdmDosLav>();
            _control.Items.Insert(0, "Selecciona un Dosificador");
            _control.DataTextField = "Equipo";
            _control.DataValueField = "id";
            _control.DataSource = lista;
            _control.DataBind();
        }
    }
}
