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
    
    public partial class AdmPortGalon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdmPortGalon()
        {
            this.PedidosArea = new HashSet<PedidosArea>();
        }
    
        public int id { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> Stock { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidosArea> PedidosArea { get; set; }
    }
}
