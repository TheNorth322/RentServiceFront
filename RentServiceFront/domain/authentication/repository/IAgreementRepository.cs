using System.Threading.Tasks;
using RentServiceFront.domain.model.request.Agreement;

namespace RentServiceFront.domain.authentication.repository;

public interface IAgreementRepository
{
    Task<string> createAgreement(CreateAgreementRequest agreementRequest);
}