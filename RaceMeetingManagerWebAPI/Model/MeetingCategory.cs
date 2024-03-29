﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceMeetingManagerWebAPI.Model
{
	public class MeetingCategory
	{
		[Key]
		public int MeetingCategoryCode { get; set; }
		public string Description { get; set; }
		public ICollection<Meeting> Meetings { get; set; }
	}
}
