using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryCategorias : ICategoriasRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarCategoria(categorias categoria)
        {
            bool res = false;
            
            try
            {
                categorias categoriaObj = conn.categorias.Where(c => c.id == categoria.id).FirstOrDefault<categorias>();

                categoriaObj.categoria = categoria.categoria;
                
                conn.categorias.Attach(categoriaObj);
                conn.Entry(categoriaObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarCategoria(int id)
        {
            bool res = false;

            try
            {
                categorias categoriaObj = conn.categorias.Where(c => c.id == id).FirstOrDefault<categorias>();
                conn.categorias.Remove(categoriaObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<categorias> GetAllCategorias()
        {
            List<categorias> categoriaObj = null;
            try
            {
                categoriaObj = conn.categorias.ToList<categorias>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return categoriaObj;
        }

        public List<categorias> GetCategoriaByID(int id)
        {
            List<categorias> categoriaObj = null;
            try
            {
                categoriaObj = conn.categorias.Where(c => c.id == id).ToList<categorias>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return categoriaObj;
        }

        public bool InsertarCategoria(categorias categoria)
        {
            bool res = false;
            try
            {
                conn.categorias.Add(categoria);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return res;
        }
    }
}
