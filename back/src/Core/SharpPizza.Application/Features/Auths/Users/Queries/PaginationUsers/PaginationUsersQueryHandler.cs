using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Shared.Queries;
using SharpPizza.Application.Persistence;
using SharpPizza.Application.Specifications.Users;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Auths.Users.Queries.PaginationUsers
{
    public class PaginationUsersQueryHandler : IRequestHandler<PaginationUsersQuery, PaginationVm<Usuario>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaginationUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationVm<Usuario>> Handle(PaginationUsersQuery request, CancellationToken cancellationToken)
        {
            var userSpecificationParams = new UserSpecificationParams
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Search = request.Search,
                Sort = request.Sort
            };

            var spec = new UserSpecification(userSpecificationParams);
            var users = await _unitOfWork.Repository<Usuario>().GetAllWithSpec(spec);

            var specCount = new UserForCountingSpecification(userSpecificationParams);
            var totalUsers = await _unitOfWork.Repository<Usuario>().CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalUsers) / Convert.ToDecimal(request.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var usersByPage = users.Count();

            var pagination = new PaginationVm<Usuario>
            {
                Count = totalUsers,
                Data = users,
                PageCount = totalPages,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                ResultByPage = usersByPage
            };

            return pagination;
        }
    }
}