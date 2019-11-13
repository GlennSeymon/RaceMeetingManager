using AutoMapper;
using RaceMeetingManagerDTOLayer;
using RaceMeetingManagerWebAPI.Model;

namespace RaceMeetingManagerWebAPI.Classes
{
	public class DomainProfile : Profile
	{
		public DomainProfile()
		{
			CreateMap<MeetingCategory, MeetingCategoryDTO>().ReverseMap();

			CreateMap<Meeting, MeetingDTO>()
				.ForMember(dest => dest.VenueDesc, opt => opt.MapFrom(src => src.Venue.Name))
				.ForMember(dest => dest.StateDesc, opt => opt.MapFrom(src => src.State.DescShort))
				.ReverseMap();

			//CreateMap<Race, RaceVM>().ReverseMap();

		}
	}
}
