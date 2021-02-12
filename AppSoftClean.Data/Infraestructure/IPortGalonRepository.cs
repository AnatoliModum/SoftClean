using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface IPortGalonRepository
    {
        bool InsertarGalonera(AdmPortGalon Galonera);
        List<AdmPortGalon> GetAllGaloneras();
        List<AdmPortGalon> GetGaloneraByID(int id);
        bool EliminarGalonera(int id);
        bool ActualizarGalonera(AdmPortGalon Galonera);
    }
}
