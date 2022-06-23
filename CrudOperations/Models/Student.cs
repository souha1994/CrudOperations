using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CrudOperations.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Id")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Ce champs est requis")]
        [Display(Name = "Nom et prénom")]
        [Column(TypeName = "varchar(250)")]
        public string StudentName { get; set; } = String.Empty;
        [Display(Name = "Image")]
        [Column(TypeName = "varchar(250)")]
        public string? StudentImage { get; set; } = String.Empty;
        [Required(ErrorMessage = "Ce champs est requis")]
        [Display(Name = "la date de naissance")]
        [DataType(DataType.Date)]
        public DateTime birthDate { get; set; }
        [Required(ErrorMessage = "Ce champs est requis")]
        [Display(Name = "numéro de telphone")]
        [Column(TypeName = "varchar(250)")]
        public string mobilePhone { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ce champs est requis")]
        [Display(Name = "la date d'inscription")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy")]
        public DateTime DateInscription { get; set; }
        public int FiliereID { get; set; }
        [ForeignKey("FiliereID")]
        public Filiere? filiere { get; set; }
    }
}
