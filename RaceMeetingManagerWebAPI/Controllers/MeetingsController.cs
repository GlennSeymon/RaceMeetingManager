using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceMeetingManagerWebAPI.Interface;
using RaceMeetingManagerWebAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MeetingsController : ControllerBase
	{
		private readonly RaceMeetingManagerContext context;
		private readonly IMeetingDTOService meetingDTOService;
		private readonly IMapper mapper;

		public MeetingsController(RaceMeetingManagerContext context, IMeetingDTOService meetingDTOService, IMapper mapper)
		{
			this.context = context;
			this.meetingDTOService = meetingDTOService;
			this.mapper = mapper;
		}

		// GET: api/Meetings
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings()
		{
			return Ok(await this.meetingDTOService.Get());
		}

		// GET: api/Meetings/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Meeting>> GetMeeting(int id)
		{
			var meeting = await context.Meetings.FindAsync(id);

			if (meeting == null)
			{
				return NotFound();
			}

			return meeting;
		}

		// PUT: api/Meetings/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMeeting(int id, Meeting meeting)
		{
			if (id != meeting.MeetCode)
			{
				return BadRequest();
			}

			context.Entry(meeting).State = EntityState.Modified;

			try
			{
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MeetingExists(id))
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

		// POST: api/Meetings
		[HttpPost]
		public async Task<ActionResult<Meeting>> PostMeeting(Meeting meeting)
		{
			context.Meetings.Add(meeting);
			await context.SaveChangesAsync();

			return CreatedAtAction("GetMeeting", new { id = meeting.MeetCode }, meeting);
		}

		// DELETE: api/Meetings/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Meeting>> DeleteMeeting(int id)
		{
			var meeting = await context.Meetings.FindAsync(id);
			if (meeting == null)
			{
				return NotFound();
			}

			context.Meetings.Remove(meeting);
			await context.SaveChangesAsync();

			return meeting;
		}

		private bool MeetingExists(int id)
		{
			return context.Meetings.Any(e => e.MeetCode == id);
		}
	}
}
