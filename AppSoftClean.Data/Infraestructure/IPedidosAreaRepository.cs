using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    interface IPedidosAreaRepository
    {
        bool InsertarPedido(PedidosArea Pedido);
        List<PedidosArea> GetAllPedidos();
        List<PedidosArea> GetPedidoByID(int id);
        bool EliminarPedido(int id);
        bool ActualizarPedido(PedidosArea Pedido);
    }
}
