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
    }
}
