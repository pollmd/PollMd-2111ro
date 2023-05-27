using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollMd2.Data;
using PollMd2.Models;

namespace PollMd2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly pollmdContext _context;

        public QuestionsController(pollmdContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public ActionResult<Question> Get(int? id)
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }

            var result = (id != null) ?
                _context.Questions.Include("Answers").FirstOrDefault(x => x.Id == id) :
                _context.Questions.Include("Answers").OrderBy(x => x.Id).LastOrDefault();


            return result;
        }

        [HttpPost]
        [Route("Vote")]
        public async Task VoteAsync([FromForm] int optionid)
        {
            var vote = new Vote
            {
                AnswerId = optionid,
                UserId = "no authorized",
                CreatedOn = DateTime.Now,
                QuestionId = _context.Answers.FirstOrDefault(x => x.Id == optionid)?.QuestionId
            };

            var answer = _context.Answers.FirstOrDefault(x => x.Id == optionid);
            if (answer != null)
            {
                answer.Votes++;
                _context.Entry(answer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'pollmdContext.Questions'  is null.");
            }
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Questions
        [Route("QuestionWithAnswers")]
        [Route("QuestionWithAnswers/{id}")]
        [HttpGet]
        public ActionResult<Question> QuestionWithAnswers(int? id)
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }

            var result = (id != null) ?
                _context.Questions.FirstOrDefault(x => x.Id == id) :
                _context.Questions.OrderBy(x => x.Id).LastOrDefault();

            if (result != null)
            {
                var answers = _context.Answers.Where(x => x.QuestionId == id).ToList();
                result.Answers = answers;
            }

            return result;
        }

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        [Route("AddPoll")]
        public async Task AddPoll([FromForm] string questiontext, [FromForm] string option1, [FromForm] string option2, [FromForm] string option3)
        {
            var question = new Question
            {
                Text = questiontext,
                UserId = "no authorized",
                CreationDate = DateTime.Now,
                Answers = new List<Answer> { 
                    new Answer() { Text = option1, Votes=0 },
                    new Answer() { Text = option2, Votes=0 },
                    new Answer() { Text = option3, Votes=0 },
                }
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync(); ;
        }
    }
}
