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
		void Update(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO);
		Task Add(IMapper mapper, MeetingCategoryDTO meetingCategoryDTO);
	}
}
