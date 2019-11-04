using AutoMapper;
using RaceMeetingManagerDTOLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Interface
{
	public interface IMeetingDTOService
	{
		Task<MeetingDTO> Get(IMapper mapper, int meetCode);
		Task<IEnumerable<MeetingDTO>> Get(IMapper mapper);
		void Update(IMapper mapper, MeetingDTO meetingDTO);
		Task Add(IMapper mapper, MeetingDTO meetingDTO);
	}
}
