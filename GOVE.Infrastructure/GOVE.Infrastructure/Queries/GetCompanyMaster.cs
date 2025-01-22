using GOVE.Models.Requests;
using GOVE.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOVE.Infrastructure.Queries
{
    public class GetCompanyMaster
    {
        public class Query : IRequest<CompanyMasterRequest>
        {
            public int? CompanyId { get; set; }

            public Query(int? companyId)
            {

                CompanyId = companyId;

            }
        }
        public class Handler : IRequestHandler<Query, CompanyMasterRequest>
        {
            private readonly ICompanyRepository _getuserrepository;
            public Handler(ICompanyRepository repository)
            {
                _getuserrepository = repository;
            }
            public async Task<CompanyMasterRequest> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _getuserrepository.Get_CompanyMasterRepository(request.CompanyId);
            }
        }
    }
}
