using Application.DTOS;
using DomainLayer.Entities;

namespace Application.Interface;

public interface IUser
{
    Task<User> GetById(int id);
    Task<User> GetByEmail(string email);
    Task<bool> Create(UserDto user);
    Task<bool> Update(int id ,User existUser, UserDto user);
    Task<bool> Delete(User existUser);
    Task<List<User>> GetAll();
}