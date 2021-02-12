using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface IDosEstLimRepository
    {
        bool InsertarEstacion(AdmDosEstLim Estacion);
        List<AdmDosEstLim> GetAllEstaciones();
        List<AdmDosEstLim> GetEstacionesByID(int id);
        bool EliminarEstacion(int id);
        bool ActualizarEstacion(AdmDosEstLim Estacion);
    }
}
