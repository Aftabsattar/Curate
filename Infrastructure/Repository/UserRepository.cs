using Application.DTOS;
using Application.Interface;
using DomainLayer.Entities;
using Infrastructure.Context;

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
        var result = await _appDbContext.Users.FindAsync(user);
        if (result != null) 
        {
            throw new Exception("User already exist");
        }
        
        var NewUser= new User 
        { 
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password
        };
        await _appDbContext.Users.AddAsync(NewUser);
        _appDbContext.SaveChanges();
        return true;
    }

    public Task<string> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<string> Update(int id, UserDto user)
    {
        throw new NotImplementedException();
    }
}
