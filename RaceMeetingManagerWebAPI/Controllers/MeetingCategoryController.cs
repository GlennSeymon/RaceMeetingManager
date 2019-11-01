using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RaceMeetingManagerDTOLayer;
using RaceMeetingManagerWebAPI.Interface;
using RaceMeetingManagerWebAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Controllers
{
	[ApiController, Route("api/[controller]")]
	public class MeetingCategoryController : ControllerBase
	{
		/// <summary>The meeting sample 2019 database context</summary>  
		private readonly RaceMeetingManagerContext context;
		private readonly IMeetingCategoryDTOService meetingCategoryDTOService;
		private readonly IMapper mapper;

		public MeetingCategoryController(RaceMeetingManagerContext context, IMeetingCategoryDTOService meetingCategoryDTOService, IMapper mapper)
		{
			this.context = context;
			this.meetingCategoryDTOService = meetingCategoryDTOService;
			this.mapper = mapper;
		}

		/// <summary>Gets the meeting category.</summary>  
		/// <returns>Task<ActionResult<IEnumerable<MeetingCategoryDTO>>>.</returns>  
		/// <remarks> GET api/values</remarks>  
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MeetingCategoryDTO>>> GetMeetingCategories()
		{
			return Ok(await this.meetingCategoryDTOService.Get(this.mapper));
		}

		/// <summary>Creates the specified meeting category.</summary>  
		/// <param name="MeetingCategory">The meeting category.</param>  
		/// <returns>Task<ActionResult<MeetingCategory>>.</returns>  
		[HttpPost]
		public async Task<ActionResult<MeetingCategory>> Create([FromBody] MeetingCategory meetingCategory)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await context.MeetingCategories.AddAsync(meetingCategory);
			await context.SaveChangesAsync();

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

			var meetingCategory = await context.MeetingCategories.FindAsync(id);

			if (meetingCategory == null)
				return NotFound();

			meetingCategory.Description = meetingCategoryFromJson.Description;
			meetingCategory.MeetingCategoryCode = id;

			await context.SaveChangesAsync();

			return Ok(meetingCategory);
		}

		/// <summary>Deletes the specified identifier.</summary>  
		/// <param name="id">The identifier.</param>  
		/// <returns>Task<ActionResult<MeetingCategory>>.</returns>  
		[HttpDelete("{id}")]
		public async Task<ActionResult<MeetingCategory>> Delete(int id)
		{
			var meetingCategory = await context.MeetingCategories.FindAsync(id);

			if (meetingCategory == null)
				return NotFound();

			context.Remove(meetingCategory);
			await context.SaveChangesAsync();

			return Ok(meetingCategory);
		}
	}
}