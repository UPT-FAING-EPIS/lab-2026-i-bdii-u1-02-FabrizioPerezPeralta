using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteAPI.Models
{
    [Table("CLIENTES")]
    public partial class Cliente
    {
        public Cliente()
        {
            ClientesDocumentos = new HashSet<ClientesDocumento>();
        }

        [Key]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [Required]
        [Column("NOM_CLIENTE")]
        [StringLength(100)]
        public string NomCliente { get; set; } = null!;

        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<ClientesDocumento> ClientesDocumentos { get; set; }
    }
}
