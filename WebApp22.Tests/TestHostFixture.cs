using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace WebApp22.Tests
{
	/// <summary>
	/// One instance of this will be created per test collection.
	/// </summary>
	public class TestHostFixture : ICollectionFixture<WebApplicationFactory<Startup>>
	{
		public readonly HttpClient Client;

		public TestHostFixture()
		{
			var factory = new WebApplicationFactory<Startup>();
			Client = factory.CreateClient(new WebApplicationFactoryClientOptions{AllowAutoRedirect = false});
		}
	}

	[CollectionDefinition("Integration tests collection")]
	public class IntegrationTestsCollection : ICollectionFixture<TestHostFixture>
	{
		// This class has no code, and is never created. Its purpose is simply
		// to be the place to apply [CollectionDefinition] and all the
		// ICollectionFixture<> interfaces.
	}
}
