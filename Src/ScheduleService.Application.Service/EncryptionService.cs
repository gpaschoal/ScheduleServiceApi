﻿using Microsoft.Extensions.Options;
using ScheduleService.Application.CommandHandler.Services.Models;
using System.Security.Cryptography;
using System.Text;

namespace ScheduleService.Application.CommandHandler.Services;

public class EncryptionService : IEncryptionService
{
    private readonly EncryptionModel _encryptionModel;

    public EncryptionService(IOptions<EncryptionModel> encryptionModel)
    {
        _encryptionModel = encryptionModel.Value;
    }

    public string Encrypt(string encryptString)
    {
        byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
        using Aes encryptor = Aes.Create();
        Rfc2898DeriveBytes pdb = new(_encryptionModel.Key,
                    new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        encryptor.Key = pdb.GetBytes(32);
        encryptor.IV = pdb.GetBytes(16);
        using MemoryStream ms = new();
        using CryptoStream cs = new(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(clearBytes, 0, clearBytes.Length);
        cs.Close();

        encryptString = Convert.ToBase64String(ms.ToArray());

        return encryptString;
    }

    public string Decrypt(string cipherText)
    {
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using Aes encryptor = Aes.Create();
        Rfc2898DeriveBytes pdb = new(_encryptionModel.Key,
                    new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        encryptor.Key = pdb.GetBytes(32);
        encryptor.IV = pdb.GetBytes(16);
        using MemoryStream ms = new();
        using CryptoStream cs = new(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(cipherBytes, 0, cipherBytes.Length);
        cs.Close();

        cipherText = Encoding.Unicode.GetString(ms.ToArray());

        return cipherText;
    }
}
