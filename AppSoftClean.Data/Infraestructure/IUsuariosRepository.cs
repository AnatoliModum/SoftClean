using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface IUsuariosRepository
    {
        bool InsertarUsuario(usuarios user);
        List<usuarios> GetAllUsuarios();
        List<usuarios> GetUsuarioByID(int id);
        bool EliminarUsuario(int id);
        bool ActualizarUsuario(usuarios user);
        usuarios GetUsuariosLogin(string usuario, string password);
    }
}
