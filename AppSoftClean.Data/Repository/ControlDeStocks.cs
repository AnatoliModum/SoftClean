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

        public string ActualizarPedido(PedidosArea PedidoNuevo)
        {
            String res = "";
            ComprobacionDePedidos com = this.ValidacionUpdate(PedidoNuevo);
            RepositoryPedidosArea RPA = new RepositoryPedidosArea();
            PedidosArea PedidoAntiguo = RPA.GetPedidoByID(PedidoNuevo.id).First();

            if (com._CepInBasStock && com._DosEstLimStock && com._DosLavStock && com._ModEqDos &&
                com._ModJabStock && com._PorGalon && com._QuimicosStock && com._TipMaqLavStock)
            {
                if (RPA.ActualizarPedido(PedidoNuevo))
                {
                    if (!this.ModificadorStockUpdate(PedidoNuevo , PedidoAntiguo))
                    {
                        res = "Pedido creado exitosamente, error al modificar el stock";
                    }
                }
                else
                {
                    res = "Error al actualizar el pedido";
                }
            }
            else
            {
                res = "No se puede actualizar el pedido, por favor, verifique el stock de los siguientes productos \n" + Environment.NewLine;

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

        public void EliminarPedido(PedidosArea Pedido)
        {
            int id = 0;

            RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
            RepositoryModJab RMJ = new RepositoryModJab();
            RepositoryCepInsBas RCIB = new RepositoryCepInsBas(); //MultiEntidad
            RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();
            RepositoryProdQuim RPQ = new RepositoryProdQuim(); //String
            RepositoryDosLav RDL = new RepositoryDosLav(); //String
            RepositoryModEqDos RMED = new RepositoryModEqDos();
            RepositoryPortGalon RPG = new RepositoryPortGalon();

            #region Modificaciones constantes
            if (Pedido.IdDosEstLim != 0)
            {
                id = Pedido.IdDosEstLim.Value;
                AdmDosEstLim ADEL = RDEL.GetEstacionesByID(id).First();
                ADEL.EqDisponibles += 1;
                RDEL.ActualizarEstacion(ADEL);
            }

            if (Pedido.IdModJab != 0)
            {
                id = Pedido.IdModJab.Value;
                AdmModJab AMJ = RMJ.GetJaboneraByID(id).First();
                AMJ.Stock += 1;
                RMJ.ActualizarJabonera(AMJ);
            }

            if (Pedido.IdTipMaqLav != 0)
            {
                id = Pedido.IdTipMaqLav.Value;
                AdmTipMaqLav ATML = RTML.GetLavavajillasByID(id).First();
                ATML.Stock += 1;
                RTML.ActualizarLavavajillas(ATML);
            }

            if (Pedido.IdModEqDos != 0)
            {
                id = Pedido.IdModEqDos.Value;
                AdmModEqDos AMED = RMED.GetEquipoDosificadorByID(id).First();
                AMED.EqDisponibles += 1;
                RMED.ActualizarEquipoDosificador(AMED);
            }

            if (Pedido.IdPorGalon != 0)
            {
                id = Pedido.IdPorGalon.Value;
                AdmPortGalon APG = RPG.GetGaloneraByID(id).First();
                APG.Stock += 1;
                RPG.ActualizarGalonera(APG);
            }
            #endregion

            #region consumibles
            List<AdmCepInBas> ACIB = RCIB.GetAllConsumibles();
            for (int i = 0; i < ACIB.Count(); i++)
            {
                ACIB[i].Stock += 1;
                RCIB.ActualizarConsumibles(ACIB[i]);
            }
            #endregion

            #region Quimicos
            RepositoryProdQuim quimico = new RepositoryProdQuim();
            AdmProdQuim ProductoQuimico = new AdmProdQuim();
            List<String> listaQuimicos = getProductos(Pedido.ProdQuim);

            for (int i = 0; i < getProductos(Pedido.ProdQuim).Count; i++) // Quita el stock que se requiere en el pedido nuevo
            {
                ProductoQuimico = quimico.GetQuimicoByName(listaQuimicos[i]).First();
                ProductoQuimico.Stock += 1;
                quimico.ActualizarQuimico(ProductoQuimico);
            }
            #endregion

            #region DosLav
            AdmDosLav Dosificador = new AdmDosLav();
            List<String> listaDosificadores = getProductos(Pedido.DosLav);

            for (int i = 0; i < listaDosificadores.Count; i++) // Quita el stock que se requiere en el pedido nuevo
            {
                Dosificador = RDL.GetDosificadoresByName(listaDosificadores[i]).First();
                Dosificador.Stock += 1;
                RDL.ActualizarDosificador(Dosificador);
            }
            #endregion
            
        }

        private ComprobacionDePedidos ValidacionCreate(PedidosArea Pedido)
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

        private bool ModificadorStockCreate(PedidosArea Pedido)
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

            #region Modificaciones constantes
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
            #endregion

            #region consumibles
            List<AdmCepInBas> ACIB = RCIB.GetAllConsumibles();
            for(int i = 0; i < ACIB.Count(); i++)
            {
                ACIB[i].Stock = ACIB[i].Stock - Pedido.CanCepInBas;
                RCIB.ActualizarConsumibles(ACIB[i]);
            }
            #endregion

            #region Quimicos
            RepositoryProdQuim quimico = new RepositoryProdQuim();
            AdmProdQuim ProductoQuimico = new AdmProdQuim();
            List<String> listaQuimicos = getProductos(Pedido.ProdQuim);

            for (int i = 0; i < getProductos(Pedido.ProdQuim).Count; i++) // Quita el stock que se requiere en el pedido nuevo
            {
                ProductoQuimico = quimico.GetQuimicoByName(listaQuimicos[i]).First();
                ProductoQuimico.Stock -= 1;
                quimico.ActualizarQuimico(ProductoQuimico);
            }
            #endregion

            #region DosLav
            AdmDosLav Dosificador = new AdmDosLav();
            List<String> listaDosificadores = getProductos(Pedido.DosLav);

            for (int i = 0; i < listaDosificadores.Count; i++) // Quita el stock que se requiere en el pedido nuevo
            {
                Dosificador = RDL.GetDosificadoresByName(listaDosificadores[i]).First();
                Dosificador.Stock -= 1;
                RDL.ActualizarDosificador(Dosificador);
            }
            #endregion

            return res;
        }

        private ComprobacionDePedidos ValidacionUpdate(PedidosArea PedidoNew)
        {
            int count = 0;
            ComprobacionDePedidos CDP = new ComprobacionDePedidos();

            RepositoryPedidosArea RPA = new RepositoryPedidosArea();
            PedidosArea pedidoOld =RPA.GetPedidoByID(PedidoNew.id).First();

            //DosEstLimStock
            RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();

            if (pedidoOld.CanDosEstLim < PedidoNew.CanDosEstLim)
            {
                int? stockDosEstLimStock = RDEL.GetEstacionesByID(PedidoNew.IdDosEstLim.Value).First().EqDisponibles;

                if (stockDosEstLimStock > (PedidoNew.CanDosEstLim - pedidoOld.CanDosEstLim))
                {
                    CDP._DosEstLimStock = true;

                }
            }
            else
            {
                CDP._DosEstLimStock = true;
            }

            //ModJabStock
            RepositoryModJab RMJ = new RepositoryModJab();

            if (pedidoOld.CanModJab < PedidoNew.CanModJab)
            {
                int? stockModJabStock = RMJ.GetJaboneraByID(PedidoNew.IdModJab.Value).First().Stock;

                if (stockModJabStock > (PedidoNew.CanModJab - pedidoOld.CanModJab))
                {
                    CDP._ModJabStock = true;
                }
            }
            else
            {
                CDP._ModJabStock = true;
            }

            //CepInBasStock
            RepositoryCepInsBas RCIB = new RepositoryCepInsBas();

            if (pedidoOld.CanCepInBas < PedidoNew.CanCepInBas)
            {
                List<AdmCepInBas> listAdm = RCIB.GetAllConsumibles();

                foreach (var item in listAdm)
                {
                    if (item.Stock > (PedidoNew.CanCepInBas - pedidoOld.CanCepInBas))
                    {
                        count += 1;
                    }
                }

                if (count == 3)
                {
                    CDP._CepInBasStock = true;
                }
            }
            else
            {
                CDP._CepInBasStock = true;
            }

            //TipMaqLavStock
            RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();

            if (pedidoOld.CanTipMaqLav < PedidoNew.CanTipMaqLav)
            {
                int? stockTipMaqLavStock = RTML.GetLavavajillasByID(PedidoNew.IdTipMaqLav.Value)[0].Stock;

                if (stockTipMaqLavStock > (PedidoNew.CanTipMaqLav - pedidoOld.CanTipMaqLav))
                {
                    CDP._TipMaqLavStock = true;
                }
            }
            else
            {
                CDP._TipMaqLavStock = true;
            }

            //QuimicosStock
            RepositoryProdQuim RPQ = new RepositoryProdQuim();

            List<string> listQuimicos = getProductos(PedidoNew.ProdQuim);

            List<AdmProdQuim> listAdmProdQuim = new List<AdmProdQuim>();
            count = 0;

            for (int i = 0; i < listQuimicos.Count(); i++)
            {
                listAdmProdQuim.Add(RPQ.GetQuimicoByName(listQuimicos[i]).First());

                if (listAdmProdQuim[i].Stock >= 1)
                {
                    count += 1;
                }
            }
            if (count == listQuimicos.Count())
            {
                CDP._QuimicosStock = true;
            }

            //DosLavStock
            RepositoryDosLav RDL = new RepositoryDosLav();

            List<string> listDosLav = getProductos(PedidoNew.DosLav);

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

            //ModEqDos
            RepositoryModEqDos RMED = new RepositoryModEqDos();

            if (pedidoOld.CanModEqDos < PedidoNew.CanModEqDos)
            {
                int? stockModEqDos = RMED.GetEquipoDosificadorByID(PedidoNew.IdModEqDos.Value).First().EqDisponibles;

                if (stockModEqDos > (PedidoNew.CanModEqDos - pedidoOld.CanModEqDos))
                {
                    CDP._ModEqDos = true;
                }
            }
            else
            {
                CDP._ModEqDos = true;
            }

            //PorGalon
            RepositoryPortGalon RPG = new RepositoryPortGalon();

            if (pedidoOld.CanPorGalon < PedidoNew.CanPorGalon)
            {
                int? stockPorGalon = RPG.GetGaloneraByID(PedidoNew.IdPorGalon.Value).First().Stock;

                if (stockPorGalon > (PedidoNew.CanPorGalon - pedidoOld.CanPorGalon))
                {
                    CDP._PorGalon = true;
                }
            }
            else
            {
                CDP._PorGalon = true;
            }

            return CDP;
        }

        private bool ModificadorStockUpdate(PedidosArea PedidoNuevo, PedidosArea PedidoAntiguo)
        {
            #region Variables Constantes
            int id = PedidoNuevo.id;
            RepositoryPedidosArea RPA = new RepositoryPedidosArea();
            #endregion

            #region condicionales constantes
            if (PedidoAntiguo.CanDosEstLim < PedidoNuevo.CanDosEstLim)
            {
                RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
                id = PedidoNuevo.IdDosEstLim.Value;
                AdmDosEstLim entidad = RDEL.GetEstacionesByID(id).First();

                entidad.EqDisponibles = entidad.EqDisponibles - (PedidoNuevo.CanDosEstLim - PedidoAntiguo.CanDosEstLim);
            }
            else
            {
                RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
                id = PedidoNuevo.IdDosEstLim.Value;
                AdmDosEstLim entidad = RDEL.GetEstacionesByID(id).First();

                entidad.EqDisponibles = entidad.EqDisponibles + (PedidoAntiguo.CanDosEstLim - PedidoNuevo.CanDosEstLim);
            }

            if (PedidoAntiguo.CanModJab < PedidoNuevo.CanModJab)
            {
                RepositoryModJab RMJ = new RepositoryModJab();
                id = PedidoNuevo.IdModJab.Value;
                AdmModJab entidad = RMJ.GetJaboneraByID(id).First();

                entidad.Stock = entidad.Stock - (PedidoNuevo.CanModJab - PedidoAntiguo.CanModJab);
            }
            else
            {
                RepositoryModJab RMJ = new RepositoryModJab();
                id = PedidoNuevo.IdModJab.Value;
                AdmModJab entidad = RMJ.GetJaboneraByID(id).First();

                entidad.Stock = entidad.Stock + (PedidoAntiguo.CanModJab - PedidoNuevo.CanModJab);
            }

            if (PedidoAntiguo.CanTipMaqLav < PedidoNuevo.CanTipMaqLav)
            {
                RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();
                id = PedidoNuevo.IdTipMaqLav.Value;
                AdmTipMaqLav entidad = RTML.GetLavavajillasByID(id).First();

                entidad.Stock = entidad.Stock - (PedidoNuevo.CanTipMaqLav - PedidoAntiguo.CanTipMaqLav);
            }
            else
            {
                RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();
                id = PedidoNuevo.IdTipMaqLav.Value;
                AdmTipMaqLav entidad = RTML.GetLavavajillasByID(id).First();

                entidad.Stock = entidad.Stock + (PedidoAntiguo.CanTipMaqLav - PedidoNuevo.CanTipMaqLav);
            }

            if (PedidoAntiguo.CanModEqDos < PedidoNuevo.CanModEqDos)
            {
                RepositoryModEqDos RMED = new RepositoryModEqDos();
                id = PedidoNuevo.IdModEqDos.Value;
                AdmModEqDos entidad = RMED.GetEquipoDosificadorByID(id).First();

                entidad.EqDisponibles = entidad.EqDisponibles - (PedidoNuevo.CanModEqDos - PedidoAntiguo.CanModEqDos);
            }
            else
            {
                RepositoryModEqDos RMED = new RepositoryModEqDos();
                id = PedidoNuevo.IdModEqDos.Value;
                AdmModEqDos entidad = RMED.GetEquipoDosificadorByID(id).First();

                entidad.EqDisponibles = entidad.EqDisponibles + (PedidoAntiguo.CanModEqDos - PedidoNuevo.CanModEqDos);
            }

            if (PedidoAntiguo.CanPorGalon < PedidoNuevo.CanPorGalon)
            {
                RepositoryPortGalon RPG = new RepositoryPortGalon();
                id = PedidoNuevo.IdPorGalon.Value;
                AdmPortGalon entidad = RPG.GetGaloneraByID(id).First();

                entidad.Stock = entidad.Stock - (PedidoNuevo.CanPorGalon - PedidoAntiguo.CanPorGalon);
            }
            else
            {
                RepositoryPortGalon RPG = new RepositoryPortGalon();
                id = PedidoNuevo.IdPorGalon.Value;
                AdmPortGalon entidad = RPG.GetGaloneraByID(id).First();

                entidad.Stock = entidad.Stock + (PedidoAntiguo.CanPorGalon - PedidoNuevo.CanPorGalon);
            }
            #endregion

            #region Consumibles
            RepositoryCepInsBas RCIB = new RepositoryCepInsBas();
            List<AdmCepInBas> ListaConsumibles = RCIB.GetAllConsumibles();
            
            if(PedidoAntiguo.CanCepInBas < PedidoNuevo.CanCepInBas)
            {
                int Diferencia = PedidoNuevo.CanCepInBas.Value - PedidoAntiguo.CanCepInBas.Value;

                for (int i = 0; i < ListaConsumibles.Count(); i++)
                {
                    ListaConsumibles[i].Stock = ListaConsumibles[i].Stock - Diferencia;
                }
            }
            else
            {
                int Diferencia = PedidoAntiguo.CanCepInBas.Value - PedidoNuevo.CanCepInBas.Value;

                for (int i = 0; i < ListaConsumibles.Count(); i++)
                {
                    ListaConsumibles[i].Stock = ListaConsumibles[i].Stock + Diferencia;
                }
            }
            #endregion

            #region Quimicos
            RepositoryProdQuim quimico = new RepositoryProdQuim();
            AdmProdQuim ProductoQuimico = new AdmProdQuim();
            List<String> listaQuimicosNuevos = getProductos(PedidoNuevo.ProdQuim);
            List<String> listaQuimicosAntiguos = getProductos(PedidoAntiguo.ProdQuim);
            
            for (int i = 0; i < getProductos(PedidoAntiguo.ProdQuim).Count; i++) // Regenera el stock que se quito en el pedido original
            {
                ProductoQuimico = quimico.GetQuimicoByName(listaQuimicosAntiguos[i]).First();
                ProductoQuimico.Stock += 1;
                quimico.ActualizarQuimico(ProductoQuimico);
            }

            for (int i = 0; i < getProductos(PedidoNuevo.ProdQuim).Count; i++) // Quita el stock que se requiere en el pedido nuevo
            {
                ProductoQuimico = quimico.GetQuimicoByName(listaQuimicosNuevos[i]).First();
                ProductoQuimico.Stock -= 1;
                quimico.ActualizarQuimico(ProductoQuimico);
            }
            #endregion

            #region DosLav
            RepositoryDosLav RDL = new RepositoryDosLav();
            AdmDosLav dosificador = new AdmDosLav();
            List<String> listaDosificadoresNuevos = getProductos(PedidoNuevo.DosLav);
            List<String> listaDosificadoresAntiguos = getProductos(PedidoAntiguo.DosLav);

            for (int i = 0; i < getProductos(PedidoAntiguo.DosLav).Count; i++) // Regenera el stock que se quito en el pedido original
            {
                dosificador = RDL.GetDosificadoresByName(listaDosificadoresAntiguos[i]).First();
                dosificador.Stock += 1;
                RDL.ActualizarDosificador(dosificador);
            }

            for (int i = 0; i < getProductos(PedidoNuevo.DosLav).Count; i++) // Quita el stock que se requiere en el pedido nuevo
            {
                dosificador = RDL.GetDosificadoresByName(listaDosificadoresNuevos[i]).First();
                dosificador.Stock -= 1;
                RDL.ActualizarDosificador(dosificador);
            }
            #endregion


            return false;
        }

        private List<string> getProductos(string cadena)
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
