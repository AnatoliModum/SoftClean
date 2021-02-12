using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryLevantamientoEquipos : ILevantamientoEquiposRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarLevantamiento(LevantamientoEquipos Levantamiento)
        {
            bool res = false;

            try
            {
                LevantamientoEquipos levantamientoObj = conn.LevantamientoEquipos.Where(c => c.id == Levantamiento.id).FirstOrDefault<LevantamientoEquipos>();

                levantamientoObj.IdDivision = Levantamiento.IdDivision;
                levantamientoObj.dteFecha = Levantamiento.dteFecha;
                levantamientoObj.NumHoja = Levantamiento.NumHoja;

                conn.LevantamientoEquipos.Attach(levantamientoObj);
                conn.Entry(levantamientoObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarLevantamiento(int id)
        {
            bool res = false;

            try
            {
                LevantamientoEquipos levantamientoObj = conn.LevantamientoEquipos.Where(c => c.id == id).FirstOrDefault<LevantamientoEquipos>();
                conn.LevantamientoEquipos.Remove(levantamientoObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<LevantamientoEquipos> GetAllLevantamientos()
        {
            List<LevantamientoEquipos> levantamientoObj = null;
            try
            {
                levantamientoObj = conn.LevantamientoEquipos.ToList<LevantamientoEquipos>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return levantamientoObj;
        }

        public List<LevantamientoEquipos> GetLevantamientoByID(int id)
        {
            List<LevantamientoEquipos> levantamientoObj = null;
            try
            {
                levantamientoObj = conn.LevantamientoEquipos.Where(c => c.id == id).ToList<LevantamientoEquipos>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return levantamientoObj;
        }

        public bool InsertarLevantamiento(LevantamientoEquipos Levantamiento)
        {
            bool res = false;
            try
            {
                conn.LevantamientoEquipos.Add(Levantamiento);
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
