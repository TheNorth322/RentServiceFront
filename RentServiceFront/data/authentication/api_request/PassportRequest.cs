using System.Threading.Tasks;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.passport;

namespace RentServiceFront.data.authentication.api_request;

public class PassportRequest : IPassportRepository
{
    private PassportClient _passportClient;
    private IPassportService _api;
    private SecureDataStorage _secureDataStorage;

    public PassportRequest(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _passportClient = new PassportClient(_secureDataStorage.JwtToken);
        _api = _passportClient._passportService;
    }

    public async Task<Passport> getPassportById(long id)
    {
        return await _api.getPassportById(id);
    }

    public async Task<Passport> addPassport(AddPassportRequest request)
    {
        return await _api.addPassport(request);
    }

    public async Task<Passport> updatePassport(UpdatePassportRequest request)
    {
        return await _api.updatePassport(request);
    }

    public async Task<string> deletePassport(string username, long passport_id)
    {
        return await _api.deletePassport(username, passport_id);
    }
}