using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AppSoftClean.Web.Control
{
    public static class GridViewExtended
    {
        public static void getCatalog<T>(this GridView _control, List<T> lista) where T : class
        {
            _control.DataSource = lista;
            _control.DataBind();
        }

        public static void getCatalogo(this GridView _control, IList lista)
        {
            _control.DataSource = lista;
            _control.DataBind();
        }
    }
}
