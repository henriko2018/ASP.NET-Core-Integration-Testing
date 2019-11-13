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
		public async Task Returns_OK()
		{
			var response = await _testHostFixture.Client.GetAsync("/Home/Index");
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}

		[Fact]
		public async Task Uses_settings_from_test()
		{
			var response = await _testHostFixture.Client.GetStringAsync("/Home/Index");
			Assert.Contains("Value from test", response);
		}

		[Fact]
		public async Task Uses_test_service_implementation()
		{
			var response = await _testHostFixture.Client.GetStringAsync("/Home/Index");
			Assert.Contains("TestImpl", response);
		}
	}
}
