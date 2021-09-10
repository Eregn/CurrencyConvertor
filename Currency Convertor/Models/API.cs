using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Currency_Convertor.Models
{
	public class API
	{
		public async static Task<JObject> GetAPI()
		{
			var client = new HttpClient();
			var response = await client.GetAsync("http://api.exchangeratesapi.io/v1/latest?access_key=7b77dcf9adb2cbd55bd14dd922725d43");
			var responseString = await response.Content.ReadAsStringAsync();
			var obj = JsonConvert.DeserializeObject<JObject>(responseString);
			var rates = obj.Value<JObject>("rates");
			return rates;
		}

	}
}
