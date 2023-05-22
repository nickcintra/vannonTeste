using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using vannon_teste.Models;

namespace vannon_teste.Data
{
    public class vannonDBContext : DbContext
    {

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        public vannonDBContext() : base("sqlconn") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FilmeMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class FilmeMap : EntityTypeConfiguration<Filme>
    {
        public FilmeMap()
        {
            ToTable("Filme");
            HasKey(x => x.id);

            Property(x => x.titulo)
                .IsVariableLength()
                .IsRequired()
                .HasMaxLength(100);
        }
    }

    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Clientes");
            HasKey(c => c.Id);
            
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            // Relacionamento um-para-um entre Cliente e Usuario
            HasRequired(c => c.Usuario)
                .WithOptional(u => u.Cliente)
                .Map(m => m.MapKey("UsuarioId"));
        }
    }

    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuarios");

            HasKey(u => u.Id);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}