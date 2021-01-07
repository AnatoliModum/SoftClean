using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryAreaUso : IAreaUsoRepository
    {

        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarAreaUso(AreaUso Area)
        {
            bool res = false;

            try
            {
                AreaUso areaObj = conn.AreaUso.Where(c => c.IdAreaUso == Area.IdAreaUso).FirstOrDefault<AreaUso>();

                areaObj.Area = Area.Area;
                areaObj.Descripcion = Area.Descripcion;

                conn.AreaUso.Attach(areaObj);
                conn.Entry(areaObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;

        }

        public bool EliminarAreaUso(int id)
        {
            bool res = false;

            try
            {
                AreaUso areaObj = conn.AreaUso.Where(c => c.IdAreaUso == id).FirstOrDefault<AreaUso>();
                conn.AreaUso.Remove(areaObj);
                conn.SaveChanges();
                res = true;
            }catch(Exception ex)
            {
                string mensajeError = ex.Message;
            }
            
            return res;
        }

        public List<AreaUso> GetAllAreasUso()
        {
            List<AreaUso> areaObj = null;
            try
            {
                areaObj = conn.AreaUso.ToList<AreaUso>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return areaObj;
        }

        public List<AreaUso> GetAreaUsoByID(int id)
        {
            List<AreaUso> areaObj = null;
            try
            {
                areaObj = conn.AreaUso.Where(c => c.IdAreaUso == id).ToList<AreaUso>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return areaObj;
        }

        public bool InsertarAreaUso(AreaUso Area)
        {
            bool res = false;
            try
            {
                conn.AreaUso.Add(Area);
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
