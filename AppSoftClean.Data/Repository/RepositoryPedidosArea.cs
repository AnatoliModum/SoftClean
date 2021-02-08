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
            //RDEL = new RepositoryDosEstLimp();
            //RME = new RepositoryModEqDos();
            //RMJ = new RepositoryModJab();
            //RCIB = new RepositoryCepInsBas();
            //RTML = new RepositoryTipMaqLav();

            try
            {
                int id = 0;
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

                if (pedidoObj.CanModEqDos < Pedido.CanModEqDos)
                {
                    RME = new RepositoryModEqDos();
                    id = Pedido.IdModEqDos.Value;
                    AdmModEqDos entidad = RME.GetEquipoDosificadorByID(id).First();

                    if (entidad.EqDisponibles > (pedidoObj.CanModEqDos - Pedido.CanModEqDos))
                    {
                        entidad.EqDisponibles = entidad.EqDisponibles - (Pedido.CanModEqDos - pedidoObj.CanModEqDos);
                        RME.ActualizarEquipoDosificador(entidad);
                    }
                    else
                    {
                        res = false;
                    }
                }
                else
                {
                    id = Pedido.id;
                    AdmModEqDos AMED = RME.GetEquipoDosificadorByID(id).First();
                    AMED.EqDisponibles = AMED.EqDisponibles + (pedidoObj.CanModEqDos - Pedido.CanModEqDos);
                    RME.ActualizarEquipoDosificador(AMED);
                }

                if (pedidoObj.CanDosEstLim < Pedido.CanDosEstLim)
                {
                    id = Pedido.IdDosEstLim.Value;
                    AdmDosEstLim entidad = RDEL.GetEstacionesByID(id).First();

                    if (entidad.EqDisponibles > (pedidoObj.CanDosEstLim - Pedido.CanDosEstLim))
                    {
                        entidad.EqDisponibles = entidad.EqDisponibles - (Pedido.CanDosEstLim - pedidoObj.CanDosEstLim);
                        RDEL.ActualizarEstacion(entidad);
                    }
                    else
                    {
                        res = false;
                    }
                }
                else
                {
                    id = Pedido.IdDosEstLim.Value;
                    AdmDosEstLim entidad = RDEL.GetEstacionesByID(id).First();
                    entidad.EqDisponibles = entidad.EqDisponibles + (pedidoObj.CanDosEstLim - Pedido.CanDosEstLim);
                    RDEL.ActualizarEstacion(entidad);
                }

                if (pedidoObj.CanModJab < Pedido.CanModJab)
                {
                    id = Pedido.IdModJab.Value;
                    AdmModJab entidad = RMJ.GetJaboneraByID(id).First();

                    if (entidad.Stock > (pedidoObj.CanModJab - Pedido.CanModJab))
                    {
                        entidad.Stock = entidad.Stock - (Pedido.CanModJab - pedidoObj.CanModJab);
                        RMJ.ActualizarJabonera(entidad);
                    }
                    else
                    {
                        res = false;
                    }
                }
                else
                {
                    id = Pedido.IdModJab.Value;
                    AdmModJab entidad = RMJ.GetJaboneraByID(id).First();
                    entidad.Stock = entidad.Stock + (pedidoObj.CanModJab - Pedido.CanModJab);
                    RMJ.ActualizarJabonera(entidad);
                }

                if (pedidoObj.CanCepInBas < Pedido.CanCepInBas)
                {
                    List<AdmCepInBas> listaEntidades = RCIB.GetAllConsumibles();

                    for(id = 0; id >= listaEntidades.Count(); id++)
                    {
                        if (listaEntidades[id].Stock > (Pedido.CanCepInBas - pedidoObj.CanCepInBas))
                        {
                            res = true;
                        }
                        else
                        {
                            res = false;
                        }
                    }

                    if (res)
                    {
                        for (id = 0; id >= listaEntidades.Count(); id++)
                        {
                            listaEntidades[id].Stock = listaEntidades[id].Stock - (Pedido.CanCepInBas - pedidoObj.CanCepInBas);
                        }
                    }

                }
                else
                {
                    List<AdmCepInBas> listaEntidades = RCIB.GetAllConsumibles();

                    for (id = 0; id >= listaEntidades.Count(); id++)
                    {
                        listaEntidades[id].Stock = listaEntidades[id].Stock + (pedidoObj.CanCepInBas - Pedido.CanCepInBas);
                    }
                }

                if (pedidoObj.CanTipMaqLav < Pedido.CanTipMaqLav)
                {
                    id = Pedido.id;
                    AdmTipMaqLav entidad = RTML.GetLavavajillasByID(id).First();

                    if (entidad.Stock > (pedidoObj.CanTipMaqLav - Pedido.CanTipMaqLav))
                    {
                        entidad.Stock = entidad.Stock - (Pedido.CanTipMaqLav - pedidoObj.CanTipMaqLav);
                        RTML.ActualizarLavavajillas(entidad);
                    }
                    else
                    {
                        res = false;
                    }
                }
                else
                {
                    id = Pedido.id;
                    AdmTipMaqLav entidad = RTML.GetLavavajillasByID(id).First();
                    entidad.Stock = entidad.Stock + (pedidoObj.CanTipMaqLav - Pedido.CanTipMaqLav);
                    RTML.ActualizarLavavajillas(entidad);
                }

                if (res)
                {
                    conn.PedidosArea.Attach(pedidoObj);
                    conn.Entry(pedidoObj).State = System.Data.Entity.EntityState.Modified;
                    conn.SaveChanges();
                    res = true;
                }
                
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
            //RDEL = new RepositoryDosEstLimp();
            //RME = new RepositoryModEqDos();
            //RMJ = new RepositoryModJab();
            //RCIB = new RepositoryCepInsBas();
            //RTML = new RepositoryTipMaqLav();

            try
            {
                int id = 0;

                id = Pedido.IdModJab.Value;
                RMJ = new RepositoryModJab();
                AdmModJab jabonera = RMJ.GetJaboneraByID(id).First();
                if (jabonera.Stock > Pedido.CanModJab)
                {
                    jabonera.Stock = jabonera.Stock - Pedido.CanModJab;
                    RMJ.ActualizarJabonera(jabonera);
                }
                else
                {
                    return res = false;
                }

                id = Pedido.IdModEqDos.Value;
                AdmModEqDos eqDos = RME.GetEquipoDosificadorByID(id).First();
                if (eqDos.EqDisponibles > (Pedido.CanModEqDos))
                {
                   eqDos.EqDisponibles = eqDos.EqDisponibles - (Pedido.CanModEqDos);
                   RME.ActualizarEquipoDosificador(eqDos);
                }
                else
                {
                   return res = false;
                }

                id = Pedido.IdDosEstLim.Value;
                AdmDosEstLim dosEstacion = RDEL.GetEstacionesByID(id).First();
                if (dosEstacion.EqDisponibles > Pedido.CanDosEstLim)
                {
                    dosEstacion.EqDisponibles = dosEstacion.EqDisponibles - Pedido.CanDosEstLim;
                    RDEL.ActualizarEstacion(dosEstacion);
                }
                else
                {
                    return res = false;
                }
                
                id = Pedido.IdTipMaqLav.Value;
                AdmTipMaqLav maquinaLavavajillas = RTML.GetLavavajillasByID(id).First();
                if (maquinaLavavajillas.Stock > Pedido.CanTipMaqLav)
                {
                    maquinaLavavajillas.Stock = maquinaLavavajillas.Stock - Pedido.CanTipMaqLav;
                    RTML.ActualizarLavavajillas(maquinaLavavajillas);
                }
                else
                {
                    return res = false;
                }

                
                List<AdmCepInBas> listaEntidades = RCIB.GetAllConsumibles();
                for (id = 0; id >= listaEntidades.Count(); id++)
                    {
                        if (listaEntidades[id].Stock > Pedido.CanCepInBas)
                        {
                            res = true;
                        }
                        else
                        {
                            return res = false;
                        }
                    }
                if (res)
                    {
                        for (id = 0; id >= listaEntidades.Count(); id++)
                        {
                            listaEntidades[id].Stock = listaEntidades[id].Stock - Pedido.CanCepInBas;
                        }
                    }

                
              

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
