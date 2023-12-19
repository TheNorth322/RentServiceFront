using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.data.service;

[Headers("Authorization: Bearer")]
public interface IUserService
{
    [Get("/user/{username}")]
    Task<User> getUserByUsername(string username);

    [Get("/user/{username}/agreements")]
    Task<List<Agreement>> getUserAgreements(string username);

    [Get("/user/{username}/entity")]
    Task<EntityUser> getUserEntityInfo(string username);

    [Get("/user/{username}/individual")]
    Task<IndividualUser> getUserIndividualInfo(string username);
    
    [Get("/user/{username}/rooms")]  
    Task<List<UserRoom>> getUserRooms(string username);
    
    [Delete("/user/{username}/rooms/delete")]
    Task<string> deleteUserRoom(string username, long roomId);
    [Post("/user/set/passport")]
    Task<string> setPassport([Query] string token, [Query] long passportId);
}