using ScheduleService.Application.Handler.Repositories.Users;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Users;

public class UserSignInRepository : IUserSignInRepository
{
    private readonly IUserRepository _repository;

    public UserSignInRepository(IUserRepository repository)
    {
        _repository = repository;
    }
}
