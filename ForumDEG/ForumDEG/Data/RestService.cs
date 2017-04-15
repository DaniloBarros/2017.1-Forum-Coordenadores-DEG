using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ForumDEG {
	public class RestService {

		HttpClient client;
		
		public RestService() {
			// var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
			// var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			// client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
		}

		public async Task<string> RefreshDataAsync() {
			var uri = new Uri(string.Format(Constants.RestUrl, "example-user"));
			var aee = "nao aeee";
			try {
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode) {
					var content = await response.Content.ReadAsStringAsync();
					Debug.WriteLine(@"				TodoItem successfully deleted.");
					System.Diagnostics.Debug.WriteLine(content);
					// var oi = (JObject) JsonConvert.DeserializeObject(content);
					// var user = (JObject) JsonConvert.DeserializeObject(JsonConvert.SerializeObject(oi));
					// Debug.WriteLine(oi["result"].Value<string>());

					var obj = JObject.Parse(content);
					var dict = obj["result"].ToObject<Dictionary<string, string>>();
					var success = obj["success"].ToObject<Boolean>();

					foreach (KeyValuePair<string, string> kvp in dict) {
						Debug.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
					}
					Debug.WriteLine(success);
					aee = "aeeee";
				}
				return aee;
			}
			catch (Exception ex) {
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
				return aee;
			}
		}
	}
}
