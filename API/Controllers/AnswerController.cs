// using API.Data;
// using API.Entities;
// using AutoMapper;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace API.Controllers
// {

//     public class AnswerController : BaseApiController
//     {
//         private readonly DataContext _context;
//         private readonly IMapper _mapper;

//         public AnswerController(DataContext context, IMapper mapper)
//         {
//             _mapper = mapper;
//             _context = context;
//         }

//         [HttpGet("{questionId}")]
//         public async Task<ActionResult<IEnumerable<Answer>>> GetAnswersByQuestion(int questionId)
//         {
//             var answers = await _context.Answers
//                 .Where(a => a.QuestionID == questionId)
//                 .ToListAsync();

//             return answers;
//         }
//     }
// }