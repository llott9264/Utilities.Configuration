using MediatR;

namespace Utilities.Configuration.MediatR
{
	public class GetConfigurationByKeyQuery(string key) : IRequest<string>
	{
		public string Key { get; } = key;
	}
}
