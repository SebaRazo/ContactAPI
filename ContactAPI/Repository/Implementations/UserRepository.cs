using AutoMapper;
using ContactAPI.Data;
using ContactAPI.Entities;
using ContactAPI.Models.DTOs;
using ContactAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AgendaContext _context;                               // Inyecto el Context y el Mapper
        private readonly IMapper _mapper;
        public UserRepository(AgendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Archive(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Create(User user)//ESTA OK
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id) //ESTA OK
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            await _context.SaveChangesAsync();
        }


        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int userId)//ESTA OK
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task Update(int id_user, CreateUser dto)
        {
            var id = id_user;
            var userItem = _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userItem != null)
            {
                await _context.Users.AddAsync(_mapper.Map<User>(dto));
                await _context.SaveChangesAsync();
            }
        }

        Task IUserRepository.Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
