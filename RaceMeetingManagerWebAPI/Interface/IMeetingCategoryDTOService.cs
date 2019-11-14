using AutoMapper;
using RaceMeetingManagerDTOLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Interface
{
	public interface IMeetingCategoryDTOService
	{
		Task<MeetingCategoryDTO> Get(IMapper mapper, int meetCode);
		Task<IEnumerable<MeetingCategoryDTO>> Get(IMapper mapper);
		Task<MeetingCategoryDTO> Update(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO);
		Task<MeetingCategoryDTO> Add(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO);
		void Delete(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO);
	}
}
