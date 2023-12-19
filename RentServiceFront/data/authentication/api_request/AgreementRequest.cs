using System.Threading.Tasks;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.request.Agreement;

namespace RentServiceFront.data.authentication.api_request;

public class AgreementRequest : IAgreementRepository
{
    private AgreementClient _agreementClient;
    private IAgreementService _api;
    private SecureDataStorage _secureDataStorage;

    public AgreementRequest(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _agreementClient = new AgreementClient(_secureDataStorage.JwtToken);
        _api = _agreementClient._agreementService;
    }

    public async Task<string> createAgreement(CreateAgreementRequest request)
    {
        return await _api.createAgreement(request);
    }
}