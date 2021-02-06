using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    public interface ICategoriasRepository
    {
        bool InsertarCategoria(Categorias categoria);
        List<Categorias> GetAllCategorias();
        List<Categorias> GetCategoriaByID(int id);
        bool EliminarCategoria(int id);
        bool ActualizarCategoria(Categorias categoria);
    }
}
