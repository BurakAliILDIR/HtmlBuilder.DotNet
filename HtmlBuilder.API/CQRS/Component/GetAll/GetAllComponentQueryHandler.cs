using AutoMapper;
using HtmlBuilder.API.CQRS.User.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HtmlBuilder.API.CQRS.Component.GetAll
{
    public class GetAllComponentQueryHandler : IRequestHandler<GetAllComponentQueryRequest, GetAllComponentQueryResponse>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllComponentQueryHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAllComponentQueryResponse> Handle(GetAllComponentQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Components.ToListAsync();

            var data = _mapper.Map<List<GetAllComponentDto>>(result);

            return new GetAllComponentQueryResponse { Data = data };
        }
    }
}
