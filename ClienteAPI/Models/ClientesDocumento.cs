using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Models
{
    [Table("CLIENTES_DOCUMENTOS")]
    [PrimaryKey(nameof(IdCliente), nameof(IdTipoDocumento))]
    public partial class ClientesDocumento
    {
        [Key]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [Key]
        [Column("ID_TIPO_DOCUMENTO")]
        public byte IdTipoDocumento { get; set; }

        [Required]
        [Column("NUM_DOCUMENTO")]
        [StringLength(15)]
        public string NumDocumento { get; set; } = null!;

        [ForeignKey("IdCliente")]
        [InverseProperty("ClientesDocumentos")]
        public virtual Cliente IdClienteNavigation { get; set; } = null!;

        [ForeignKey("IdTipoDocumento")]
        [InverseProperty("ClientesDocumentos")]
        public virtual TiposDocumento IdTipoDocumentoNavigation { get; set; } = null!;
    }
}
