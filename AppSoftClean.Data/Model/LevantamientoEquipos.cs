//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppSoftClean.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class LevantamientoEquipos
    {
        public int id { get; set; }
        public Nullable<int> IdDivision { get; set; }
        public Nullable<System.DateTime> dteFecha { get; set; }
        public Nullable<int> NumHoja { get; set; }
    
        public virtual AdmDivisiones AdmDivisiones { get; set; }
    }
}
