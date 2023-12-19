using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.authentication.repository;

public interface IUserRepository
{
    Task<User> getUserByUsername(string username);

    Task<List<Agreement>> getUserAgreements(string username);

    Task<EntityUser> getUserEntityInfo(string username);

    Task<IndividualUser> getUserIndividualInfo(string username);

    Task<List<UserRoom>> getUserRooms(string username);

    Task<string> deleteUserRoom(string username, long roomId);
    
    Task<string> setPassport(string token, long passportId);
}