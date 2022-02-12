using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands;
using ScheduleService.Domain.CommandHandler.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace ScheduleService.Application.CommandHandlerTest.Handlers;

public class StubCommand : ICommandExecution
{ }

public class HandlerBaseStub : RequestHandler<StubCommand, CustomResultData>
{
    public int HandleExecutionCalls { get; private set; }
    public HandlerBaseStub()
    {
        HandleExecutionCalls = default;
    }

    public override async Task<CustomResultData> Handle(StubCommand request, CancellationToken cancellationToken)
    {
        HandleExecutionCalls++;
        return ValidResponse();
    }
}
