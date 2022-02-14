using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands;
using ScheduleService.Domain.CommandHandler.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace ScheduleService.Application.CommandHandlerTest.Handlers;

public class StubCommand : ICommandExecution
{ }

public class HandlerBaseStub : CommandHandler<StubCommand, CustomResultData>
{
    public int HandleExecutionCalls { get; private set; }
    public HandlerBaseStub()
    {
        HandleExecutionCalls = default;
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public override async Task<CustomResultData> HandleAsync(StubCommand request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        HandleExecutionCalls++;
        return ValidResponse();
    }
}
