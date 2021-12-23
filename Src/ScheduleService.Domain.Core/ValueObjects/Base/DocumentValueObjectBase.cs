namespace ScheduleService.Domain.Core.ValueObjects.Base;

public abstract class DocumentValueObjectBase : IEquatable<DocumentValueObjectBase>
{
    public DocumentValueObjectBase(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public bool Equals(DocumentValueObjectBase? other)
    {
        if (other is null)
            return false;

        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as DocumentValueObjectBase);
    }
}
