using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Model
{
    public class ComprobacionDePedidos
    {
        private bool DosEstLimStock = false;
        private bool ModJabStock = false;
        private bool CepInBasStock = false;
        private bool TipMaqLavStock = false;
        private bool QuimicosStock = false;
        private bool DosLavStock = false;
        private bool ModEqDos = false;
        private bool PorGalon = false;

        public bool _DosEstLimStock {
            get { return DosEstLimStock; }
            set { DosEstLimStock = value; }
        }

        public bool _ModJabStock
        {
            get { return ModJabStock; }
            set { ModJabStock = value; }
        }

        public bool _CepInBasStock
        {
            get { return CepInBasStock; }
            set { CepInBasStock = value; }
        }

        public bool _TipMaqLavStock
        {
            get { return TipMaqLavStock; }
            set { TipMaqLavStock = value; }
        }

        public bool _QuimicosStock
        {
            get { return QuimicosStock; }
            set { QuimicosStock = value; }
        }

        public bool _DosLavStock
        {
            get { return DosLavStock; }
            set { DosLavStock = value; }
        }

        public bool _ModEqDos
        {
            get { return ModEqDos; }
            set { ModEqDos = value; }
        }

        public bool _PorGalon
        {
            get { return PorGalon; }
            set { PorGalon = value; }
        }
    }
}
