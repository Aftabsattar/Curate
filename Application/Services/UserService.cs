using Application.DTOS;
using Application.Interface;
using DomainLayer.Entities;

namespace Curate.Application.Services;

public class UserService
{
    private readonly IUser _user;
    public UserService(IUser user)
    {
          _user = user;
    }
    public async Task<string> Create(UserDto user)
    {
         var existingUser = await _user.GetByEmail(user.Email);
         if(existingUser != null)
         {
            throw new Exception("User with this email already exists");
        }
      var result = await _user.Create(user);
        if(result)
        {
            return "User created successfully";
        }
        return "Failed to create user";
    }

   public async Task<string> Update(int id, UserDto user)
   {
       var existingUser = await _user.GetById(id);
       if(existingUser == null)
       {
           return "User not found";
       }
       var result = await _user.Update(id, existingUser, user);
       if(result)
       {
           return "User updated successfully";
       }
       return "Failed to update user";
   }

    public async Task<string> Delete(int id)
    {
         var existingUser = await _user.GetById(id);
         if(existingUser == null)
         {
              return "User not found";
         }
         var result = await _user.Delete(existingUser);
         if(result)
         {
              return "User deleted successfully";
         }
         return "Failed to delete user";
    }
    public async Task<List<User>> ReadAll()
    {
         return await _user.GetAll();
    }
}