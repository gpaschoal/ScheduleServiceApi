using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScheduleService.Domain.Command.Commands;
using ScheduleService.Domain.Repository;
using ScheduleService.Presentation.Api.Controllers.Base;

namespace ScheduleService.Presentation.Api.ActionFilters;

public class UoWActionFilter : IActionFilter
{
    private readonly IUnitOfWork _unitOfWork;
    private bool _isTransactable = false;

    public UoWActionFilter(IUnitOfWork unitOfWork)
    { _unitOfWork = unitOfWork; }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _isTransactable = context.ActionArguments.Any(argument => argument.Value is IRequest);

        if (_isTransactable)
            _unitOfWork.BeginTransaction();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (!_isTransactable)
            return;

        if (context.Result is not ObjectResult newResult)
            return;

        if (newResult.Value is CustomResponse resultData && resultData.Success)
            _unitOfWork.CommitTransaction();
        else
            _unitOfWork.RollBackTransaction();
    }
}