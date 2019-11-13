using AutoMapper;
using RaceMeetingManagerDTOLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Interface
{
	public interface IMeetingDTOService
	{
		Task<MeetingDTO> Get(int meetCode);
		Task<IEnumerable<MeetingDTO>> Get();
		void Update(MeetingDTO meetingDTO);
		Task Add(MeetingDTO meetingDTO);
	}
}
