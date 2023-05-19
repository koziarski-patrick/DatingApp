using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }

        public int SurveyID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        [ForeignKey("SurveyID")]
        public Survey Survey { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}