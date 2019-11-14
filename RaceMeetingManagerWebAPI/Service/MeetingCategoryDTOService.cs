using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RaceMeetingManagerDTOLayer;
using RaceMeetingManagerWebAPI.Interface;
using RaceMeetingManagerWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Service
{
	public class MeetingCategoryDTOService : IMeetingCategoryDTOService
	{
		private readonly RaceMeetingManagerContext context;

		public MeetingCategoryDTOService(RaceMeetingManagerContext context)
		{
			this.context = context;
		}

		~MeetingCategoryDTOService()
		{
			this.context.Dispose();
		}

		public async Task<MeetingCategoryDTO> Add(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO)
		{
			var meetingCategory = mapper.Map<MeetingCategory>(meetingCategoryDTO);
			var meetingCategoryAdded = context.MeetingCategories.Add(meetingCategory).Entity;

			await context.SaveChangesAsync();

			return mapper.Map<MeetingCategoryDTO>(meetingCategoryAdded);
		}

		public async void Delete(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO)
		{
			var meetingCategory = mapper.Map<MeetingCategory>(meetingCategoryDTO);
			context.MeetingCategories.Remove(meetingCategory);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<MeetingCategoryDTO>> Get(IMapper mapper)
		{
			var meetingCategories = await context.MeetingCategories.ToListAsync();
			return mapper.Map<MeetingCategoryDTO[]>(meetingCategories);
		}

		public async Task<MeetingCategoryDTO> Get(IMapper mapper, int meetingCategoryCode)
		{
			var meetingCategory = await context.MeetingCategories.FindAsync(meetingCategoryCode);
			return mapper.Map<MeetingCategoryDTO>(meetingCategory);
		}

		public async Task<MeetingCategoryDTO> Update(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO)
		{
			var meetingCategory = await this.context.MeetingCategories.FindAsync(meetingCategoryDTO.MeetingCategoryCode);

			meetingCategory.Description = meetingCategoryDTO.Description;

			this.context.MeetingCategories.Update(meetingCategory);
			this.context.Entry(meetingCategory).State = EntityState.Modified;

			await this.context.SaveChangesAsync();

			return mapper.Map<MeetingCategoryDTO>(meetingCategory);
		}
	}
}