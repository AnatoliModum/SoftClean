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
        public string ComenzarPedido(PedidosArea Pedido)
        {
            String res = "";
            ComprobacionDePedidos com = this.ValidacionCreate(Pedido);
            RepositoryPedidosArea RPA = new RepositoryPedidosArea();

            if (com._CepInBasStock && com._DosEstLimStock && com._DosLavStock && com._ModEqDos &&
                com._ModJabStock && com._PorGalon && com._QuimicosStock && com._TipMaqLavStock)
            {
                if(RPA.InsertarPedido(Pedido))
                {
                    if (!this.ModificadorStockCreate(Pedido))
                    {
                        res = "Pedido creado exitosamente, error al modificar el stock";
                    }
                }
                else
                {
                    res = "Error al crear el pedido";
                }
            }
            else
            {
                res = "No se puede crear el pedido, por favor, verifique el stock de los siguientes productos \n"+Environment.NewLine;

                if (!com._CepInBasStock) { res = String.Concat(res, "Cepillos Insertos y Bases" + Environment.NewLine); }
                if (!com._DosEstLimStock) { res = String.Concat(res, "Dosificador Estacion de Limpieza" + Environment.NewLine); }
                if (!com._DosLavStock) { res = String.Concat(res, "Dosificador Lavavajillas" + Environment.NewLine); }
                if (!com._ModEqDos) { res = String.Concat(res, "Modelo Equipo Dosificador" + Environment.NewLine); }
                if (!com._ModJabStock) { res = String.Concat(res, "Modelo Jaboneras" + Environment.NewLine); }
                if (!com._PorGalon) { res = String.Concat(res, "Porta Galon" + Environment.NewLine); }
                if (!com._QuimicosStock) { res = String.Concat(res, "Quimicos" + Environment.NewLine); }
                if (!com._TipMaqLavStock) { res = String.Concat(res, "Maquina Lavavajillas" + Environment.NewLine); }
            }
            
            return res;
        }

        public ComprobacionDePedidos ValidacionCreate(PedidosArea Pedido)
        {
            ComprobacionDePedidos comprobador = new ComprobacionDePedidos();
            
            return comprobador;
        }

        public bool ModificadorStockCreate(PedidosArea Pedido)
        {
            bool res = false;
            int id = 0;

            RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
            RepositoryModJab RMJ = new RepositoryModJab();
            RepositoryCepInsBas RCIB = new RepositoryCepInsBas(); //MultiEntidad
            RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();
            RepositoryProdQuim RPQ = new RepositoryProdQuim(); //String
            RepositoryDosLav RDL = new RepositoryDosLav(); //String
            RepositoryModEqDos RMED = new RepositoryModEqDos();
            RepositoryPortGalon RPG = new RepositoryPortGalon();

            if (Pedido.IdDosEstLim != 0)
            {
                id = Pedido.IdDosEstLim.Value;
                AdmDosEstLim ADEL = RDEL.GetEstacionesByID(id).First();
                ADEL.EqDisponibles = ADEL.EqDisponibles - Pedido.CanDosEstLim;
                RDEL.ActualizarEstacion(ADEL);
            }

            if (Pedido.IdModJab != 0)
            {
                id = Pedido.IdModJab.Value;
                AdmModJab AMJ = RMJ.GetJaboneraByID(id).First();
                AMJ.Stock = AMJ.Stock - Pedido.CanModJab;
                RMJ.ActualizarJabonera(AMJ);
            }

            if (Pedido.IdTipMaqLav != 0)
            {
                id = Pedido.IdTipMaqLav.Value;
                AdmTipMaqLav ATML = RTML.GetLavavajillasByID(id).First();
                ATML.Stock = ATML.Stock - Pedido.CanTipMaqLav;
                RTML.ActualizarLavavajillas(ATML);
            }

            if (Pedido.IdModEqDos != 0)
            {
                id = Pedido.IdModEqDos.Value;
                AdmModEqDos AMED = RMED.GetEquipoDosificadorByID(id).First();
                AMED.EqDisponibles = AMED.EqDisponibles - Pedido.CanModEqDos;
                RMED.ActualizarEquipoDosificador(AMED);
            }

            if (Pedido.IdPorGalon != 0)
            {
                id = Pedido.IdPorGalon.Value;
                AdmPortGalon APG = RPG.GetGaloneraByID(id).First();
                APG.Stock = APG.Stock - Pedido.CanPorGalon;
                RPG.ActualizarGalonera(APG);
            }

            List<AdmCepInBas> ACIB = RCIB.GetAllConsumibles();
            for(int i = 0; i < ACIB.Count(); i++)
            {
                ACIB[i].Stock = ACIB[i].Stock - Pedido.CanCepInBas;
                RCIB.ActualizarConsumibles(ACIB[i]);
            }




            return res;
        }

    }
}
