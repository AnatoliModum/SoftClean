using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface IDivisionesRepository
    {
        bool InsertarDivision(AdmDivisiones Division);
        List<AdmDivisiones> GetAllDivisiones();
        List<AdmDivisiones> GetDivisionesByID(int id);
        bool EliminarDivision(int id);
        bool ActualizarDivision(AdmDivisiones Division);
    }
}
