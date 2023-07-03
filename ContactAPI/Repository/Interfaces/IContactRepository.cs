using ContactAPI.Entities;
using ContactAPI.Models.DTOs;

namespace ContactAPI.Repository.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAllByUser(int id);
        public void Create(CreateContact dto, int id);
        public void Update(CreateContact dto);
        public void Delete(int id);
    }
}
