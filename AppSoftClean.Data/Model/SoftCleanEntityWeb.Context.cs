﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ServiceForHotelEntities : DbContext
    {
        public ServiceForHotelEntities()
            : base("name=ServiceForHotelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdmCepInBas> AdmCepInBas { get; set; }
        public virtual DbSet<AdmDivisiones> AdmDivisiones { get; set; }
        public virtual DbSet<AdmDosEstLim> AdmDosEstLim { get; set; }
        public virtual DbSet<AdmDosLav> AdmDosLav { get; set; }
        public virtual DbSet<AdmModEqDos> AdmModEqDos { get; set; }
        public virtual DbSet<AdmModJab> AdmModJab { get; set; }
        public virtual DbSet<AdmPortGalon> AdmPortGalon { get; set; }
        public virtual DbSet<AdmProdQuim> AdmProdQuim { get; set; }
        public virtual DbSet<AdmTipMaqLav> AdmTipMaqLav { get; set; }
        public virtual DbSet<AreaUso> AreaUso { get; set; }
        public virtual DbSet<LevantamientoEquipos> LevantamientoEquipos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<PedidosArea> PedidosArea { get; set; }
    }
}
