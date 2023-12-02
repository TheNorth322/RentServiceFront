using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.authentication.use_case;

public class UserUseCase
{
    private IUserRepository _userRepository;

    public UserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentException("User repository can't be null");
    }

    public async Task<User> getUserByUsername(string username)
    {
        return await _userRepository.getUserByUsername(username);
    }

    public async Task<List<Agreement>> getUserAgreements(string username)
    {
        
        return await _userRepository.getUserAgreements(username);
    }

    public async Task<EntityUser> getUserEntityInfo(string username)
    {
        
        return await _userRepository.getUserEntityInfo(username);
    }

    public async Task<IndividualUser> getUserIndividualInfo(string username)
    {
        
        return await _userRepository.getUserIndividualInfo(username);
    }

    public async Task<string> setPassport(string token, long passportId)
    {
        return await _userRepository.setPassport(token, passportId);
    }
}