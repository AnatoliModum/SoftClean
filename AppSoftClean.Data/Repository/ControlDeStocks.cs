using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    class ControlDeStocks
    {
        public bool ComenzarPedido(PedidosArea Pedido)
        {
            bool res = false;

            if (this.ValidacionCreate(Pedido)) { res = true;  }
            
            return res;
        }

        public bool ValidacionCreate(PedidosArea Pedido)
        {
            int id = 0;
            bool res = false;

            RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
            id = Pedido.IdDosEstLim.Value;
            AdmDosEstLim dosEstacion = RDEL.GetEstacionesByID(id).First();
            if (dosEstacion.EqDisponibles > Pedido.CanDosEstLim)
            {
                dosEstacion.EqDisponibles = dosEstacion.EqDisponibles - Pedido.CanDosEstLim;
                RDEL.ActualizarEstacion(dosEstacion);
                res = true;
            }
            else
            {
                return res = false;
            }

            //RepositoryModEqDos RME = null;
            //RepositoryModJab RMJ = null;
            //RepositoryCepInsBas RCIB = null;
            //RepositoryTipMaqLav RTML = null;

            return res;
        }

        public bool ModificadorStockCreate(PedidosArea Pedido)
        {
            return false;
        }

    }
}
