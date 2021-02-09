using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Model;
using Microsoft.Practices.Unity;
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

        //[Dependency]
        //private IDosEstLimRepository RDEL { get; set; }
        //private IModEqDosRepository RME = new RepositoryModEqDos();
        //private IModJabRepository RMJ = new RepositoryModJab();
        //private ICepInBasRepository RCIB = new RepositoryCepInsBas();
        //private ITipMaqLavRepository RTML = new RepositoryTipMaqLav();

        public RepositoryDosEstLimp RDEL = null;
        public RepositoryModEqDos RME = null;
        public RepositoryModJab RMJ = null;
        public RepositoryCepInsBas RCIB = null;
        public RepositoryTipMaqLav RTML = null;

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
                pedidoObj.IdTipMaqLav = Pedido.IdTipMaqLav;
                pedidoObj.IdDosLav = Pedido.IdDosLav;
                pedidoObj.IdPorGalon = Pedido.IdPorGalon;

                pedidoObj.ProdQuim = Pedido.ProdQuim;
                pedidoObj.DosLav = Pedido.DosLav;

                pedidoObj.CanModEqDos = Pedido.CanModEqDos;
                pedidoObj.CanDosEstLim = Pedido.CanDosEstLim;
                pedidoObj.CanModJab = Pedido.CanModJab;
                pedidoObj.CanCepInBas = Pedido.CanCepInBas;
                pedidoObj.CanTipMaqLav = Pedido.CanTipMaqLav;


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
