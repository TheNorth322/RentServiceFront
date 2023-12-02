using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.data.authentication.api_request;

public class UserRequest : IUserRepository
{
    private IUserService _api;
    private UserClient _userClient;
    private SecureDataStorage _secureDataStorage;

    public UserRequest(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _userClient = new UserClient(_secureDataStorage.JwtToken);
        _api = _userClient.userService;
    }

    public async Task<User> getUserByUsername(string username)
    {
        return await _api.getUserByUsername(username);
    }

    public async Task<List<Agreement>> getUserAgreements(string username)
    {
        return await _api.getUserAgreements(username);
    }

    public async Task<EntityUser> getUserEntityInfo(string username)
    {
        return await _api.getUserEntityInfo(username);
    }

    public async Task<IndividualUser> getUserIndividualInfo(string username)
    {
        return await _api.getUserIndividualInfo(username);
    }

    public async Task<string> setPassport(string token, long passportId)
    {
        return await _api.setPassport(token, passportId);
    }
}