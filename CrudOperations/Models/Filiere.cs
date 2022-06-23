using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperations.Models
{
    public class Filiere
    {
        [Key]
        [Display(Name = "ID")]
        public int FiliereId { get; set; }
        [Required]
        [Display(Name = "la filière")]
        [Column(TypeName = "varchar(250)")]
        public string FiliereName { get; set; } = String.Empty;
    }
}
