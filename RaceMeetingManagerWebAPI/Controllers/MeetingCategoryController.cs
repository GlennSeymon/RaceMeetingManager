using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceMeetingManagerWebAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Controllers
{
	[ApiController, Route("api/[controller]")]
	public class MeetingCategoryController : ControllerBase
	{
		/// <summary>The meeting sample 2019 database context</summary>  
		private readonly RaceMeetingManagerContext meetingSample2019Context;

		public MeetingCategoryController(RaceMeetingManagerContext meetingSample2019Context)
		{
			this.meetingSample2019Context = meetingSample2019Context;
		}

		/// <summary>Gets the meeting category.</summary>  
		/// <returns>Task<ActionResult<IEnumerable<MeetingCategory>>>.</returns>  
		/// <remarks> GET api/values</remarks>  
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MeetingCategory>>> GetMeetingCategories()
		{
			return Ok(await meetingSample2019Context.MeetingCategories.ToListAsync());
		}

		/// <summary>Creates the specified meeting category.</summary>  
		/// <param name="MeetingCategory">The meeting category.</param>  
		/// <returns>Task<ActionResult<MeetingCategory>>.</returns>  
		[HttpPost]
		public async Task<ActionResult<MeetingCategory>> Create([FromBody] MeetingCategory meetingCategory)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await meetingSample2019Context.MeetingCategories.AddAsync(meetingCategory);
			await meetingSample2019Context.SaveChangesAsync();

			return Ok(meetingCategory);
		}

		/// <summary>Updates the specified identifier.</summary>  
		/// <param name="id">The identifier.</param>  
		/// <param name="meetingCategoryFromJson">The meeting category from json.</param>  
		/// <returns>Task<ActionResult<MeetingCategory>>.</returns>  
		[HttpPut("{id}")]
		public async Task<ActionResult<MeetingCategory>> Update(int id, [FromBody] MeetingCategory meetingCategoryFromJson)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var meetingCategory = await meetingSample2019Context.MeetingCategories.FindAsync(id);

			if (meetingCategory == null)
				return NotFound();

			meetingCategory.Description = meetingCategoryFromJson.Description;
			meetingCategory.MeetingCategoryCode = id;

			await meetingSample2019Context.SaveChangesAsync();

			return Ok(meetingCategory);
		}

		/// <summary>Deletes the specified identifier.</summary>  
		/// <param name="id">The identifier.</param>  
		/// <returns>Task<ActionResult<MeetingCategory>>.</returns>  
		[HttpDelete("{id}")]
		public async Task<ActionResult<MeetingCategory>> Delete(int id)
		{
			var meetingCategory = await meetingSample2019Context.MeetingCategories.FindAsync(id);

			if (meetingCategory == null)
				return NotFound();

			meetingSample2019Context.Remove(meetingCategory);
			await meetingSample2019Context.SaveChangesAsync();

			return Ok(meetingCategory);
		}
	}
}