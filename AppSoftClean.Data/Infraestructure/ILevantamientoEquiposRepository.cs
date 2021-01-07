using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    interface ILevantamientoEquiposRepository
    {
        bool InsertarLevantamiento(LevantamientoEquipos Levantamiento);
        List<LevantamientoEquipos> GetAllLevantamientos();
        List<LevantamientoEquipos> GetLevantamientoByID(int id);
        bool EliminarLevantamiento(int id);
        bool ActualizarLevantamiento(LevantamientoEquipos Levantamiento);
    }
}
