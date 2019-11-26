using MediatR;
using MediatrPattern.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrPattern.Domain.Users.Commands.Insert
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediatr;
        private readonly IWrite _write;
        private readonly IRead _read;

        public Handler(IMediator mediatr, IWrite write, IRead read)
        {
            _mediatr = mediatr;
            _write = write;
            _read = read;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var existingUser =  this._read.GetByEmail(request.Email);
            if (existingUser != null)
                return new Response("Username", "Já existe um caboclo com este e-mail");

            var user = request.ConvertToUser();
            await this._write.Insert(user);

            return Response.Ok;
        }
    }
}
