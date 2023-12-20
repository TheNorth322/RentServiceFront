using System.Threading.Tasks;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.passport;

namespace RentServiceFront.domain.authentication.repository;

public interface IPassportRepository
{
    Task<Passport> getPassportById(long id);

    Task<Passport> addPassport(AddPassportRequest request);

    Task<Passport> updatePassport(UpdatePassportRequest request);

    Task<string> deletePassport(string username, long passport_id);
}