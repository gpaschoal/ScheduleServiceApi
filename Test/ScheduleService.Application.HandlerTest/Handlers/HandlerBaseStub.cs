using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands;
using ScheduleService.Domain.Handler.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace ScheduleService.Application.HandlerTest.Handlers;

public class StubCommand : ICommandExecution
{ }

public class HandlerBaseStub : RequestHandler<StubCommand, CustomResultData>
{
    public int HandleExecutionCalls { get; private set; }
    public HandlerBaseStub()
    {
        HandleExecutionCalls = default;
    }

    public override Task<CustomResultData> Handle(StubCommand request, CancellationToken cancellationToken)
    {
        HandleExecutionCalls++;
        return ValidResponseAsync();
    }
}
