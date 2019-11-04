using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaceMeetingManagerDTOLayer;
using RaceMeetingManagerWebAPI.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Service
{
	public class MeetingDTOService : IMeetingDTOService
	{
		private readonly RaceMeetingManagerContext context;

		public MeetingDTOService(RaceMeetingManagerContext context)
		{
			this.context = context;
		}

		public Task Add(IMapper mapper, MeetingDTO meetingDTO)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEnumerable<MeetingDTO>> Get(IMapper mapper)
		{
			var meetings = await context.Meetings.ToListAsync();
			return mapper.Map<MeetingDTO[]>(meetings);
		}

		public Task<MeetingDTO> Get(IMapper mapper, int meetCode)
		{
			throw new System.NotImplementedException();
		}

		public void Update(IMapper mapper, MeetingDTO meetingDTO)
		{
			throw new System.NotImplementedException();
		}
	}
}