using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apibackend.Models
{
    [Table("usu_usuarios")]
    public partial class UsuUsuarios
    {
        [Key]
        [Column("UsuRut")]
        [Required]
        public int Usurut { get; set; }

        [Column("UsuDv")]
        [MaxLength(1)]
        public string Usudv { get; set; } = null!;

        [Column("UsuNombres")]
        [MaxLength(30)]
        public string Usunombres { get; set; } = null!;

        [Column("UsuAPaterno")]
        [MaxLength(20)]
        public string Usuapaterno { get; set; } = null!;

        [Column("UsuAMaterno")]
        [MaxLength(20)]
        public string? Usuamaterno { get; set; }

        [Column("UsuUsuario")]
        [MaxLength(20)]
        public string Usuusuario { get; set; } = null!;

        [Column("UsuClave")]
        public string Usuclave { get; set; } = null!;

        [Column("CodEstado")]
        [Required]
        public int Codestado { get; set; }

        [Column("CodTipoUsuario")]
        [Required]
        public int Codtipousuario { get; set; }

        [Column("FecVigencia")]
        public DateTime? Fecvigencia { get; set; }

        [Column("UsuEmail")]
        [MaxLength(30)]
        public string Usuemail { get; set; } = null!;

        [Column("UsuAvatar")]
        [MaxLength(150)]
        public string? Usuavatar { get; set; }

        [Column("FecIngReg")]
        [Required]
        public DateTime Fecingreg { get; set; }

        [Column("UsuIngReg")]
        [MaxLength(20)]
        public string Usuingreg { get; set; } = null!;

        [Column("FunIngReg")]
        [MaxLength(20)]
        public string Funingreg { get; set; } = null!;

        [Column("FecModreg")]
        [Required]
        public DateTime Fecmodreg { get; set; }

        [Column("UsuModreg")]
        [MaxLength(20)]
        public string Usumodreg { get; set; } = null!;

        [Column("FunModReg")]
        [MaxLength(20)]
        public string Funmodreg { get; set; } = null!;
    }
}