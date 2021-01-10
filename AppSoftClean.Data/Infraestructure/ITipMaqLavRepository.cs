using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface ITipMaqLavRepository
    {
        bool InsertarLavavajillas(AdmTipMaqLav Lavavajillas);
        List<AdmTipMaqLav> GetAllLavavajillas();
        List<AdmTipMaqLav> GetLavavajillasByID(int id);
        bool EliminarLavavajillas(int id);
        bool ActualizarLavavajillas(AdmTipMaqLav Lavavajillas);
    }
}
