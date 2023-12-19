using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.request.Agreement;

namespace RentServiceFront.data.service;

public interface IAgreementService
{
    [Post("/agreement/create")]
    [Headers("Authorization: Bearer")]
    Task<string> createAgreement([Body] CreateAgreementRequest agreementRequest);

    [Get("/agreement/generate/pdf")]
    [Headers("Authorization: Bearer")]
    Task<HttpResponseMessage> generateAgreementPdf([Query] long id);

}