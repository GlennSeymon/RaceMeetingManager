using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaceMeetingManagerDTOLayer;
using RaceMeetingManagerWebAPI.Interface;
using RaceMeetingManagerWebAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceMeetingManagerWebAPI.Service
{
	public class RaceDTOService : IRaceDTOService
	{
		private readonly RaceMeetingManagerContext context;

		public RaceDTOService(RaceMeetingManagerContext context)
		{
			this.context = context;
		}

		public async Task Add(IMapper mapper, RaceDTO raceDTO)
		{
			var race = mapper.Map<Race>(raceDTO);
			context.Races.Add(race);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<RaceDTO>> Get(IMapper mapper)
		{
			var races = await context.Races.ToListAsync();
			return mapper.Map<RaceDTO[]>(races);
		}

		public async Task<RaceDTO> Get(IMapper mapper, int raceCode)
		{
			var race = await context.Races.FindAsync(raceCode);
			return mapper.Map<RaceDTO>(race);
		}

		public async void Update(IMapper mapper, RaceDTO raceDTO)
		{
			var race = mapper.Map<Race>(raceDTO);
			context.Races.Update(race);
			await context.SaveChangesAsync();
		}
	}
}