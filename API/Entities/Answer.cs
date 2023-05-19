using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }

        public int QuestionID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public bool IsCorrect { get; set; } // Property to indicate if it is the correct answer

        [ForeignKey("QuestionID")]
        public Question Question { get; set; }
    }
}