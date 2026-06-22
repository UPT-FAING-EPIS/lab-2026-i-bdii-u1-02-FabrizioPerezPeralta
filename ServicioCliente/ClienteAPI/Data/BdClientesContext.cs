using ClienteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Data
{
    public partial class BdClientesContext : DbContext
    {
        public BdClientesContext()
        {
        }

        public BdClientesContext(DbContextOptions<BdClientesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClientesDocumento> ClientesDocumentos { get; set; }
        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente).HasName("PK_CLIENTES");
                entity.Property(e => e.NomCliente).IsUnicode(false);
            });

            modelBuilder.Entity<ClientesDocumento>(entity =>
            {
                entity.HasKey(e => new { e.IdCliente, e.IdTipoDocumento }).HasName("PK_CLIENTES_DOCUMENTOS");
                entity.Property(e => e.NumDocumento).IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClientesDocumentos)
                    .HasConstraintName("FK_CLIENTES_DOCUMENTOS_X_CLIENTE");

                entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.ClientesDocumentos)
                    .HasConstraintName("FK_CLIENTES_DOCUMENTOS_X_TIPO_DOCUMENTO");
            });

            modelBuilder.Entity<TiposDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento).HasName("PK_TIPOS_DOCUMENTOS");
                entity.Property(e => e.DesTipoDocumento).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
