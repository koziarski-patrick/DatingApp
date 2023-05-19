using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Survey
    {
        [Key]
        public int SurveyID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int AdministratorID { get; set; }

        [Required]
        [MaxLength(500)]
        public string ShareableURL { get; set; }

        public bool IsPublished { get; set; }

        [ForeignKey("AdministratorID")]
        public User Administrator { get; set; }
    }
}