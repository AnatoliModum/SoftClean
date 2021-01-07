using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    class RepositoryDetalleLevantamiento : IDetalleLevantamientoRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarDetalles(DetalleLevantamiento Detalles)
        {
            bool res = false;

            try
            {
                DetalleLevantamiento detallesObj = conn.DetalleLevantamiento.Where(c => c.IdDetalleLevantamiento == Detalles.IdDetalleLevantamiento).FirstOrDefault<DetalleLevantamiento>();

                detallesObj.IdLevantamiento = Detalles.IdLevantamiento;
                detallesObj.IdPedidosArea = Detalles.IdPedidosArea;

                conn.DetalleLevantamiento.Attach(detallesObj);
                conn.Entry(detallesObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarDetalles(int id)
        {
            bool res = false;

            try
            {
                LevantamientoEquipos levantamientoObj = conn.LevantamientoEquipos.Where(c => c.IdLevantamientosEquipos == id).FirstOrDefault<LevantamientoEquipos>();
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

        public List<DetalleLevantamiento> GetAllDetalles()
        {
            List<DetalleLevantamiento> levantamientoObj = null;
            try
            {
                levantamientoObj = conn.DetalleLevantamiento.ToList<DetalleLevantamiento>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return levantamientoObj;
        }

        public List<DetalleLevantamiento> GetDetallesByID(int id)
        {
            List<DetalleLevantamiento> levantamientoObj = null;
            try
            {
                levantamientoObj = conn.DetalleLevantamiento.Where(c => c.IdDetalleLevantamiento == id).ToList<DetalleLevantamiento>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return levantamientoObj;
        }

        public bool InsertarDetalles(DetalleLevantamiento Detalles)
        {
            bool res = false;
            try
            {
                conn.DetalleLevantamiento.Add(Detalles);
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
