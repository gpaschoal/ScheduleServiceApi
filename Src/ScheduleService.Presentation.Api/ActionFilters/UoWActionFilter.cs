using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScheduleService.Domain.Repository;
using ScheduleService.Presentation.Api.Controllers.Base;

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
        if (context.Result is not ObjectResult newResult)
            return;

        if (newResult.Value is CustomResponse resultData && resultData.Success)
            _unitOfWork.CommitTransaction();
        else
            _unitOfWork.RollBackTransaction();
    }
}