using EasyValidation.DependencyInjection;

namespace ScheduleService.Application.Handler.Handlers;

public interface IHandlerBus
{
    IValidatorLocator Validator { get; }
}
