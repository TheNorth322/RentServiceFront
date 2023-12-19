using System;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.request.Agreement;

namespace RentServiceFront.domain.authentication.use_case;

public class AgreementUseCase
{
    private IAgreementRepository _agreementRepository;

    public AgreementUseCase(IAgreementRepository agreementRepository)
    {
        _agreementRepository = agreementRepository ?? throw new ArgumentException("Agreement repository can't be null");
    }

    public async Task<string> createAgreement(CreateAgreementRequest request)
    {
        return await _agreementRepository.createAgreement(request);
    } 
}