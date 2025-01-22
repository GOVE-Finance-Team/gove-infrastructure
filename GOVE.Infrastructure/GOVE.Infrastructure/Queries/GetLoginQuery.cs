using GOVE.Models.Entities;
using GOVE.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOVE.Infrastructure.Queries
{
    public class GetLoginQuery
    {
        public class Query : IRequest<Login?>
        {
            public string UserName { get; }
            public string Password { get; }
            public Query(string userName, string password)
            {
                UserName = userName;
                Password = password;
            }
        }
        public class Handler(IUserRepository repository) : IRequestHandler<Query, Login?>
        {
            public async Task<Login?> Handle(Query request, CancellationToken cancellationToken) =>
                await repository.FindByUsername(request.UserName);
        }
    }
}
