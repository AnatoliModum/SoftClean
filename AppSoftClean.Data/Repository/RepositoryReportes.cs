using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Repository
{
   public class RepositoryReportes
    {
        public List<Reportes> ObtenerListado(List<PedidosArea> pedido, LevantamientoEquipos levantamiento)
        {
            List<Reportes> ListaReportes = new List<Reportes>();
            Reportes reporte = new Reportes();
            RepositoryDivisiones RD = new RepositoryDivisiones();
            int id = 0;

            for (int i = 0; i < pedido.Count(); i++)
            {
                id = levantamiento.IdDivision.Value;
                reporte.Division = RD.GetDivisionesByID(id).First().Nombre;
                
                reporte.Fecha = levantamiento.dteFecha.Value;
                reporte.NumeroDeHoja = levantamiento.NumHoja.Value;
                
                #region Consultas simples sin listado;
                reporte.AreaInstalacion = pedido[i].AreaIns;

                RepositoryModEqDos RMED = new RepositoryModEqDos();
                reporte.ModeloEquipoDosificador = pedido[i].CanModEqDos.ToString() +
                    RMED.GetEquipoDosificadorByID(pedido[i].IdModEqDos.Value).First().Modelo;

                RepositoryDosEstLimp RDEL = new RepositoryDosEstLimp();
                reporte.DosificadorEstacionDeLimpieza = pedido[i].CanDosEstLim.ToString() +
                    RDEL.GetEstacionesByID(pedido[i].IdDosEstLim.Value).First().DosEstLimp;

                RepositoryModJab RMJ = new RepositoryModJab();
                reporte.ModeloJabonera = pedido[i].CanModJab.ToString() +
                    RMJ.GetJaboneraByID(pedido[i].IdModJab.Value).First().Modelo;

                RepositoryTipMaqLav RTML = new RepositoryTipMaqLav();
                reporte.TipoMaquinaLavavajillas = pedido[i].CanTipMaqLav.ToString() +
                    RTML.GetLavavajillasByID(pedido[i].IdTipMaqLav.Value).First().Tipo;

                RepositoryPortGalon RPG = new RepositoryPortGalon();
                reporte.PortaGalones = pedido[i].CanPorGalon.ToString() +
                    RPG.GetGaloneraByID(pedido[i].IdPorGalon.Value).First().Tipo;

                reporte.CantidadConsumibles = pedido[i].CanCepInBas.Value;
                #endregion
                string saltoLinea = "" + Environment.NewLine;

                reporte.ProductosQuimicos = pedido[i].ProdQuim.Replace(".",saltoLinea);
                reporte.DosificadoresLavavajillas = pedido[i].DosLav.Replace(".",saltoLinea);

                reporte.id = pedido[i].id;

                ListaReportes.Add(reporte);
            }

            return ListaReportes;
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
