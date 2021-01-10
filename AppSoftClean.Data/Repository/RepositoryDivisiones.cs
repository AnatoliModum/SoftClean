using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryDivisiones : IDivisionesRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarDivision(AdmDivisiones Division)
        {
            bool res = false;

            try
            {
                AdmDivisiones divisionObj = conn.AdmDivisiones.Where(c => c.IdAdmDivisiones == Division.IdAdmDivisiones).FirstOrDefault<AdmDivisiones>();

                divisionObj.Nombre = Division.Nombre;
                
                conn.AdmDivisiones.Attach(divisionObj);
                conn.Entry(divisionObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarDivision(int id)
        {
            bool res = false;

            try
            {
                AdmDivisiones divisionObj = conn.AdmDivisiones.Where(c => c.IdAdmDivisiones == id).FirstOrDefault<AdmDivisiones>();
                conn.AdmDivisiones.Remove(divisionObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<AdmDivisiones> GetAllDivisiones()
        {
            List<AdmDivisiones> divisionObj = null;
            try
            {
                divisionObj = conn.AdmDivisiones.ToList<AdmDivisiones>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return divisionObj;
        }

        public List<AdmDivisiones> GetDivisionesByID(int id)
        {
            List<AdmDivisiones> divisionObj = null;
            try
            {
                divisionObj = conn.AdmDivisiones.Where(c => c.IdAdmDivisiones == id).ToList<AdmDivisiones>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return divisionObj;
        }

        public bool InsertarDivision(AdmDivisiones Division)
        {
            bool res = false;
            try
            {
                conn.AdmDivisiones.Add(Division);
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
