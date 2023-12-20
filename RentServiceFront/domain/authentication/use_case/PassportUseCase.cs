using System;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.passport;

namespace RentServiceFront.domain.authentication.use_case;

public class PassportUseCase
{
    private IPassportRepository _passportRepository;

    public PassportUseCase(IPassportRepository passportRepository)
    {
        _passportRepository = passportRepository ?? throw new ArgumentException("Passport repository can't be null");
    }

    public async Task<Passport> getPassportById(long id)
    {
        return await _passportRepository.getPassportById(id); 
    }

    public async Task<Passport> addPassport(AddPassportRequest request)
    {
        return await _passportRepository.addPassport(request);
    }

    public async Task<string> deletePassport(string username, long passport_id)
    {
        return await _passportRepository.deletePassport(username, passport_id);
    }


    public async Task<Passport> updatePassport(UpdatePassportRequest request)
    {
        return await _passportRepository.updatePassport(request);
    }
}