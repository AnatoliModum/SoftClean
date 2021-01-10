using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryDosEstLimp : IDosEstLimRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarEstacion(AdmDosEstLim Estacion)
        {
            bool res = false;

            try
            {
                AdmDosEstLim estacionObj = conn.AdmDosEstLim.Where(c => c.IdAdmDosEstLim == Estacion.IdAdmDosEstLim).FirstOrDefault<AdmDosEstLim>();

                estacionObj.DosEstLimp = Estacion.DosEstLimp;
                estacionObj.EqDisponibles = Estacion.EqDisponibles;

                conn.AdmDosEstLim.Attach(estacionObj);
                conn.Entry(estacionObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarEstacion(int id)
        {
            bool res = false;

            try
            {
                AdmDosEstLim estacionObj = conn.AdmDosEstLim.Where(c => c.IdAdmDosEstLim == id).FirstOrDefault<AdmDosEstLim>();
                conn.AdmDosEstLim.Remove(estacionObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<AdmDosEstLim> GetAllEstaciones()
        {
            List<AdmDosEstLim> estacionObj = null;
            try
            {
                estacionObj = conn.AdmDosEstLim.ToList<AdmDosEstLim>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return estacionObj;
        }

        public List<AdmDosEstLim> GetEstacionesByID(int id)
        {
            List<AdmDosEstLim> estacionObj = null;
            try
            {
                estacionObj = conn.AdmDosEstLim.Where(c => c.IdAdmDosEstLim == id).ToList<AdmDosEstLim>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return estacionObj;
        }

        public bool InsertarEstacion(AdmDosEstLim Estacion)
        {
            bool res = false;
            try
            {
                conn.AdmDosEstLim.Add(Estacion);
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
