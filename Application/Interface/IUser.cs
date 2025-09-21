using Application.DTOS;
using DomainLayer.Entities;

namespace Application.Interface;

public interface IUser
{
    Task<bool> Create(UserDto user);
    Task<string> Update(int id , UserDto user);
    Task<string> Delete(int id);
    Task<IEnumerable<User>> GetAll();
}