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

        public string ActualizarPedido(PedidosArea Pedido)
        {
            return "";
        }

        public ComprobacionDePedidos ValidacionCreate(PedidosArea Pedido)
        {
            ComprobacionDePedidos CDP = new ComprobacionDePedidos();
            int id = 0;
            
            RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
            id = Pedido.IdDosEstLim.Value;
            AdmDosEstLim dosEstacion = RDEL.GetEstacionesByID(id).First();

            if (dosEstacion.EqDisponibles >= Pedido.CanDosEstLim)
            {
                CDP._DosEstLimStock = true;
            }

            RepositoryCepInsBas RCIB = new RepositoryCepInsBas();

            List<AdmCepInBas> listAdm = RCIB.GetAllConsumibles();

            int count = 0;

            foreach (var item in listAdm)
            {

                if (item.Stock >= Pedido.CanCepInBas)
                    count += 1;

            }

            if (count == 3)
            {
                CDP._CepInBasStock = true;
            }

            RepositoryProdQuim RPQ = new RepositoryProdQuim();

            List<string> listQuimicos = getProductos(Pedido.ProdQuim);

            List<AdmProdQuim> listAdmProdQuim = new List<AdmProdQuim>();
            count = 0;

            for (int i = 0; i < listQuimicos.Count(); i++)
            {
                listAdmProdQuim.Add(RPQ.GetQuimicoByName(listQuimicos[i])[0]);

                if (listAdmProdQuim[i].Stock >= 1)
                {
                    count += 1;
                }
            }
            if (count == listQuimicos.Count())
            {
                CDP._QuimicosStock = true;
            }

            //ModJabStock
            RepositoryModJab RMJ = new RepositoryModJab();

            int? stockModJabStock = RMJ.GetJaboneraByID(Pedido.IdModJab.Value)[0].Stock;

            if (stockModJabStock >= Pedido.CanModJab)
            {
                CDP._ModJabStock = true;
            }

            //TipMaqLavStock

            RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();

            int? stockTipMaqLavStock = RTML.GetLavavajillasByID(Pedido.IdTipMaqLav.Value)[0].Stock;

            if (stockTipMaqLavStock >= Pedido.CanTipMaqLav)
            {
                CDP._TipMaqLavStock = true;
            }

            //DosLavStock
            RepositoryDosLav RDL = new RepositoryDosLav();

            List<string> listDosLav = getProductos(Pedido.DosLav);

            List<AdmDosLav> listDosLav2 = new List<AdmDosLav>();
            count = 0;
            for (int i = 0; i < listDosLav.Count(); i++)
            {
                listDosLav2.Add(RDL.GetDosificadoresByName(listDosLav[i])[0]);

                if (listDosLav2[i].Stock >= 1)
                {
                    count += 1;
                }
            }

            if (count == listDosLav.Count())
            {
                CDP._DosLavStock = true;
            }

            //ModEqDos pendiente
            RepositoryModEqDos RMED = new RepositoryModEqDos();

            int? stockModEqDos = RMED.GetEquipoDosificadorByID(Pedido.IdModEqDos.Value)[0].EqDisponibles;

            if (stockModEqDos >= Pedido.CanModEqDos)
            {
                CDP._ModEqDos = true;
            }

            //PorGalon

            RepositoryPortGalon RPG = new RepositoryPortGalon();

            int? stockPorGalon = RPG.GetGaloneraByID(Pedido.IdPorGalon.Value)[0].Stock;

            if (stockPorGalon >= Pedido.CanPorGalon)
            {
                CDP._PorGalon = true;
            }

            return CDP;
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

        public ComprobacionDePedidos ValidacionUpdate(PedidosArea Pedido)
        {
            return null;
        }

        public bool ModificadorStockUpdate(PedidosArea Pedido)
        {
            return false;
        }

        public List<string> getProductos(string cadena)
        {
            List<string> quimicosList = new List<string>();
            string[] quimicos = null;

            if (cadena != "")
            {

                quimicos = cadena.Split('.');

                foreach (var item in quimicos)
                {
                    quimicosList.Add(item);

                }

                return quimicosList;
            }
            else
            {
                return null;
            }

        }

    }
}
