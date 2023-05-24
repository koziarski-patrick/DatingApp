using API.DTOs;

namespace API.Controllers
{
    public class QuestionDto
    {
        public int QuestionID { get; set; }
        public int SurveyID { get; set; }
        public string Text { get; set; }
        public SurveyDto Survey { get; set; }  // Include the Survey property
        public ICollection<AnswerDto> Answers { get; set; }  // Include the Answers property

    }
}