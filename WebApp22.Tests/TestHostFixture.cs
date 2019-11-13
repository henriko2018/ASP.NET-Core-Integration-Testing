using System;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Moq;
using Xunit;

namespace WebApp22.Tests
{
	/// <summary>
	/// One instance of this will be created per test collection.
	/// </summary>
	public class TestHostFixture : ICollectionFixture<CustomWebApplicationFactory>
	{
		public readonly HttpClient Client;

		public TestHostFixture()
		{
			var factory = new CustomWebApplicationFactory();
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

	public class TestStartup : Startup
	{
		public TestStartup(IConfiguration configuration) : base(configuration)
		{
		}

        public override void ConfigureServices(IServiceCollection services)
        {
            var mock = new Mock<ISomeService>();
            mock.Setup(service => service.Ping()).Returns("TestImpl");
            services.AddSingleton(mock.Object);

            var assembly = typeof(Startup).Assembly;
            services.Configure<RazorViewEngineOptions>(options =>
                options.FileProviders.Add(new EmbeddedFileProvider(assembly)));
            services.AddMvc()
                .AddApplicationPart(assembly)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
	}

	public class CustomWebApplicationFactory : WebApplicationFactory<TestStartup>
	{
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost
                .CreateDefaultBuilder(Array.Empty<string>())
                .UseStartup<TestStartup>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			base.ConfigureWebHost(builder);
			var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			if (string.IsNullOrEmpty(environmentName))
				throw new ArgumentException(
					$"{nameof(CustomWebApplicationFactory)}.{nameof(ConfigureWebHost)} needs environment variable ASPNETCORE_ENVIRONMENT to set environment.");
			builder.UseEnvironment(environmentName);
        }
    }
}
