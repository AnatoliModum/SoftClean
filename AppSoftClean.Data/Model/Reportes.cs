using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Model
{
   public class Reportes
    {
        public int id { get; set; }
        public string AreaInstalacion { get; set; } 
        public string ModeloEquipoDosificador { get; set; } //
        public string DosificadorEstacionDeLimpieza { get; set; } //
        public string ProductosQuimicos { get; set; }
        public string ModeloJabonera { get; set; } //
        public int CantidadConsumibles { get; set; }
        public string TipoMaquinaLavavajillas { get; set; } //
        public string DosificadoresLavavajillas { get; set; }
        public string PortaGalones { get; set; } //
        public string Division { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroDeHoja { get; set; }

        
    }
}
