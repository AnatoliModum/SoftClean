using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryTipMaqLav : ITipMaqLavRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarLavavajillas(AdmTipMaqLav Lavavajillas)
        {
            bool res = false;

            try
            {
                AdmTipMaqLav lavavajillasObj = conn.AdmTipMaqLav.Where(c => c.id == Lavavajillas.id).FirstOrDefault<AdmTipMaqLav>();

                lavavajillasObj.Tipo = Lavavajillas.Tipo;
                lavavajillasObj.Stock = Lavavajillas.Stock;

                conn.AdmTipMaqLav.Attach(lavavajillasObj);
                conn.Entry(lavavajillasObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarLavavajillas(int id)
        {
            bool res = false;

            try
            {
                AdmTipMaqLav lavavajillasObj = conn.AdmTipMaqLav.Where(c => c.id == id).FirstOrDefault<AdmTipMaqLav>();
                conn.AdmTipMaqLav.Remove(lavavajillasObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<AdmTipMaqLav> GetAllLavavajillas()
        {
            List<AdmTipMaqLav> lavavajillasObj = null;
            try
            {
                lavavajillasObj = conn.AdmTipMaqLav.ToList<AdmTipMaqLav>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return lavavajillasObj;
        }

        public List<AdmTipMaqLav> GetLavavajillasByID(int id)
        {
            List<AdmTipMaqLav> lavavajillaObj = null;
            try
            {
                lavavajillaObj = conn.AdmTipMaqLav.Where(c => c.id == id).ToList<AdmTipMaqLav>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return lavavajillaObj;
        }

        public bool InsertarLavavajillas(AdmTipMaqLav Lavavajillas)
        {
            bool res = false;
            try
            {
                conn.AdmTipMaqLav.Add(Lavavajillas);
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
