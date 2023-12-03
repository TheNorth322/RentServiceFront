using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.bank;

namespace RentServiceFront.domain.authentication.use_case;

public class BankUseCase
{
    private IBankRepository _bankRepository;

    public BankUseCase(IBankRepository bankRepository)
    {
        _bankRepository = bankRepository;
    }

    public async Task<List<Bank>> getBanks()
    {
        return await _bankRepository.getBanks();
    }

    public async Task<Bank> createBank(CreateBankRequest request)
    {
        return await _bankRepository.createBank(request);
    }

    public async Task<string> updateBank(UpdateBankRequest request)
    {
        return await _bankRepository.updateBank(request);
    }

    public async Task<string> deleteBank(long id)
    {
        return await _bankRepository.deleteBank(id);
    }
}