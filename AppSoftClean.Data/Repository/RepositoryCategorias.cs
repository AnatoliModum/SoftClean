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

        public bool ActualizarCategoria(Categorias categoria)
        {
            bool res = false;
            
            try
            {
                Categorias categoriaObj = conn.Categorias.Where(c => c.id == categoria.id).FirstOrDefault<Categorias>();

                categoriaObj.categoria = categoria.categoria;
                
                conn.Categorias.Attach(categoriaObj);
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
                Categorias categoriaObj = conn.Categorias.Where(c => c.id == id).FirstOrDefault<Categorias>();
                conn.Categorias.Remove(categoriaObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<Categorias> GetAllCategorias()
        {
            List<Categorias> categoriaObj = null;
            try
            {
                categoriaObj = conn.Categorias.ToList<Categorias>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return categoriaObj;
        }

        public List<Categorias> GetCategoriaByID(int id)
        {
            List<Categorias> categoriaObj = null;
            try
            {
                categoriaObj = conn.Categorias.Where(c => c.id == id).ToList<Categorias>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return categoriaObj;
        }

        public bool InsertarCategoria(Categorias categoria)
        {
            bool res = false;
            try
            {
                conn.Categorias.Add(categoria);
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
