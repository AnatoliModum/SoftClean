using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryProdQuim : IProdQuimRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarQuimico(AdmProdQuim Quimico)
        {
            bool res = false;

            try
            {
                AdmProdQuim quimicoObj = conn.AdmProdQuim.Where(c => c.id == Quimico.id).FirstOrDefault<AdmProdQuim>();

                quimicoObj.Quimico = Quimico.Quimico;
                quimicoObj.Stock = Quimico.Stock;
                quimicoObj.IdAreaUso = Quimico.IdAreaUso;

                conn.AdmProdQuim.Attach(quimicoObj);
                conn.Entry(quimicoObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarQuimico(int id)
        {
            bool res = false;

            try
            {
                AdmProdQuim quimicoObj = conn.AdmProdQuim.Where(c => c.id == id).FirstOrDefault<AdmProdQuim>();
                conn.AdmProdQuim.Remove(quimicoObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<AdmProdQuim> GetAllQuimicos()
        {
            List<AdmProdQuim> quimicoObj = null;
            try
            {
                quimicoObj = conn.AdmProdQuim.ToList<AdmProdQuim>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return quimicoObj;
        }

        public List<AdmProdQuim> GetAllQuimicosAmaLlaves()
        {
            List<AdmProdQuim> quimicoObj = null;
            try
            {
                quimicoObj = conn.AdmProdQuim.Where(c => c.IdAreaUso == 2).ToList<AdmProdQuim>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return quimicoObj;
        }

        public List<AdmProdQuim> GetAllQuimicosCocina()
        {
            List<AdmProdQuim> quimicoObj = null;
            List<AdmProdQuim> quimicoAma = null;
            try
            {
                quimicoObj = conn.AdmProdQuim.Where(c => c.IdAreaUso == 1).ToList<AdmProdQuim>();
                quimicoAma = conn.AdmProdQuim.Where(c => c.IdAreaUso == 2).ToList<AdmProdQuim>();
                quimicoObj.AddRange(quimicoAma);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return quimicoObj;
        }

        public List<AdmProdQuim> GetQuimicoByID(int id)
        {
            List<AdmProdQuim> quimicoObj = null;
            try
            {
                quimicoObj = conn.AdmProdQuim.Where(c => c.id == id).ToList<AdmProdQuim>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return quimicoObj;
        }

        public List<AdmProdQuim> GetQuimicoByName(string name)
        {
            List<AdmProdQuim> quimicoObj = null;
            try
            {
                quimicoObj = conn.AdmProdQuim.Where(c => c.Quimico == name).ToList<AdmProdQuim>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return quimicoObj;
        }


        public bool InsertarQuimico(AdmProdQuim Quimico)
        {
            bool res = false;
            try
            {
                conn.AdmProdQuim.Add(Quimico);
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
