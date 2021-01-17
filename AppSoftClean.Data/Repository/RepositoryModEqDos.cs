using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryModEqDos : IModEqDosRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarEquipoDosificador(AdmModEqDos EquipoDosificador)
        {
            bool res = false;

            try
            {
                AdmModEqDos equipoObj = conn.AdmModEqDos.Where(c => c.Id == EquipoDosificador.Id).FirstOrDefault<AdmModEqDos>();

                equipoObj.Modelo = EquipoDosificador.Modelo;
                equipoObj.EqDisponibles = EquipoDosificador.EqDisponibles;
                
                conn.AdmModEqDos.Attach(equipoObj);
                conn.Entry(equipoObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarEquipoDosificador(int id)
        {
            bool res = false;

            try
            {
                AdmModEqDos equipoOnj = conn.AdmModEqDos.Where(c => c.Id == id).FirstOrDefault<AdmModEqDos>();
                conn.AdmModEqDos.Remove(equipoOnj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<AdmModEqDos> GetAllEquiposDosificadores()
        {
            List<AdmModEqDos> levantamientoObj = null;
            try
            {
                levantamientoObj = conn.AdmModEqDos.ToList<AdmModEqDos>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return levantamientoObj;
        }

        public List<AdmModEqDos> GetEquipoDosificadorByID(int id)
        {
            List<AdmModEqDos> equipoObj = null;
            try
            {
                equipoObj = conn.AdmModEqDos.Where(c => c.Id == id).ToList<AdmModEqDos>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return equipoObj;
        }

        public bool InsertarEquipoDosificador(AdmModEqDos EquipoDosificador)
        {
            bool res = false;
            try
            {
                conn.AdmModEqDos.Add(EquipoDosificador);
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
