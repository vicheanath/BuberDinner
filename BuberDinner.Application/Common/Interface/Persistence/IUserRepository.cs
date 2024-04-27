
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interface.Persistence;

public interface IUserRepository
{
        User? GetUserByEmail(string email);
        void Add(User user);
}
