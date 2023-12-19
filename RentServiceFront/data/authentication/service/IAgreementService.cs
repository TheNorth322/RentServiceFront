using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.request.Agreement;

namespace RentServiceFront.data.service;

public interface IAgreementService
{
    [Post("/agreement/create")]
    [Headers("Authorization: Bearer")]
    Task<string> createAgreement([Body] CreateAgreementRequest agreementRequest);
}