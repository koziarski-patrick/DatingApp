using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class SurveyController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SurveyController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet] // .../api/survey
        public async Task<ActionResult<IEnumerable<SurveyDto>>> GetSurveys()
        {
            var survey = await _context.Surveys.ToListAsync();
            var surveysToReturn = _mapper.Map<IEnumerable<SurveyDto>>(survey); // Map the users to the MemberDto
            return Ok(surveysToReturn); // Return the surveys
        }

        [HttpGet("{id}")] // .../api/survey/1
        public async Task<ActionResult<SurveyDto>> GetSurvey(int id)
        {
            // Covernet string to int 
            // int surveyId = Convert.ToInt32(id);
            var survey = await _context.Surveys.FindAsync(id);
            return _mapper.Map<SurveyDto>(survey); // Map the user to the MemberDto
        }

        // [HttpGet("{id}/details")] // .../api/survey/1/details
        // public async Task<ActionResult<SurveyDto>> GetSurveyDetails(int id)
        // {
        //     var survey = await _context.Surveys.FindAsync(id);
        //     return _mapper.Map<SurveyDto>(survey);
        // }

        [HttpGet("{id}/questions")] // .../api/survey/1/questions
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestionsForSurvey(int id)
        {
            var questions = await _context.Questions
                .Where(q => q.SurveyID == id)
                .ToListAsync();

            var questionsToReturn = _mapper.Map<IEnumerable<QuestionDto>>(questions);
            return Ok(questionsToReturn);
        }

        [HttpGet("{id}/answers")]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswersByQuestion(int id)
        {
            var answers = await _context.Answers
                .Where(a => a.QuestionID == id)
                .ToListAsync();

            return answers;
        }
    }
}

// using API.Data;
// using API.Entities;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace API.Controllers
// {
//     [Authorize]
//     public class SurveyController : BaseApiController
//     {
//         private readonly DataContext _context;
//         public SurveyController(DataContext context)
//         {
//             _context = context;
//         }

//         [HttpGet] // .../api/survey
//         public async Task<ActionResult<IEnumerable<Survey>>> GetSurveys()
//         {
//             var surveys = await _context.Surveys.ToListAsync();
//             return surveys;
//         }

//         [HttpGet("{id}")] // .../api/survey/1
//         public async Task<ActionResult<Survey>> GetSurvey(int id)
//         {
//             return await _context.Surveys.FindAsync(id);
//         }

//     }
// }