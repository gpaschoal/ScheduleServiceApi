using EasyValidation.DependencyInjection;

namespace ScheduleService.Application.Handler.Handlers;

public class HandlerBus : IHandlerBus
{
    public HandlerBus(IValidatorLocator validator)
    {
        Validator = validator;
    }

    public IValidatorLocator Validator { get; }
}
