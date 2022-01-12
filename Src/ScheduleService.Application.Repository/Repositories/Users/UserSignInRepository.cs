using ScheduleService.Application.Handler.Repositories.Users;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Users;

internal class UserSignInRepository : IUserSignInRepository
{
    private readonly IUserRepository _repository;

    public UserSignInRepository(IUserRepository repository)
    {
        _repository = repository;
    }

    public User GetUserByEmailAndPassword(string email, string password)
    {
        return _repository.GetUserByEmailAndPassword(email, password);
    }
}
