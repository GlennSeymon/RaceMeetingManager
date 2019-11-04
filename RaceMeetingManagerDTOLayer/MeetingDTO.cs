using System;
using System.Collections.Generic;
using System.Text;

namespace RaceMeetingManagerDTOLayer
{
	public class MeetingDTO
	{
		public int MeetCode { get; set; }
		public string Title { get; set; }
		public string StateDesc { get; set; }
		public DateTime MeetDate { get; set; }
		public string VenueDesc { get; set; }
	}
}
