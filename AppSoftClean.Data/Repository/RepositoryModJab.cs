using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryModJab : IModJabRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarJabonera(AdmModJab Jabonera)
        {
            bool res = false;

            try
            {
                AdmModJab jaboneraObj = conn.AdmModJab.Where(c => c.id == Jabonera.id).FirstOrDefault<AdmModJab>();

                jaboneraObj.Modelo = Jabonera.Modelo;
                jaboneraObj.Stock = Jabonera.Stock;

                conn.AdmModJab.Attach(jaboneraObj);
                conn.Entry(jaboneraObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarJabonera(int id)
        {
            bool res = false;

            try
            {
                AdmModJab jaboneraObj = conn.AdmModJab.Where(c => c.id == id).FirstOrDefault<AdmModJab>();
                conn.AdmModJab.Remove(jaboneraObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<AdmModJab> GetAllJaboneras()
        {
            List<AdmModJab> jaboneraObj = null;
            try
            {
                jaboneraObj = conn.AdmModJab.ToList<AdmModJab>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return jaboneraObj;
        }

        public List<AdmModJab> GetJaboneraByID(int id)
        {
            List<AdmModJab> jaboneraObj = null;
            try
            {
                jaboneraObj = conn.AdmModJab.Where(c => c.id == id).ToList<AdmModJab>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return jaboneraObj;
        }

        public bool InsertarJabonera(AdmModJab Jabonera)
        {
            bool res = false;
            try
            {
                conn.AdmModJab.Add(Jabonera);
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
