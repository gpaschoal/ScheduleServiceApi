using Microsoft.AspNetCore.Authorization;

namespace ScheduleService.Presentation.Api.Controllers.Base;

[AttributeUsage(AttributeTargets.Method)]
public class PolicyAuthorizationAttribute : AuthorizeAttribute
{
    public PolicyAuthorizationAttribute()
    { }

    public PolicyAuthorizationAttribute(string endpointPolicy)
    {
        EndpointPolicy = endpointPolicy;
    }
    public string? EndpointPolicy { get; }
}
