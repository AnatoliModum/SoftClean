using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
    public class ControlDeStocks
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
            int? id = 0;
            int count = 0;
            
            RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
            id = Pedido.IdDosEstLim;
            if (id == null || id.Value == 0 || Pedido.CanDosEstLim == null)
            {
                CDP._DosEstLimStock = true;
            }
            else
            {
                AdmDosEstLim dosEstacion = RDEL.GetEstacionesByID(id.Value).First();

                if (dosEstacion.EqDisponibles >= Pedido.CanDosEstLim)
                {
                    CDP._DosEstLimStock = true;
                }
            }

            if (Pedido.CanCepInBas == null || Pedido.CanCepInBas.Value == 0)
            {
                CDP._CepInBasStock = true;
            }
            else
            {
                RepositoryCepInsBas RCIB = new RepositoryCepInsBas();

                List<AdmCepInBas> listAdm = RCIB.GetAllConsumibles();

                count = 0;

                foreach (var item in listAdm)
                {

                    if (item.Stock >= Pedido.CanCepInBas)
                        count += 1;

                }

                if (count == 3)
                {
                    CDP._CepInBasStock = true;
                }
            }


            if (!string.IsNullOrEmpty(Pedido.ProdQuim))
            {
                RepositoryProdQuim RPQ = new RepositoryProdQuim();

                List<string> listQuimicos = getProductos(Pedido.ProdQuim);

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
            }
            else
            {
                CDP._QuimicosStock = true;
            }


            //ModJabStock

            if (Pedido.IdModJab == null || Pedido.IdModJab.Value == 0 || Pedido.CanModJab == null)
            {
                CDP._ModJabStock = true;
            }
            else
            {
                RepositoryModJab RMJ = new RepositoryModJab();

                int? stockModJabStock = RMJ.GetJaboneraByID(Pedido.IdModJab.Value).First().Stock;

                if (stockModJabStock >= Pedido.CanModJab)
                {
                    CDP._ModJabStock = true;
                }
            }


            //TipMaqLavStock
            if (Pedido.IdTipMaqLav == null || Pedido.IdTipMaqLav.Value == 0 || Pedido.CanTipMaqLav == null)
            {
                CDP._TipMaqLavStock = true;
            }
            else
            {
                RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();

                int? stockTipMaqLavStock = RTML.GetLavavajillasByID(Pedido.IdTipMaqLav.Value).First().Stock;

                if (stockTipMaqLavStock >= Pedido.CanTipMaqLav)
                {
                    CDP._TipMaqLavStock = true;
                }
            }


            //DosLavStock

            if (!string.IsNullOrEmpty(Pedido.DosLav))
            {
                RepositoryDosLav RDL = new RepositoryDosLav();

                List<string> listDosLav = getProductos(Pedido.DosLav);

                List<AdmDosLav> listDosLav2 = new List<AdmDosLav>();
                count = 0;
                for (int i = 0; i < listDosLav.Count(); i++)
                {
                    listDosLav2.Add(RDL.GetDosificadoresByName(listDosLav[i])[0]);

                    if (listDosLav2[i].Stock >= 1 || listDosLav2[i].Stock == null)
                    {
                        count += 1;
                    }
                }

                if (count == listDosLav.Count())
                {
                    CDP._DosLavStock = true;
                }
            }
            else
            {
                CDP._DosLavStock = true;
            }


            //ModEqDos pendiente
            if (Pedido.IdModEqDos == null || Pedido.IdModEqDos.Value == 0 || Pedido.CanModEqDos == null)
            {
                CDP._ModEqDos = true;
            }
            else
            {
                RepositoryModEqDos RMED = new RepositoryModEqDos();

                int? stockModEqDos = RMED.GetEquipoDosificadorByID(Pedido.IdModEqDos.Value).First().EqDisponibles;

                if (stockModEqDos >= Pedido.CanModEqDos)
                {
                    CDP._ModEqDos = true;
                }
            }


            //PorGalon
            if (Pedido.IdPorGalon == null || Pedido.IdPorGalon.Value == 0 || Pedido.CanPorGalon == null)
            {
                CDP._PorGalon = true;
            }
            else
            {
                RepositoryPortGalon RPG = new RepositoryPortGalon();

                int? stockPorGalon = RPG.GetGaloneraByID(Pedido.IdPorGalon.Value).First().Stock;

                if (stockPorGalon >= Pedido.CanPorGalon)
                {
                    CDP._PorGalon = true;
                }
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
            if (Pedido.IdDosEstLim != 0 && Pedido.IdDosEstLim != null)
            {
                id = Pedido.IdDosEstLim.Value;
                AdmDosEstLim ADEL = RDEL.GetEstacionesByID(id).First();
                ADEL.EqDisponibles = ADEL.EqDisponibles - Pedido.CanDosEstLim;
                if (RDEL.ActualizarEstacion(ADEL)) { res = true; } else { return res = false; }
            }

            if (Pedido.IdModJab != 0 && Pedido.IdModJab != null)
            {
                id = Pedido.IdModJab.Value;
                AdmModJab AMJ = RMJ.GetJaboneraByID(id).First();
                AMJ.Stock = AMJ.Stock - Pedido.CanModJab;
                if (RMJ.ActualizarJabonera(AMJ)) { res = true; } else { return res = false; }
            }

            if (Pedido.IdTipMaqLav != 0 && Pedido.IdTipMaqLav != null)
            {
                id = Pedido.IdTipMaqLav.Value;
                AdmTipMaqLav ATML = RTML.GetLavavajillasByID(id).First();
                ATML.Stock = ATML.Stock - Pedido.CanTipMaqLav;
                if (RTML.ActualizarLavavajillas(ATML)) { res = true; } else { return res = false; }
            }

            if (Pedido.IdModEqDos != 0 && Pedido.IdModEqDos != null)
            {
                id = Pedido.IdModEqDos.Value;
                AdmModEqDos AMED = RMED.GetEquipoDosificadorByID(id).First();
                AMED.EqDisponibles = AMED.EqDisponibles - Pedido.CanModEqDos;
                if (RMED.ActualizarEquipoDosificador(AMED)) { res = true; } else { return res = false; }
            }

            if (Pedido.IdPorGalon != 0 && Pedido.IdPorGalon != null)
            {
                id = Pedido.IdPorGalon.Value;
                AdmPortGalon APG = RPG.GetGaloneraByID(id).First();
                APG.Stock = APG.Stock - Pedido.CanPorGalon;
                if (RPG.ActualizarGalonera(APG)) { res = true; } else { return res = false; }
            }
            #endregion

            #region consumibles
            if (Pedido.CanCepInBas != 0 && Pedido.CanCepInBas != null)
            {
                List<AdmCepInBas> ACIB = RCIB.GetAllConsumibles();
                for (int i = 0; i < ACIB.Count(); i++)
                {
                    ACIB[i].Stock = ACIB[i].Stock - Pedido.CanCepInBas;
                    if(RCIB.ActualizarConsumibles(ACIB[i])) { res = true; } else { return res = false; }
            }
            }
            #endregion

            #region Quimicos
            if (Pedido.ProdQuim.Length > 1 && Pedido.ProdQuim != null)
            {
                RepositoryProdQuim quimico = new RepositoryProdQuim();
                AdmProdQuim ProductoQuimico = new AdmProdQuim();
                List<String> listaQuimicos = getProductos(Pedido.ProdQuim);

                for (int i = 0; i < getProductos(Pedido.ProdQuim).Count; i++) // Quita el stock que se requiere en el pedido nuevo
                {
                    ProductoQuimico = quimico.GetQuimicoByName(listaQuimicos[i]).First();
                    ProductoQuimico.Stock -= 1;
                    if(quimico.ActualizarQuimico(ProductoQuimico)) { res = true; } else { return res = false; }
            }
            }
            #endregion

            #region DosLav
            if (Pedido.DosLav.Length > 1 && Pedido.DosLav != null)
            {
                AdmDosLav Dosificador = new AdmDosLav();
                List<String> listaDosificadores = getProductos(Pedido.DosLav);

                for (int i = 0; i < listaDosificadores.Count; i++) // Quita el stock que se requiere en el pedido nuevo
                {
                    Dosificador = RDL.GetDosificadoresByName(listaDosificadores[i]).First();
                    Dosificador.Stock -= 1;
                    if(RDL.ActualizarDosificador(Dosificador)) { res = true; } else { return res = false; }
                }
            }
            #endregion

            return res;
        }

        private ComprobacionDePedidos ValidacionUpdate(PedidosArea PedidoNew)
        {
            int count = 0;
            ComprobacionDePedidos CDP = new ComprobacionDePedidos();

            RepositoryPedidosArea RPA = new RepositoryPedidosArea();
            PedidosArea pedidoOld = RPA.GetPedidoByID(PedidoNew.id).First();

            //DosEstLimStock
            RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();

            if (PedidoNew.IdDosEstLim == null || PedidoNew.IdDosEstLim.Value == 0 || PedidoNew.CanDosEstLim == null)
            {
                CDP._DosEstLimStock = true;
            }
            else
            {
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
            }


            //ModJabStock
            if (PedidoNew.IdModJab == null || PedidoNew.IdModJab.Value == 0 || PedidoNew.CanModJab == 0)
            {
                CDP._ModJabStock = true;
            }
            else
            {
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
            }


            //CepInBasStock
            if (PedidoNew.CanCepInBas == null)
            {
                CDP._CepInBasStock = true;
            }
            else
            {
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
            }


            //TipMaqLavStock
            if (PedidoNew.IdTipMaqLav == null || PedidoNew.IdTipMaqLav.Value == 0 || PedidoNew.CanTipMaqLav == null)
            {
                CDP._TipMaqLavStock = true;
            }
            else
            {
                RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();

                if (pedidoOld.CanTipMaqLav < PedidoNew.CanTipMaqLav)
                {
                    int? stockTipMaqLavStock = RTML.GetLavavajillasByID(PedidoNew.IdTipMaqLav.Value).First().Stock;

                    if (stockTipMaqLavStock > (PedidoNew.CanTipMaqLav - pedidoOld.CanTipMaqLav))
                    {
                        CDP._TipMaqLavStock = true;
                    }
                }
                else
                {
                    CDP._TipMaqLavStock = true;
                }
            }


            //QuimicosStock

            if (string.IsNullOrEmpty(PedidoNew.ProdQuim))
            {
                CDP._QuimicosStock = true;
            }
            else
            {
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
            }


            //DosLavStock
            if (string.IsNullOrEmpty(PedidoNew.DosLav))
            {
                CDP._DosLavStock = true;
            }
            else
            {
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
            }


            //ModEqDos
            if (PedidoNew.IdModEqDos == null || PedidoNew.IdModEqDos.Value == 0 || PedidoNew.CanModEqDos == null)
            {
                CDP._ModEqDos = true;
            }
            else
            {
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
            }

            //PorGalon
            if (PedidoNew.IdPorGalon == null || PedidoNew.IdPorGalon.Value == 0 || PedidoNew.CanPorGalon == null)
            {
                CDP._PorGalon = true;
            }
            else
            {
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
            }


            return CDP;
        }

        private bool ModificadorStockUpdate(PedidosArea PedidoNuevo, PedidosArea PedidoAntiguo)
        {
            #region Variables Constantes
            int id = PedidoNuevo.id;
            RepositoryPedidosArea RPA = new RepositoryPedidosArea();
            bool res = false;
            #endregion

            #region condicionales constantes

            if (PedidoNuevo.IdDosEstLim != 0 && PedidoNuevo.IdDosEstLim != null)
            {
                if (PedidoAntiguo.CanDosEstLim < PedidoNuevo.CanDosEstLim)
                {
                    RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
                    id = PedidoNuevo.IdDosEstLim.Value;
                    AdmDosEstLim entidad = RDEL.GetEstacionesByID(id).First();

                    entidad.EqDisponibles = entidad.EqDisponibles - (PedidoNuevo.CanDosEstLim - PedidoAntiguo.CanDosEstLim);
                    if (RDEL.ActualizarEstacion(entidad)) { res = true; } else { return res = false; }
                }
                else
                {
                    RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
                    id = PedidoNuevo.IdDosEstLim.Value;
                    AdmDosEstLim entidad = RDEL.GetEstacionesByID(id).First();

                    entidad.EqDisponibles = entidad.EqDisponibles + (PedidoAntiguo.CanDosEstLim - PedidoNuevo.CanDosEstLim);
                    if (RDEL.ActualizarEstacion(entidad)) { res = true; } else { return res = false; }
                }
            }

            if (PedidoNuevo.IdModJab != 0 && PedidoNuevo.IdModJab != null)
            {
                if (PedidoAntiguo.CanModJab < PedidoNuevo.CanModJab)
                {
                    RepositoryModJab RMJ = new RepositoryModJab();
                    id = PedidoNuevo.IdModJab.Value;
                    AdmModJab entidad = RMJ.GetJaboneraByID(id).First();

                    entidad.Stock = entidad.Stock - (PedidoNuevo.CanModJab - PedidoAntiguo.CanModJab);
                    if (RMJ.ActualizarJabonera(entidad)) { res = true; } else { return res = false; }
                }
                else
                {
                    RepositoryModJab RMJ = new RepositoryModJab();
                    id = PedidoNuevo.IdModJab.Value;
                    AdmModJab entidad = RMJ.GetJaboneraByID(id).First();

                    entidad.Stock = entidad.Stock + (PedidoAntiguo.CanModJab - PedidoNuevo.CanModJab);
                    if (RMJ.ActualizarJabonera(entidad)) { res = true; } else { return res = false; }
                }
            }

            if (PedidoNuevo.IdTipMaqLav != 0 && PedidoNuevo.IdTipMaqLav != null)
            {
                if (PedidoAntiguo.CanTipMaqLav < PedidoNuevo.CanTipMaqLav)
                {
                    RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();
                    id = PedidoNuevo.IdTipMaqLav.Value;
                    AdmTipMaqLav entidad = RTML.GetLavavajillasByID(id).First();

                    entidad.Stock = entidad.Stock - (PedidoNuevo.CanTipMaqLav - PedidoAntiguo.CanTipMaqLav);
                    if (RTML.ActualizarLavavajillas(entidad)) { res = true; } else { return res = false; }
                }
                else
                {
                    RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();
                    id = PedidoNuevo.IdTipMaqLav.Value;
                    AdmTipMaqLav entidad = RTML.GetLavavajillasByID(id).First();

                    entidad.Stock = entidad.Stock + (PedidoAntiguo.CanTipMaqLav - PedidoNuevo.CanTipMaqLav);
                    if (RTML.ActualizarLavavajillas(entidad)) { res = true; } else { return res = false; }
                }
            }

            if (PedidoNuevo.IdModEqDos != 0 && PedidoNuevo.IdModEqDos != null)
            {
                if (PedidoAntiguo.CanModEqDos < PedidoNuevo.CanModEqDos)
                {
                    RepositoryModEqDos RMED = new RepositoryModEqDos();
                    id = PedidoNuevo.IdModEqDos.Value;
                    AdmModEqDos entidad = RMED.GetEquipoDosificadorByID(id).First();

                    entidad.EqDisponibles = entidad.EqDisponibles - (PedidoNuevo.CanModEqDos - PedidoAntiguo.CanModEqDos);
                    if (RMED.ActualizarEquipoDosificador(entidad)) { res = true; } else { return res = false; }
                }
                else
                {
                    RepositoryModEqDos RMED = new RepositoryModEqDos();
                    id = PedidoNuevo.IdModEqDos.Value;
                    AdmModEqDos entidad = RMED.GetEquipoDosificadorByID(id).First();

                    entidad.EqDisponibles = entidad.EqDisponibles + (PedidoAntiguo.CanModEqDos - PedidoNuevo.CanModEqDos);
                    if (RMED.ActualizarEquipoDosificador(entidad)) { res = true; } else { return res = false; }
                }
            }

            if (PedidoNuevo.IdPorGalon != 0 && PedidoNuevo.IdPorGalon != null)
            {
                if (PedidoAntiguo.CanPorGalon < PedidoNuevo.CanPorGalon)
                {
                    RepositoryPortGalon RPG = new RepositoryPortGalon();
                    id = PedidoNuevo.IdPorGalon.Value;
                    AdmPortGalon entidad = RPG.GetGaloneraByID(id).First();

                    entidad.Stock = entidad.Stock - (PedidoNuevo.CanPorGalon - PedidoAntiguo.CanPorGalon);
                    if (RPG.ActualizarGalonera(entidad)) { res = true; } else { return res = false; }
                }
                else
                {
                    RepositoryPortGalon RPG = new RepositoryPortGalon();
                    id = PedidoNuevo.IdPorGalon.Value;
                    AdmPortGalon entidad = RPG.GetGaloneraByID(id).First();

                    entidad.Stock = entidad.Stock + (PedidoAntiguo.CanPorGalon - PedidoNuevo.CanPorGalon);
                    if (RPG.ActualizarGalonera(entidad)) { res = true; } else { return res = false; }
                }
            }
            #endregion

            #region Consumibles
            if (PedidoNuevo.CanCepInBas != 0 && PedidoNuevo.CanCepInBas != null)
            {
                RepositoryCepInsBas RCIB = new RepositoryCepInsBas();
                List<AdmCepInBas> ListaConsumibles = RCIB.GetAllConsumibles();

                if (PedidoAntiguo.CanCepInBas < PedidoNuevo.CanCepInBas)
                {
                    int Diferencia = PedidoNuevo.CanCepInBas.Value - PedidoAntiguo.CanCepInBas.Value;

                    for (int i = 0; i < ListaConsumibles.Count(); i++)
                    {
                        ListaConsumibles[i].Stock = ListaConsumibles[i].Stock - Diferencia;
                        if (RCIB.ActualizarConsumibles(ListaConsumibles[i])) { res = true; } else { return res = false; }
                    }
                }
                else
                {
                    int Diferencia = PedidoAntiguo.CanCepInBas.Value - PedidoNuevo.CanCepInBas.Value;

                    for (int i = 0; i < ListaConsumibles.Count(); i++)
                    {
                        ListaConsumibles[i].Stock = ListaConsumibles[i].Stock + Diferencia;
                        if (RCIB.ActualizarConsumibles(ListaConsumibles[i])) { res = true; } else { return res = false; }
                    }
                }
            }
            #endregion

            #region Quimicos
            if (PedidoNuevo.ProdQuim.Length != 0 && PedidoNuevo.IdModEqDos != null)
            {
                RepositoryProdQuim quimico = new RepositoryProdQuim();
                AdmProdQuim ProductoQuimico = new AdmProdQuim();
                List<String> listaQuimicosNuevos = getProductos(PedidoNuevo.ProdQuim);
                List<String> listaQuimicosAntiguos = getProductos(PedidoAntiguo.ProdQuim);

                for (int i = 0; i < getProductos(PedidoAntiguo.ProdQuim).Count; i++) // Regenera el stock que se quito en el pedido original
                {
                    ProductoQuimico = quimico.GetQuimicoByName(listaQuimicosAntiguos[i]).First();
                    ProductoQuimico.Stock += 1;
                    if (quimico.ActualizarQuimico(ProductoQuimico)) { res = true; } else { return res = false; }
                }

                for (int i = 0; i < getProductos(PedidoNuevo.ProdQuim).Count; i++) // Quita el stock que se requiere en el pedido nuevo
                {
                    ProductoQuimico = quimico.GetQuimicoByName(listaQuimicosNuevos[i]).First();
                    ProductoQuimico.Stock -= 1;
                    if (quimico.ActualizarQuimico(ProductoQuimico)) { res = true; } else { return res = false; }
                }
            }
            #endregion

            #region DosLav
            if (PedidoNuevo.DosLav.Length != 0 && PedidoNuevo.IdModEqDos != null)
            {
                RepositoryDosLav RDL = new RepositoryDosLav();
                AdmDosLav dosificador = new AdmDosLav();
                List<String> listaDosificadoresNuevos = getProductos(PedidoNuevo.DosLav);
                List<String> listaDosificadoresAntiguos = getProductos(PedidoAntiguo.DosLav);

                for (int i = 0; i < getProductos(PedidoAntiguo.DosLav).Count; i++) // Regenera el stock que se quito en el pedido original
                {
                    dosificador = RDL.GetDosificadoresByName(listaDosificadoresAntiguos[i]).First();
                    dosificador.Stock += 1;
                    if (RDL.ActualizarDosificador(dosificador)) { res = true; } else { return res = false; }
                }

                for (int i = 0; i < getProductos(PedidoNuevo.DosLav).Count; i++) // Quita el stock que se requiere en el pedido nuevo
                {
                    dosificador = RDL.GetDosificadoresByName(listaDosificadoresNuevos[i]).First();
                    dosificador.Stock -= 1;
                    if (RDL.ActualizarDosificador(dosificador)) { res = true; } else { return res = false; }
                }
            }
            #endregion
            
            return res;
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
                    if (!string.IsNullOrEmpty(item))
                    {
                        quimicosList.Add(item);
                    }

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
