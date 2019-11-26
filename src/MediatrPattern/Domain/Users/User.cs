using MediatR;
using MediatrPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrPattern.Domain
{
    public class User : IRequest<Response>
    {
        public User(string email, string name)
        {
            Email = email;
            Name = name;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
