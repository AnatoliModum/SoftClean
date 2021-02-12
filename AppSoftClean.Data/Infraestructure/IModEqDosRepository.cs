using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface IModEqDosRepository
    {
        bool InsertarEquipoDosificador(AdmModEqDos EquipoDosificador);
        List<AdmModEqDos> GetAllEquiposDosificadores();
        List<AdmModEqDos> GetEquipoDosificadorByID(int id);
        bool EliminarEquipoDosificador(int id);
        bool ActualizarEquipoDosificador(AdmModEqDos EquipoDosificador);
    }
}
