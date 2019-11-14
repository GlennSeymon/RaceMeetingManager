using Newtonsoft.Json;
using RaceMeetingManagerDTOLayer;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RaceMeetingManagerUIBlazor.Data
{
	public class MeetingCategoryService : BaseService
	{
		public MeetingCategoryService() : base("api/meetingcategory")
		{
		}

		public async Task<MeetingCategoryDTO[]> GetMeetingCategoryAsync()
		{
			var meetingCategories = await this.httpClient.GetStringAsync($"{this.baseUrl}{this.urlPrefix}");
			return JsonConvert.DeserializeObject<MeetingCategoryDTO[]>(meetingCategories);
		}

		public async Task<MeetingCategoryDTO> GetMeetingCategoryByIdAsync(int id)
		{
			var meetingCategory = await this.httpClient.GetStringAsync($"{this.baseUrl}{this.urlPrefix}/{id}");
			return JsonConvert.DeserializeObject<MeetingCategoryDTO>(meetingCategory);
		}

		public async Task<HttpResponseMessage> InsertMeetingCategoryAsync(MeetingCategoryDTO meetingCategoryDTO)
		{
			return await this.httpClient.PostAsync($"{this.baseUrl}{this.urlPrefix}", GetStringContentFromObject(meetingCategoryDTO));
		}

		public async Task<HttpResponseMessage> UpdateMeetingCategoryAsync(int id, MeetingCategoryDTO meetingCategory)
		{
			return await this.httpClient.PutAsync($"{this.baseUrl}{this.urlPrefix}/{id}", GetStringContentFromObject(meetingCategory));
		}

		public async Task<HttpResponseMessage> DeleteMeetingCategoryAsync(int id)
		{
			return await this.httpClient.DeleteAsync($"{this.baseUrl}{this.urlPrefix}/{id}");
		}
	}
}
