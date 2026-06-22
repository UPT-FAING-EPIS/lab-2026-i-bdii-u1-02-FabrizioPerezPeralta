using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteAPI.Models
{
    [Table("TIPOS_DOCUMENTOS")]
    public partial class TiposDocumento
    {
        public TiposDocumento()
        {
            ClientesDocumentos = new HashSet<ClientesDocumento>();
        }

        [Key]
        [Column("ID_TIPO_DOCUMENTO")]
        public byte IdTipoDocumento { get; set; }

        [Required]
        [Column("DES_TIPO_DOCUMENTO")]
        [StringLength(50)]
        public string DesTipoDocumento { get; set; } = null!;

        [InverseProperty("IdTipoDocumentoNavigation")]
        public virtual ICollection<ClientesDocumento> ClientesDocumentos { get; set; }
    }
}
