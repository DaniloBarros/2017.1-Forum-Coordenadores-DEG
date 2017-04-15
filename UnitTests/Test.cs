using NUnit.Framework;
using System;
using ForumDEG;
using System.Threading.Tasks;

namespace UnitTests {
	[TestFixture()]
	public class Test {

		RestService data;

		[Test()]
		public async Task TestCase() {

			data = new RestService();

			var response = await data.RefreshDataAsync();
			System.Console.WriteLine(response);
			Boolean assert =  string.Equals(response, "aeeee");
			Assert.True(assert);

		}
	}
}
