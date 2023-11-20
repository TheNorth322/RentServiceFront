using System.Security.Principal;
using Refit;
using RentServiceFront.domain.enums;

namespace RentServiceFront.data.secure;

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

public class SecureDataStorage
{
    private readonly byte[] entropy = Encoding.Unicode.GetBytes("YourEntropyValue");
    private readonly string filePath = "./data.json";
    private ConfidentialData _confidentialData;

    public SecureDataStorage()
    {
        LoadFromFile();
    }

    public string JwtToken
    {
        get => UnprotectData(_confidentialData._jwtToken);
        set => ProtectData(ref _confidentialData._jwtToken, value);
    }

    public string RefreshToken
    {
        get => UnprotectData(_confidentialData._refreshToken);
        set => ProtectData(ref _confidentialData._refreshToken, value);
    }

    public string Username
    {
        get => UnprotectData(_confidentialData._username);
        set => ProtectData(ref _confidentialData._username, value);
    }

    public Role Role
    {
        get => UnprotectData(_confidentialData._role);
        set => ProtectData(ref _confidentialData._role, value);
    }

    public void SaveToFile()
    {
        string jsonData = JsonConvert.SerializeObject(_confidentialData);
        File.WriteAllText(filePath, jsonData);
    }

    private void LoadFromFile()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath, Encoding.UTF8);
            _confidentialData = JsonConvert.DeserializeObject<ConfidentialData>(jsonData);
        }
        else
        {
            _confidentialData = new ConfidentialData(); // Инициализация по умолчанию
        }
    }

    private void ProtectData(ref byte[] writeTo, string data)
    {
        writeTo = ProtectedData.Protect(Encoding.UTF8.GetBytes(data), entropy, DataProtectionScope.CurrentUser);
        SaveToFile();
    }

    private string UnprotectData(byte[] encryptedData)
    {
        return Encoding.UTF8.GetString(ProtectedData.Unprotect(encryptedData, entropy,
            DataProtectionScope.CurrentUser));
    }
    
    private void ProtectData(ref Role writeTo, Role data)
    {
        writeTo = data;
        SaveToFile();
    }

    private Role UnprotectData(Role role)
    {
        return role;
    }
}