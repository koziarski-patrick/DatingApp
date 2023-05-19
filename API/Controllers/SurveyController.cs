using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SurveyController : BaseApiController
    {
        private readonly DataContext _context;
        public SurveyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // .../api/survey
        public async Task<ActionResult<IEnumerable<Survey>>> GetSurveys()
        {
            var surveys = await _context.Surveys.ToListAsync();
            return surveys;
        }

    }
}