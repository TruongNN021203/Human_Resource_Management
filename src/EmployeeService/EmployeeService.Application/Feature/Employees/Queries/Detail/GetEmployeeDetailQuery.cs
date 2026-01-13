using Contracts.ApiWrapper;
using Contracts.Routers;
using EmployeeService.Application.Employees.Queries.Detail;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Application.Feature.Employees.Queries.Detail
{
    public record GetEmployeeDetailQuery : IRequest<Result<GetEmployeeDetailResponse>>
    {
        [FromRoute(Name = RouterBase.Id)]
        public long EmployeeId { get; set; }
    }
}
