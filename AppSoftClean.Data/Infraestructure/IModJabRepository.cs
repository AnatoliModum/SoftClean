using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface IModJabRepository
    {
        bool InsertarJabonera(AdmModJab Jabonera);
        List<AdmModJab> GetAllJaboneras();
        List<AdmModJab> GetJaboneraByID(int id);
        bool EliminarJabonera(int id);
        bool ActualizarJabonera(AdmModJab Jabonera);
    }
}
