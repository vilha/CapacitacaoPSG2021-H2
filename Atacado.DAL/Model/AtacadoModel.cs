using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Atacado.DAL.Model
{
    public partial class AtacadoModel : DbContext
    {
        public AtacadoModel()
            : base("name=AtacadoModel")
        {
        }

        public virtual DbSet<categoria> categorias { get; set; }
        public virtual DbSet<Mesoregiao> Mesoregiaos { get; set; }
        public virtual DbSet<Microregiao> Microregiaos { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<produto> produtos { get; set; }
        public virtual DbSet<Regiao> Regioes { get; set; }
        public virtual DbSet<subcategoria> subcategorias { get; set; }
        public virtual DbSet<UnidadesFederacao> UFs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .HasMany(e => e.Subcategorias)
                .WithRequired(e => e.categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mesoregiao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Mesoregiao>()
                .HasMany(e => e.Microregioes)
                .WithRequired(e => e.Mesoregiao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mesoregiao>()
                .HasMany(e => e.Municipios)
                .WithRequired(e => e.Mesoregiao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Microregiao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Microregiao>()
                .HasMany(e => e.Municipios)
                .WithRequired(e => e.Microregiao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Municipio>()
                .Property(e => e.SiglaUF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<produto>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Regiao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Regiao>()
                .Property(e => e.SiglaRegiao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Regiao>()
                .HasMany(e => e.UFs)
                .WithRequired(e => e.Regiao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<subcategoria>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<subcategoria>()
                .HasMany(e => e.Produtos)
                .WithRequired(e => e.subcategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnidadesFederacao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadesFederacao>()
                .Property(e => e.SiglaUF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UnidadesFederacao>()
                .HasMany(e => e.Mesoregioes)
                .WithRequired(e => e.UFs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnidadesFederacao>()
                .HasMany(e => e.Municipios)
                .WithRequired(e => e.UFs)
                .WillCascadeOnDelete(false);
        }
    }
}
