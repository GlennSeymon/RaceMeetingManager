using System;
using System.Collections.Generic;
using System.Text;

namespace RaceMeetingManagerDTOLayer
{
	public class RaceDTO
	{
		public int RaceCode { get; set; }
		public MeetingDTO Meeting { get; set; }
		public int RaceNumber { get; set; }
		public string Name { get; set; }
		public int Distance { get; set; }
	}
}
