using Application.DTOS;
using Application.Interface;
using DomainLayer.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class UserRepository : IUser
{
    private readonly AppDbContext _appDbContext;
    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<bool> Create(UserDto user)
    {
        var NewUser = new User
        {
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password
        };
        await _appDbContext.User.AddAsync(NewUser);
        _appDbContext.SaveChanges();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
       var result = await _appDbContext.User.FindAsync(id);
        if (result == null)
         {
              throw new Exception("User not found");
        }   
        _appDbContext.User.Remove(result);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<User>> GetAll()
    {
       return await _appDbContext.User.ToListAsync();
    }

    public async Task<bool> Update(int id, UserDto user)
    {
        var existingUser = await _appDbContext.User.FindAsync(id);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        existingUser.UserName = user.UserName;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;

        _appDbContext.User.Update(existingUser);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}