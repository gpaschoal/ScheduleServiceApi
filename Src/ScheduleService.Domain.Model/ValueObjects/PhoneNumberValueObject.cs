namespace ScheduleService.Domain.Model.ValueObjects;

public record PhoneNumberValueObject
{
    public PhoneNumberValueObject(int codeArea, int phoneNumber)
    {
        CodeArea = codeArea;
        PhoneNumber = phoneNumber;
    }

    public int CodeArea { get; private set; }
    public int PhoneNumber { get; private set; }

    public override sealed string ToString() => $"({CodeArea.ToString().PadLeft(3, '0')}) {PhoneNumber.ToString().PadLeft(11, '0')}";

    public void Deconstruct(out int codeArea, out int phoneNumber)
    {
        codeArea = CodeArea;
        phoneNumber = PhoneNumber;
    }
}
