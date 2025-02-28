using MediatR;
using Microsoft.Extensions.Configuration;
using Utilities.Configuration.Exceptions;

namespace Utilities.Configuration.MediatR;

public class GetConfigurationByKeyQueryHandler(IConfiguration configuration) : IRequestHandler<GetConfigurationByKeyQuery, string>
{

	public Task<string> Handle(GetConfigurationByKeyQuery request, CancellationToken cancellationToken)
	{
		string? value = configuration.GetValue<string>(request.Key);

		if (string.IsNullOrWhiteSpace(value))
		{
			throw new NotFoundException("Configuration Value", request.Key);
		}

		return Task.FromResult(value);
	}
}