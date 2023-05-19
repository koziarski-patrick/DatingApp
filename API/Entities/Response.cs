using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Response
    {
        [Key]
        public int ResponseID { get; set; }

        public int SurveyID { get; set; }

        public int UserID { get; set; }

        public int QuestionID { get; set; }

        public int AnswerID { get; set; }

        [ForeignKey("SurveyID")]
        public Survey Survey { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("QuestionID")]
        public Question Question { get; set; }

        [ForeignKey("AnswerID")]
        public Answer Answer { get; set; }
    }
}