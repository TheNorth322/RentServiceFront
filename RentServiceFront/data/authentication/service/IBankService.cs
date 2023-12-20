using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.bank;

namespace RentServiceFront.data.service;

public interface IBankService
{
    [Headers("Authorization: Bearer")]
    [Get("/bank/all")]
    Task<List<Bank>> getBanks();

    [Headers("Authorization: Bearer")]
    [Get("/bank/entities")]
    Task<List<EntityUser>> getAllEntityUserInBank(long id);

    [Headers("Authorization: Bearer")]
    [Post("/bank/create")]
    Task<Bank> createBank([Body] CreateBankRequest request);

    [Headers("Authorization: Bearer")]
    [Put("/bank/update")]
    Task<string> updateBank([Body] UpdateBankRequest request);

    [Headers("Authorization: Bearer")]
    [Delete("/bank/delete")]
    Task<string> deleteBank([Query] long id);
}