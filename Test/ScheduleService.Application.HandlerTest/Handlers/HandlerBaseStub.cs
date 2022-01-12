﻿using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands;
using ScheduleService.Domain.Handler.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace ScheduleService.Application.HandlerTest.Handlers;

public class StubCommand : ICommandExecution
{ }

public class HandlerBaseStub : HandlerBase<StubCommand, CustomResultData>
{
    public int HandleExecutionCalls { get; private set; }
    public HandlerBaseStub(IHandlerBus handlerBus) : base(handlerBus)
    {
        HandleExecutionCalls = default;
    }

    public override Task<CustomResultData> HandleExecution(StubCommand request, CancellationToken cancellationToken)
    {
        HandleExecutionCalls++;
        return ValidResponse();
    }
}
