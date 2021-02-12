using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface IAreaUsoRepository
    {
        bool InsertarAreaUso(AreaUso Area);
        List<AreaUso> GetAllAreasUso();
        List<AreaUso> GetAreaUsoByID(int id);
        bool EliminarAreaUso(int id);
        bool ActualizarAreaUso(AreaUso Area);
    }
}
