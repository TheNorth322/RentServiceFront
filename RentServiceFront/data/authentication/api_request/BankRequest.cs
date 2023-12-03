using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.bank;

namespace RentServiceFront.data.authentication.api_request;

public class BankRequest : IBankRepository
{
    private BankClient _bankClient;
    private IBankService _api;
    private SecureDataStorage _secureDataStorage;

    public BankRequest(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _bankClient = new BankClient(_secureDataStorage.JwtToken);
        _api = _bankClient.bankService;
    }

    public async Task<List<Bank>> getBanks()
    {
        return await _api.getBanks();
    }

    public async Task<Bank> createBank(CreateBankRequest request)
    {
        return await _api.createBank(request);
    }

    public async Task<string> updateBank(UpdateBankRequest request)
    {
        return await _api.updateBank(request);
    }

    public async Task<string> deleteBank(long id)
    {
        return await _api.deleteBank(id);
    }
}