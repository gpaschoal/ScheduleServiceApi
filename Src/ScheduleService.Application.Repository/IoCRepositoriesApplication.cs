using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Application.Repository.Repositories.Cities;
using ScheduleService.Application.Repository.Repositories.Countries;
using ScheduleService.Application.Repository.Repositories.RolePolicies;
using ScheduleService.Application.Repository.Repositories.Roles;
using ScheduleService.Application.Repository.Repositories.States;
using ScheduleService.Application.Repository.Repositories.UserRoles;
using ScheduleService.Application.Repository.Repositories.Users;
using ScheduleService.Domain.CommandHandler.Repositories.Cities;
using ScheduleService.Domain.CommandHandler.Repositories.Countries;
using ScheduleService.Domain.CommandHandler.Repositories.RolePolicies;
using ScheduleService.Domain.CommandHandler.Repositories.Roles;
using ScheduleService.Domain.CommandHandler.Repositories.States;
using ScheduleService.Domain.CommandHandler.Repositories.UserRoles;
using ScheduleService.Domain.CommandHandler.Repositories.Users;

namespace ScheduleService.Application.Repository;

public static class IoCRepositoriesApplication
{
    public static void AddApplicationRepository(IServiceCollection services)
    {
        _ = services
                /* City */
                .AddScoped<ICityCreateRepository, CityCreateRepository>()
                .AddScoped<ICityUpdateRepository, CityUpdateRepository>()
                .AddScoped<ICityDeleteRepository, CityDeleteRepository>()

                /* State */
                .AddScoped<IStateCreateRepository, StateCreateRepository>()
                .AddScoped<IStateUpdateRepository, StateUpdateRepository>()
                .AddScoped<IStateDeleteRepository, StateDeleteRepository>()

                /* Country */
                .AddScoped<ICountryCreateRepository, CountryCreateRepository>()
                .AddScoped<ICountryUpdateRepository, CountryUpdateRepository>()
                .AddScoped<ICountryDeleteRepository, CountryDeleteRepository>()

                /* User */
                .AddScoped<IUserSignInRepository, UserSignInRepository>()

                /* Role */
                .AddScoped<IRoleCreateRepository, RoleCreateRepository>()
                .AddScoped<IRoleUpdateRepository, RoleUpdateRepository>()
                .AddScoped<IRoleDeleteRepository, RoleDeleteRepository>()

                /* RolePolicy */
                .AddScoped<IRolePolicyCreateRepository, RolePolicyCreateRepository>()
                .AddScoped<IRolePolicyUpdateRepository, RolePolicyUpdateRepository>()
                .AddScoped<IRolePolicyDeleteRepository, RolePolicyDeleteRepository>()

                /* UserRole */
                .AddScoped<IUserRoleCreateRepository, UserRoleCreateRepository>()
                .AddScoped<IUserRoleUpdateRepository, UserRoleUpdateRepository>()
                .AddScoped<IUserRoleDeleteRepository, UserRoleDeleteRepository>()
                ;
    }
}
