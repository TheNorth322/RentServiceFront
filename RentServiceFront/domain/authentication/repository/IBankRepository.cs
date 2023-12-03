using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.bank;

namespace RentServiceFront.domain.authentication.repository;

public interface IBankRepository
{
    Task<List<Bank>> getBanks();

    Task<Bank> createBank(CreateBankRequest request);

    Task<string> updateBank(UpdateBankRequest request);

    Task<string> deleteBank(long id);
}