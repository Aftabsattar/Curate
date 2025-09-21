using Application.DTOS;
using DomainLayer.Entities;

namespace Application.Interface;

public interface IUser
{
    Task<bool> Create(UserDto user);
    Task<bool> Update(int id , UserDto user);
    Task<bool> Delete(int id);
    Task<List<User>> GetAll();
}