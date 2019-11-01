using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaceMeetingManagerDTOLayer;
using RaceMeetingManagerWebAPI.Interface;
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

		public Task Add(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEnumerable<MeetingCategoryDTO>> Get(IMapper mapper)
		{
			var meetingCategories = await context.MeetingCategories.ToListAsync();
			return mapper.Map<MeetingCategoryDTO[]>(meetingCategories);
		}

		public Task<MeetingCategoryDTO> Get(IMapper mapper, int meetCode)
		{
			throw new System.NotImplementedException();
		}

		public void Update(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO)
		{
			throw new System.NotImplementedException();
		}
	}
}