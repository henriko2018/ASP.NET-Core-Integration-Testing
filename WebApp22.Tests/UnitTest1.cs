using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace WebApp22.Tests
{
	[Collection("Integration tests collection")]
	public class UnitTest1
	{
		private readonly TestHostFixture _testHostFixture;

		public UnitTest1(TestHostFixture testHostFixture)
		{
			_testHostFixture = testHostFixture;
		}

		[Fact]
		public async Task Test1()
		{
			var response = await _testHostFixture.Client.GetAsync("/Home/Index");
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
	}
}
