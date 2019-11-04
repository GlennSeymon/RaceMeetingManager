using Newtonsoft.Json;
using RaceMeetingManagerDTOLayer;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaceMeetingManagerUIBlazor.Data
{
	public class MeetingService
	{
		private string baseUrl = "https://localhost:44364/";
		//private string baseUrl = "https://localhost:44374/";

		public async Task<MeetingDTO[]> GetMeetingAsync()
		{
			var http = new HttpClient();
			var meetings = await http.GetStringAsync($"{baseUrl}api/meetings");
			return JsonConvert.DeserializeObject<MeetingDTO[]>(meetings);
		}
	}
}
