using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryCepInsBas : ICepInBasRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarConsumibles(AdmCepInBas Consumibles)
        {
            bool res = false;

            try
            {
                AdmCepInBas consumibleObj = conn.AdmCepInBas.Where(c => c.id == Consumibles.id).FirstOrDefault<AdmCepInBas>();

                consumibleObj.Objeto = Consumibles.Objeto;
                consumibleObj.Stock = Consumibles.Stock;

                conn.AdmCepInBas.Attach(consumibleObj);
                conn.Entry(consumibleObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarConsumibles(int id)
        {
            bool res = false;

            try
            {
                AdmCepInBas consumibleObj = conn.AdmCepInBas.Where(c => c.id == id).FirstOrDefault<AdmCepInBas>();
                conn.AdmCepInBas.Remove(consumibleObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<AdmCepInBas> GetAllConsumibles()
        {
            List<AdmCepInBas> consumibleObj = null;
            try
            {
                consumibleObj = conn.AdmCepInBas.ToList<AdmCepInBas>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return consumibleObj;
        }

        public List<AdmCepInBas> GetConsumiblesByID(int id)
        {
            List<AdmCepInBas> consumibleObj = null;
            try
            {
                consumibleObj = conn.AdmCepInBas.Where(c => c.id == id).ToList<AdmCepInBas>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return consumibleObj;
        }

        public bool InsertarConsumibles(AdmCepInBas Consumibles)
        {
            bool res = false;
            try
            {
                conn.AdmCepInBas.Add(Consumibles);
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
