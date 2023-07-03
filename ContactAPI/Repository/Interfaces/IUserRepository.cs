using ContactAPI.Entities;
using ContactAPI.Models.DTOs;

namespace ContactAPI.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task Delete(User user);
        Task Archive(User user);
        Task<User> Create(User user);
        Task Update(int id_user, CreateUser dto);
    }
}
