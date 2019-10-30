using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceMeetingManagerWebAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatesController : ControllerBase
	{
		private readonly RaceMeetingManagerContext _context;

		public StatesController(RaceMeetingManagerContext context)
		{
			_context = context;
		}

		// GET: api/States
		[HttpGet]
		public async Task<ActionResult<IEnumerable<State>>> GetStates()
		{
			return await _context.States.ToListAsync();
		}

		// GET: api/States/5
		[HttpGet("{id}")]
		public async Task<ActionResult<State>> GetState(int id)
		{
			var state = await _context.States.FindAsync(id);

			if (state == null)
			{
				return NotFound();
			}

			return state;
		}

		// PUT: api/States/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutState(int id, State state)
		{
			if (id != state.StateCode)
			{
				return BadRequest();
			}

			_context.Entry(state).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StateExists(id))
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

		// POST: api/States
		[HttpPost]
		public async Task<ActionResult<State>> PostState(State state)
		{
			_context.States.Add(state);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetState", new { id = state.StateCode }, state);
		}

		// DELETE: api/States/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<State>> DeleteState(int id)
		{
			var state = await _context.States.FindAsync(id);
			if (state == null)
			{
				return NotFound();
			}

			_context.States.Remove(state);
			await _context.SaveChangesAsync();

			return state;
		}

		private bool StateExists(int id)
		{
			return _context.States.Any(e => e.StateCode == id);
		}
	}
}
