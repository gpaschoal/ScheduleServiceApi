using EasyValidation.DependencyInjection;

namespace ScheduleService.Application.Handler;

public interface IHandlerBus
{
    IValidatorLocator Validator { get; }
}
