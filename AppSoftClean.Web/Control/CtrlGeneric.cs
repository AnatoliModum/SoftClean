using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Web.Control
{
    class CtrlGeneric : DbContext
    {
        public List<T> GetCatalogoGenericEntity<T>() where T : class
        {
            List<T> lista = null;
            using (var contexto = new ServiceForHotelEntities())
            {
                lista = contexto.Set<T>().ToList<T>();
            }
            return lista;
        }
    }
}
