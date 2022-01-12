using EasyValidation.DependencyInjection;

namespace ScheduleService.Domain.Handler.Handlers;

public interface IHandlerBus
{
    IValidatorLocator Validator { get; }
}
