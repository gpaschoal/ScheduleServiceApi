namespace ScheduleService.Domain.Model.Enums;

public enum EServiceOrderStatus
{
    /// <summary>
    /// Created and negotiating Items and values
    /// </summary>
    Opened = 0,

    /// <summary>
    /// After negotiation, scheduling a date to execute the service
    /// </summary>
    ToBeExecuted = 1,

    /// <summary>
    /// Service executed and waiting to be payed
    /// </summary>
    ToBePayed = 2,

    Finalized = 3,

    /// <summary>
    /// The service was cancelled
    /// </summary>
    Cancelled = 4,
}
