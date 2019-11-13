using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace RaceMeetingManagerUIBlazor.Data
{
	public abstract class BaseService
	{
		protected string baseUrl = "https://localhost:44364/";
		protected string urlPrefix;
		protected HttpClient httpClient;

		public BaseService(string urlPrefix)
		{
			this.httpClient = new HttpClient();
			this.urlPrefix = urlPrefix;
		}

		protected StringContent GetStringContentFromObject(object obj)
		{
			var serialized = JsonConvert.SerializeObject(obj);
			var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
			return stringContent;
		}
	}
}
