using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryPortGalon : IPortGalonRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarGalonera(AdmPortGalon Galonera)
        {
            bool res = false;

            try
            {
                AdmPortGalon galoneraObj = conn.AdmPortGalon.Where(c => c.IdAdmPortGalon == Galonera.IdAdmPortGalon).FirstOrDefault<AdmPortGalon>();

                galoneraObj.Tipo = Galonera.Tipo;
                galoneraObj.Stock = Galonera.Stock;

                conn.AdmPortGalon.Attach(galoneraObj);
                conn.Entry(galoneraObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarGalonera(int id)
        {
            bool res = false;

            try
            {
                AdmPortGalon galonObj = conn.AdmPortGalon.Where(c => c.IdAdmPortGalon == id).FirstOrDefault<AdmPortGalon>();
                conn.AdmPortGalon.Remove(galonObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<AdmPortGalon> GetAllGaloneras()
        {
            List<AdmPortGalon> galonObj = null;
            try
            {
                galonObj = conn.AdmPortGalon.ToList<AdmPortGalon>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return galonObj;
        }

        public List<AdmPortGalon> GetGaloneraByID(int id)
        {
            List<AdmPortGalon> galonObj = null;
            try
            {
                galonObj = conn.AdmPortGalon.Where(c => c.IdAdmPortGalon == id).ToList<AdmPortGalon>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return galonObj;
        }

        public bool InsertarGalonera(AdmPortGalon Galonera)
        {
            bool res = false;
            try
            {
                conn.AdmPortGalon.Add(Galonera);
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
