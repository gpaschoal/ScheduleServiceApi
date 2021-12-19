using EasyValidation.DependencyInjection;

namespace ScheduleService.Application.Handler;

public class HandlerBus : IHandlerBus
{
    public HandlerBus(IValidatorLocator validator)
    {
        Validator = validator;
    }

    public IValidatorLocator Validator { get; }
}
