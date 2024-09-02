using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_API.Data;
using University_API.Models;

namespace University_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly UniDtbContext _context;

        public ProfessorController(UniDtbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetProfessors()
        {
            if (_context.Professors == null)
            {
                return NotFound();
            }

            var professors = await _context.Professors.ToListAsync();
            return Ok(professors);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProfessor(int id)
        {
            if (_context.Professors == null)
            {
                return NotFound();
            }
            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return Ok(professor);
        }

        [HttpPost]

        public async Task<IActionResult> PostProfessor(Professor professor)
        {
            _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProfessor", professor.ProfessorId, professor);
            return CreatedAtAction(nameof(GetProfessor), new { id = professor.ProfessorId }, professor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, [FromBody] Professor p)
        {
            var professor = await _context.Professors.FirstOrDefaultAsync(x => x.ProfessorId == id);

            if (professor == null)
            {
                return NotFound();
            }

            professor.Name = p.Name;
            professor.Surname = p.Surname;
            professor.BirthDate = p.BirthDate;
            professor.Gender = p.Gender;
            professor.City = p.City;
            professor.Email = p.Email;
            professor.Photo = p.Photo;

            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var professor = await _context.Professors.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

