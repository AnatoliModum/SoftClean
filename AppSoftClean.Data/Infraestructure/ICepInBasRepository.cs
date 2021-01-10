using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface ICepInBasRepository
    {
        bool InsertarConsumibles(AdmCepInBas Consumibles);
        List<AdmCepInBas> GetAllConsumibles();
        List<AdmCepInBas> GetConsumiblesByID(int id);
        bool EliminarConsumibles(int id);
        bool ActualizarConsumibles(AdmCepInBas Consumibles);
    }
}
