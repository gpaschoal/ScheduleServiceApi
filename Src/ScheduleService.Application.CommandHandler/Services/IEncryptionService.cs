namespace ScheduleService.Application.CommandHandler.Services;

public interface IEncryptionService
{
    public string Encrypt(string data);
    public string Decrypt(string data);
}
