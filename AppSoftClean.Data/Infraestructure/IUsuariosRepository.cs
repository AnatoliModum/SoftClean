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
        bool InsertarUsuario(Usuarios user);
        List<Usuarios> GetAllUsuarios();
        List<Usuarios> GetUsuarioByID(int id);
        bool EliminarUsuario(int id);
        bool ActualizarUsuario(Usuarios user);
        Usuarios GetUsuariosLogin(string usuario, string password);
    }
}
