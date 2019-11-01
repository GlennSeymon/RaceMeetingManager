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

			/*
						CreateMap<Meeting, MeetingVM>()
							.ForMember(dest => dest.VenueCode, opt => opt.MapFrom(src => src.Venue.VenueCode))
							.ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.State.StateCode))
							.ReverseMap()

						CreateMap<Race, RaceVM>().ReverseMap();
			*/
		}
	}
}
