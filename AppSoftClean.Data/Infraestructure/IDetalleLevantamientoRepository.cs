using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface IDetalleLevantamientoRepository
    {
        bool InsertarDetalles(DetalleLevantamiento Detalles);
        List<DetalleLevantamiento> GetAllDetalles();
        List<DetalleLevantamiento> GetDetallesByID(int id);
        bool EliminarDetalles(int id);
        bool ActualizarDetalles(DetalleLevantamiento Detalles);
    }
}
