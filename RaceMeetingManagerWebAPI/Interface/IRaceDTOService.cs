using AutoMapper;
using RaceMeetingManagerDTOLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Interface
{
	public interface IRaceDTOService
	{
		Task<RaceDTO> Get(IMapper mapper, int meetCode);
		Task<IEnumerable<RaceDTO>> Get(IMapper mapper);
		void Update(IMapper mapper, RaceDTO raceDTO);
		Task Add(IMapper mapper, RaceDTO raceDTO);
	}
}
