using Microsoft.Extensions.Configuration;
using Utilities.Configuration.Exceptions;
using Utilities.Configuration.MediatR;

namespace Utilities.Configuration.Tests
{
	public class ConfigurationTests
	{
		private readonly IConfiguration _configuration = new ConfigurationBuilder()
			.AddInMemoryCollection(new Dictionary<string, string?>
			{
				{"Key1", "Value1"},
				{"SectionName:SomeKey", "SectionValue"}
			})
			.Build();

		[Fact]
		public async Task GetConfigurationByKey_ValidString_ReturnsTrue()
		{
			//Arrange
			IConfiguration configuration = _configuration;

			//Act
			GetConfigurationByKeyQuery request = new("Key1");
			GetConfigurationByKeyQueryHandler handler = new(configuration);
			string value = await handler.Handle(request, CancellationToken.None);

			//Assert
			Assert.Equal("Value1", value);
		}

		[Fact]
		public async Task GetConfigurationByKey_InvalidString_ReturnsFalse()
		{
			//Arrange
			IConfiguration configuration = _configuration;

			//Act
			GetConfigurationByKeyQuery request = new("Key2");
			GetConfigurationByKeyQueryHandler handler = new(configuration);

			//Assert
			await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, CancellationToken.None));
		}
	}
}