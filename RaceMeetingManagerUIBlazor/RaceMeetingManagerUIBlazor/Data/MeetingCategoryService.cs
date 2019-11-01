using Newtonsoft.Json;
using RaceMeetingManagerDTOLayer;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaceMeetingManagerUIBlazor.Data
{
	public class MeetingCategoryService
	{
		private string baseUrl = "https://localhost:44364/";
		//private string baseUrl = "https://localhost:44374/";

		public async Task<MeetingCategoryDTO[]> GetMeetingCategoryAsync()
		{
			var http = new HttpClient();
			var meetingCategories = await http.GetStringAsync($"{baseUrl}api/meetingcategory");
			return JsonConvert.DeserializeObject<MeetingCategoryDTO[]>(meetingCategories);
		}
	}
}
