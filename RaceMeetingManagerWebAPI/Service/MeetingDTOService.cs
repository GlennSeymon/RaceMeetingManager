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
		private readonly IMapper mapper;

		public MeetingDTOService(RaceMeetingManagerContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public Task Add(MeetingDTO meetingDTO)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEnumerable<MeetingDTO>> Get()
		{
			var meetings = await context.Meetings.ToListAsync();
			return this.mapper.Map<MeetingDTO[]>(meetings);
		}

		public Task<MeetingDTO> Get(int meetCode)
		{
			throw new System.NotImplementedException();
		}

		public void Update(MeetingDTO meetingDTO)
		{
			throw new System.NotImplementedException();
		}
	}
}