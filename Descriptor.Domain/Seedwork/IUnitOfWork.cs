using System;
using System.Threading;
using System.Threading.Tasks;

namespace Descriptor.Domain.Seedwork
{
	public interface IUnitOfWork : IDisposable
	{
		Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
