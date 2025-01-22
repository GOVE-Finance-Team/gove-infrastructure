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
    public class UsertranslanderQuery
    {
        public class Query : IRequest<UserTranslanderEntites>
        {
            public int? CompanyId { get; set; }
            public int? UserId { get; set; }
            public Query(int? userId, int? companyId)
            {
                UserId = userId;
                CompanyId = companyId;

            }
        }
        public class Handler : IRequestHandler<Query, UserTranslanderEntites>
        {
            private readonly IUsermanagementRepository _getuserrepository;

            public Handler(IUsermanagementRepository repository)
            {
                _getuserrepository = repository;
            }
            public async Task<UserTranslanderEntites> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _getuserrepository.getUsertranslander(request.CompanyId, request.UserId);
            }
        }
    }
}
