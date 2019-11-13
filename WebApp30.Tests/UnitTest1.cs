using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace WebApp30.Tests
{
	[Collection("Integration tests collection")]
	public class UnitTest1
	{
		private readonly TestHostFixture _testHostFixture;
        private readonly ITestOutputHelper _testOutputHelper;

		public UnitTest1(TestHostFixture testHostFixture, ITestOutputHelper testOutputHelper)
        {
            _testHostFixture = testHostFixture;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task Returns_OK()
        {
            var response = await _testHostFixture.Client.GetAsync("/Home/Index");
            _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
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
