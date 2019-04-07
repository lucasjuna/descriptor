using Descriptor.Application.Commands;
using Descriptor.Application.Services;
using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Domain.Seedwork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Descriptor.Application.CommandHandlers
{
	public class InitReviewerCommandHandler : IRequestHandler<InitReviewerCommand>
	{
		private readonly IIdentityService _identitySvc;
		private readonly IReviewerRepository _reviewerRepo;
		private readonly IUnitOfWork _uow;

		public InitReviewerCommandHandler(IIdentityService identitySvc, IReviewerRepository reviewerRepo, IUnitOfWork uow)
		{
			_identitySvc = identitySvc;
			_reviewerRepo = reviewerRepo;
			_uow = uow;
		}

		public async Task<Unit> Handle(InitReviewerCommand request, CancellationToken cancellationToken)
		{
			var user = _identitySvc.GetUser();
			var userFromDb = await _reviewerRepo.Find(user.Id);
			if (userFromDb == null)
			{
				userFromDb = new ReviewerInfo
				{
					Id = user.Id,
					EmpId = user.EmployeeId,
					FirstName = user.FirstName,
					LastName = user.LastName,
					LastLoginDateTime = user.LoginTime,
					LoginName = user.UserName
				};
				_reviewerRepo.Add(userFromDb);
			}
			else
			{
				userFromDb.Id = user.Id;
				userFromDb.EmpId = user.EmployeeId;
				userFromDb.FirstName = user.FirstName;
				userFromDb.LastName = user.LastName;
				userFromDb.LastLoginDateTime = user.LoginTime;
				userFromDb.LoginName = user.UserName;
			}
			await _uow.SaveEntitiesAsync();
			return Unit.Value;
		}
	}
}
