using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.passport;

namespace RentServiceFront.data.service;

public interface IPassportService
{
    [Headers("Authorization: Bearer")]
    [Get("/passport/get")]
    Task<Passport> getPassportById([Query] long id);

    [Headers("Authorization: Bearer")]
    [Post("/passport/add")]
    Task<IndividualUser> addPassport([Body] AddPassportRequest request);

    [Headers("Authorization: Bearer")]
    [Put("/passport/update")]
    Task<Passport> updatePassport([Body] UpdatePassportRequest request);
    
    [Headers("Authorization: Bearer")]
    [Delete("/passport/delete")]
    Task<string> deletePassport([Query] string username, [Query] long passport_id);
}