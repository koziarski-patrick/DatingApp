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