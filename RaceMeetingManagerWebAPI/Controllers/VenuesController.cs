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
	public class VenuesController : ControllerBase
	{
		private readonly RaceMeetingManagerContext _context;

		public VenuesController(RaceMeetingManagerContext context)
		{
			_context = context;
		}

		// GET: api/Venues
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
		{
			return await _context.Venues.ToListAsync();
		}

		// GET: api/Venues/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Venue>> GetVenue(int id)
		{
			var venue = await _context.Venues.FindAsync(id);

			if (venue == null)
			{
				return NotFound();
			}

			return venue;
		}

		// PUT: api/Venues/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutVenue(int id, Venue venue)
		{
			if (id != venue.VenueCode)
			{
				return BadRequest();
			}

			_context.Entry(venue).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!VenueExists(id))
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

		// POST: api/Venues
		[HttpPost]
		public async Task<ActionResult<Venue>> PostVenue(Venue venue)
		{
			_context.Venues.Add(venue);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetVenue", new { id = venue.VenueCode }, venue);
		}

		// DELETE: api/Venues/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Venue>> DeleteVenue(int id)
		{
			var venue = await _context.Venues.FindAsync(id);
			if (venue == null)
			{
				return NotFound();
			}

			_context.Venues.Remove(venue);
			await _context.SaveChangesAsync();

			return venue;
		}

		private bool VenueExists(int id)
		{
			return _context.Venues.Any(e => e.VenueCode == id);
		}
	}
}
