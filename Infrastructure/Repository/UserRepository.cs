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

    public async Task<bool> Delete(User existUser)
    {
        _appDbContext.User.Remove(existUser);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<User>> GetAll()
    {
       return await _appDbContext.User.ToListAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        var result = await _appDbContext.User.FirstOrDefaultAsync(u => u.Email == email);
        return result;
    }

    public async Task<User> GetById(int id)
    {
        var result = await _appDbContext.User.FirstOrDefaultAsync(u => u.Id == id);
        return result;
    }

    public async Task<bool> Update(int id, User existUser, UserDto user)
    {
        existUser.UserName = user.UserName;
        existUser.Email = user.Email;
        existUser.Password = user.Password;

        _appDbContext.User.Update(existUser);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}