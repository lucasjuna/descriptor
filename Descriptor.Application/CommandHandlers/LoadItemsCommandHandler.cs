using Descriptor.Application.BackgroundJobs;
using Descriptor.Application.Commands;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Descriptor.Application.CommandHandlers
{
	public class LoadItemsCommandHandler : IRequestHandler<LoadItemsCommand>
	{
		private readonly IBackgroundJobClient backgroundWorker;
		private readonly ILoadItemsJob loadItemsJob;

		public LoadItemsCommandHandler(IBackgroundJobClient backgroundWorker, ILoadItemsJob loadItemsJob)
		{
			this.backgroundWorker = backgroundWorker;
			this.loadItemsJob = loadItemsJob;
		}

		public Task<Unit> Handle(LoadItemsCommand request, CancellationToken cancellationToken)
		{
			backgroundWorker.Enqueue<ILoadItemsJob>(x => x.Execute(request.UserName));
			return Unit.Task;
		}
	}
}
