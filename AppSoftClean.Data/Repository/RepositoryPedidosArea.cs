using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class RepositoryPedidosArea : IPedidosAreaRepository
    {
        private ServiceForHotelEntities conn = new ServiceForHotelEntities();

        public bool ActualizarPedido(PedidosArea Pedido)
        {
            bool res = false;

            try
            {
                PedidosArea pedidoObj = conn.PedidosArea.Where(c => c.id == Pedido.id).FirstOrDefault<PedidosArea>();

                pedidoObj.AreaIns = Pedido.AreaIns;
                pedidoObj.IdModEqDos = Pedido.IdModEqDos;
                pedidoObj.IdDosEstLim = Pedido.IdDosEstLim;
                pedidoObj.IdProdQuim = Pedido.IdProdQuim;
                pedidoObj.IdModJab = Pedido.IdModJab;
                pedidoObj.IdCepInBas = Pedido.IdCepInBas;
                pedidoObj.IdTipMaqLav = Pedido.IdTipMaqLav;
                pedidoObj.IdDosLav = Pedido.IdDosLav;
                pedidoObj.IdPorGalon = Pedido.IdPorGalon;

                conn.PedidosArea.Attach(pedidoObj);
                conn.Entry(pedidoObj).State = System.Data.Entity.EntityState.Modified;
                conn.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }

            return res;
        }

        public bool EliminarPedido(int id)
        {
            bool res = false;

            try
            {
                PedidosArea pedidoObj = conn.PedidosArea.Where(c => c.id == id).FirstOrDefault<PedidosArea>();
                conn.PedidosArea.Remove(pedidoObj);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }

            return res;
        }

        public List<PedidosArea> GetAllPedidos()
        {
            List<PedidosArea> pedidoObj = null;
            try
            {
                pedidoObj = conn.PedidosArea.ToList<PedidosArea>();
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return pedidoObj;
        }

        public List<PedidosArea> GetPedidoByID(int id)
        {
            List<PedidosArea> pedidoObj = null;
            try
            {
                pedidoObj = conn.PedidosArea.Where(c => c.id == id).ToList<PedidosArea>();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return pedidoObj;
        }

        public bool InsertarPedido(PedidosArea Pedido)
        {
            bool res = false;
            try
            {
                conn.PedidosArea.Add(Pedido);
                conn.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return res;
        }
    }
}
