using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScheduleService.Application.Shared;
using ScheduleService.Domain.Repository;

namespace ScheduleService.Presentation.Api.ActionFilters;

public class UoWActionFilter : IActionFilter
{
    private readonly IUnitOfWork _unitOfWork;

    public UoWActionFilter(IUnitOfWork unitOfWork)
    { _unitOfWork = unitOfWork; }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _unitOfWork.BeginTransaction();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var newResult = context.Result as ObjectResult;

        if (newResult is null)
            return;

        if (newResult.Value is CustomResultData resultData && resultData is not null && resultData.IsValid)
            _unitOfWork.CommitTransaction();
        else
            _unitOfWork.RollBackTransaction();
    }
}