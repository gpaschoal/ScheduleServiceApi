using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScheduleService.Domain.CommandHandler.Commands;
using ScheduleService.Domain.Core.Repositories.Base;
using ScheduleService.Presentation.Api.Controllers.Base;

namespace ScheduleService.Presentation.Api.ActionFilters;

public class UoWActionFilter : IAsyncActionFilter
{
    private readonly IUnitOfWork _unitOfWork;

    public UoWActionFilter(IUnitOfWork unitOfWork)
    { _unitOfWork = unitOfWork; }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var isTransactable = context.ActionArguments.Any(argument => argument.Value is IRequest);

        if (isTransactable)
        {
            _unitOfWork.BeginTransaction();

            var invocationResult = await next();

            if (invocationResult.Result is not ObjectResult objectResult)
                return;

            if (objectResult.Value is CustomResponse resultData && resultData.Success)
                _unitOfWork.CommitTransaction();
            else
                _unitOfWork.RollBackTransaction();
        }
        else await next();
    }
}
