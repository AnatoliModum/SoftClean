using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    interface IDosLavRepository
    {
        bool InsertarDosificador(AdmDosLav Dosificador);
        List<AdmDosLav> GetAllDosificadores();
        List<AdmDosLav> GetDosificadoresByID(int id);
        bool EliminarDosificador(int id);
        bool ActualizarDosificador(AdmDosLav Dosificador);
    }
}
