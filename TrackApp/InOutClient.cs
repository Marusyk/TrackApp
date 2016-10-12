using System.Collections.Generic;
using System.Linq;
using TrackApp.Model;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TrackApp
{
	internal class InOutClient
	{
		public static EmployeeStatus GetEmployeeStatus(string firstName, string lastName)
		{
			string responseString = string.Empty;
			using (var client = new HttpClient())
			{
				var response = client.GetAsync("http://inout.osdn.nl/index/ajax/format/json").Result;
				if (response.IsSuccessStatusCode)
				{
					var responseContent = response.Content;
					responseString = responseContent.ReadAsStringAsync().Result;
				}
			}

			if (string.IsNullOrEmpty(responseString)) return null;

			var jObject = JObject.Parse(responseString);

			var contents = JsonConvert.DeserializeObject<ICollection<Content>>(jObject["content"].ToString());
			int safescanId = contents
				.FirstOrDefault(x => x.FirstName.Equals(firstName) && x.LastName.Equals(lastName))
				.SafescanId;

			var statuses = JsonConvert.DeserializeObject<ICollection<EmployeeStatus>>(jObject["statuses"].ToString());
			return statuses
				.FirstOrDefault(x => x.SafescanId == safescanId);
		}
	}
}