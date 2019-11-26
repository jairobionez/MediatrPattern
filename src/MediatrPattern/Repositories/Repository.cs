using MediatrPattern.Domain;
using MediatrPattern.Domain.Users.Commands;
using MediatrPattern.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrPattern.Repositories
{
    public class Data
    {
        public static List<User> USERS = new List<User>();
    }

    public class Write : IWrite
    {
        public Task Insert(User user)
        {
            Data.USERS.Add(user);
            return Task.CompletedTask;
        }
    }

    public class Read : IRead
    {
        public async Task<User> GetByEmail(string email) => Data.USERS.FirstOrDefault(u => u.Email.Equals(email));

        public async Task<User> GetById(Guid id) => Data.USERS.FirstOrDefault(u => u.Id.Equals(id));

        public async Task<IEnumerable<User>> List() => Data.USERS.ToList();
    }
}
